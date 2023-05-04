

using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
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
   public class CBM_BankRepository :GenericRepository<CBM_Bank>, ICBM_BankRepository
    {
        private GBAccDbContext accDbContext;
        public CBM_BankRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

       public async Task<List<CBM_BankResponseModel>>GetCBMBankList(CancellationToken cancellationToken)
        {
            var rtnData = await (from com in accDbContext.CompanyInfo
                                join b in accDbContext.CBM_Bank on com.CompanyID equals b.CompanyID
                                where b.IsActive == true && b.IsRemoved == false
                                select new CBM_BankResponseModel()
                                {
                                    BankID=b.BankID,
                                    BankName=b.BankName,
                                    CompanyID=b.CompanyID,
                                    CompanyName=com.CompanyName,
                                    Abbreviation=b.Abbreviation

                                }).ToListAsync();
            return rtnData;
        }

        public async Task<RResult> BankDataDelete(int bankID)
        {
            var result = new RResult();
            var obj = await accDbContext.CBM_Bank.FindAsync(bankID);
            obj.IsActive = false;
            obj.IsRemoved = true;
            accDbContext.CBM_Bank.Update(obj);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.message = "Delete Successfully";
            return result;
        }

        public async Task<List<SelectListItem>>DDLGetBankList(int companyID, CancellationToken cancellationToken)
        {
            var rtnList = await accDbContext.CBM_Bank.Where(s => s.IsActive == true && s.IsRemoved == false && s.CompanyID==companyID )
                .Select(x => new SelectListItem()
                {
                    Text=x.BankName,
                    Value=x.BankID.ToString()
                }).Distinct().ToListAsync(cancellationToken);

            return rtnList;
        }
    }
}
