using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
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
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private GBAccDbContext accDbContext;
        public SupplierRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> SupplierSave(Supplier model)
        {
            var result = new RResult();
            await accDbContext.Supplier.AddAsync(model);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.message = "Save Successfully";
            return result;
        }
        public async Task<Supplier>GetSupplierBySupplierID(int supplierID,CancellationToken cancellationToken)
        {
            var obj = await accDbContext.Supplier.Include(d => d.SupplierDetail.Where(d => d.IsActive == true && d.IsRemoved == false))
                .Include(sbnk => sbnk.SupplierBankInfo.Where(s => s.IsActive == true && s.IsRemoved == false))
                .Where(l => l.SupplierID == supplierID && l.IsActive == true && l.IsRemoved == false)
                .FirstOrDefaultAsync(cancellationToken);
            return obj;
        }
        public  IQueryable<SupplierResponseModel> GetSupplierList()
        {
            var rtnList =  from accCat in accDbContext.BasicCOA
                                 join accSubcat in accDbContext.BasicCOA on accCat.AccID equals accSubcat.ParentID
                                 join accBroad in accDbContext.BasicCOA on accSubcat.AccID equals accBroad.ParentID
                                 join accNarrow in accDbContext.BasicCOA on accBroad.AccID equals accNarrow.ParentID
                                 join accIden in accDbContext.BasicCOA on accNarrow.AccID equals accIden.ParentID
                                 join accItem in accDbContext.BasicCOA on accIden.AccID equals accItem.ParentID
                                 join sup in accDbContext.Supplier on accItem.AccID equals sup.SupplierID

                                 where accCat.LevelID == (int)enum_AccLevels.Category && accSubcat.LevelID == (int)enum_AccLevels.SubCategory
                                 && accBroad.LevelID== (int)enum_AccLevels.BroadGroup && accNarrow.LevelID== (int)enum_AccLevels.NarrowGroup
                                 && accIden.LevelID== (int)enum_AccLevels.Identification && accItem.LevelID== (int)enum_AccLevels.Item
                                 select new SupplierResponseModel()
                                 {
                                     AccID=accCat.AccID,
                                     AccCategory=accCat.AccName,
                                     AccSubCategory=accSubcat.AccName,
                                     AccBroadGroup=accBroad.AccName,
                                     AccNarrowGroup=accNarrow.AccName,
                                     AccIdentification=accIden.AccName,
                                     SupplierName=accItem.AccName,
                                     SupplierID=accItem.AccID

                                 };
            return rtnList;
                               
        }

        public async Task<List<SelectListItem>>GetDDLSupplierList(string  Predict, CancellationToken cancellationToken)
        {
            var supplierList = accDbContext.Supplier.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(s => new
                {
                    SupplierName = s.CompanyName,
                    SupplierID=s.SupplierID,
                });
            if (!string.IsNullOrEmpty(Predict))
            {
                supplierList.Where(b => b.SupplierName.Contains(Predict));
            }
            var rtnData = await supplierList.Select(s => new SelectListItem()
            {
                Text=s.SupplierName,
                Value=s.SupplierID.ToString()
            }).ToListAsync();
            return rtnData;
        }

     
    }
}
