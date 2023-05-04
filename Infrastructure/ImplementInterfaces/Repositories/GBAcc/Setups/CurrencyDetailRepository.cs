using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
   public class CurrencyDetailRepository:GenericRepository<CurrencyDetail>, ICurrencyDetailRepository
    {
        private GBAccDbContext accDbContext;
        public CurrencyDetailRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<List<CurrencyDetailResponseModel>>GetAllCurrencyDetailList(CancellationToken cancellationToken)
        {
            var rtnList = await (from cur in accDbContext.Currency
                                 join cd in accDbContext.CurrencyDetail on new { a1 = cur.CurrencyID, a2 = true, a3 = false } equals new { a1 = cd.CurrencyID, a2 = cd.IsActive, a3 = cd.IsRemoved }
                                 select new CurrencyDetailResponseModel()
                                 {
                                     ID=cd.ID,
                                     Date=cd.Date.ToString("dd-MMM-yyyy"),
                                     RateInBDT=cd.RateInBDT,
                                     Currency=cur.CurrencyName,
                                  CurrencyID=cd.CurrencyID,
                                 }).ToListAsync(cancellationToken);
            return rtnList;
        }

        public async Task<CurrencyDetailResponseModel>GetCurrencyDetailByCurrencyID(int currencyID,CancellationToken cancellationToken)
        {
            var obj = await accDbContext.CurrencyDetail.Where(b => b.CurrencyID == currencyID && b.IsActive == true && b.IsRemoved == false)
                .Select(s => new CurrencyDetailResponseModel()
                {
                    ID=s.ID,
                    CurrencyID=s.CurrencyID,
                    RateInBDT=s.RateInBDT,
                    Date=s.Date.ToString("dd-MMM-yyyy")
                }).FirstOrDefaultAsync(cancellationToken);
            return obj;
        }
    }
}
