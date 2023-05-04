using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Customers.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private GBAccDbContext accDbContext;
        public CustomerRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> CustomerSave(Customer model)
        {
            try
            {
                var result = new RResult();
                await accDbContext.Customer.AddAsync(model);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = ReturnMessage.SaveMessage;
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }

        public async Task<List<SelectListItem>> DDLCustomer(string predict, CancellationToken cancellationToken)
        {
            var query = accDbContext.Customer.Where(x => x.IsActive == true && x.IsRemoved == false)
                .Select(r => new
                {
                    r.CustomerID,
                    r.CustomerName,
                    r.CustomerCode,
                    FullCustomerName = $"{r.CustomerName}-{r.CustomerCode}"                   
                });
            if (!string.IsNullOrEmpty(predict))
            {
                query = query.Where(b => b.CustomerName.Contains(predict)|| b.CustomerCode.Contains(predict));
            }
            var data = await query.Select(s => new SelectListItem()
            {
                Text = s.FullCustomerName,
                Value = s.CustomerID.ToString()                
            }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<Customer> GetCustomerByCustomerID(int customerID, CancellationToken cancellationToken)
        {
            var dbCustomer = await accDbContext.Customer.Include(d => d.CustomerDetail.Where(cd => cd.IsActive == true && cd.IsRemoved == false))
                .Include(cb=>cb.CustomerBankInfo.Where(b=>b.IsActive==true && b.IsRemoved==false))
                .Where(c=>c.IsActive==true && c.IsRemoved==false && c.CustomerID==customerID)
                .FirstOrDefaultAsync();
            return dbCustomer;
           
        }

        public async Task<List<CustomerResponseModel>> GetCustomerList(CancellationToken cancellationToken)
        {
            var rtnList = await (from accCat in accDbContext.BasicCOA
                                 join accSubcat in accDbContext.BasicCOA on new {a1=accCat.AccID,a2=true,a3=false}equals new {a1=accSubcat.ParentID.Value,a2=accSubcat.IsActive,a3=accSubcat.IsRemoved}
                                // join accSubcat in accDbContext.BasicCOA  on accCat.AccID equals accSubcat.ParentID
                                 join accBroad in accDbContext.BasicCOA on new { a1 = accSubcat.AccID, a2 = true, a3 =false } equals new { a1 = accBroad.ParentID.Value, a2 = accBroad.IsActive, a3 = accBroad.IsRemoved }//on accSubcat.AccID equals accBroad.ParentID
                                 join accNarrow in accDbContext.BasicCOA on new { a1 = accBroad.AccID, a2 = true, a3 = false } equals new { a1 = accNarrow.ParentID.Value, a2 = accNarrow.IsActive, a3 = accNarrow.IsRemoved }//on accBroad.AccID equals accNarrow.ParentID
                                 join accIden in accDbContext.BasicCOA on new { a1 = accNarrow.AccID, a2 = true, a3 = false } equals new { a1 = accIden.ParentID.Value, a2 = accIden.IsActive, a3 = accIden.IsRemoved }//on accNarrow.AccID equals accIden.ParentID
                                 join accItem in accDbContext.BasicCOA on new { a1 = accIden.AccID, a2 = true, a3 = false } equals new { a1 = accItem.ParentID.Value, a2 = accItem.IsActive, a3 = accItem.IsRemoved }//on accIden.AccID equals accItem.ParentID
                                 join cus in accDbContext.Customer on new { a1 = accItem.AccID, a2 = true, a3 = false } equals new { a1 = cus.CustomerID, a2 = cus.IsActive, a3 = cus.IsRemoved }//on accItem.AccID equals sup.CustomerID

                                 where accCat.LevelID == (int)enum_AccLevels.Category && accSubcat.LevelID == (int)enum_AccLevels.SubCategory
                                 && accBroad.LevelID == (int)enum_AccLevels.BroadGroup && accNarrow.LevelID == (int)enum_AccLevels.NarrowGroup
                                 && accIden.LevelID == (int)enum_AccLevels.Identification && accItem.LevelID == (int)enum_AccLevels.Item
                                 select new CustomerResponseModel()
                                 {
                                     AccID = accCat.AccID,
                                     AccCategory = accCat.AccName,
                                     AccSubCategory = accSubcat.AccName,
                                     AccBroadGroup = accBroad.AccName,
                                     AccNarrowGroup = accNarrow.AccName,
                                     AccIdentification = accIden.AccName,
                                     CustomerName = accItem.AccName,
                                     CustomerID = accItem.AccID

                                 }).ToListAsync();
            return rtnList;

        }
    }
}
