using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
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
   public class CurrencyRepository:GenericRepository<Currency>, ICurrencyRepository
    {
        private GBAccDbContext accDbContext;
        public CurrencyRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

        public async Task<RResult> CurrencyUpdate(Currency model)
        {
            var result = new RResult();
            var dbObj = await accDbContext.Currency.FindAsync(model.CurrencyID);
            dbObj.CurrencyName = model.CurrencyName;
            dbObj.Symbol = model.Symbol;
            dbObj.ShortName = model.ShortName;
            accDbContext.Currency.Update(dbObj);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.message = "Update Successfully";
            return result;
        }
        public async Task<List<CurrencyResponseModel>> GetCurrencyList(CancellationToken cancellationToken)
        {
            var list = await accDbContext.Currency.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(s => new CurrencyResponseModel() {
                CurrencyID=s.CurrencyID,
                 CurrencyName=s.CurrencyName,
                 ShortName=s.ShortName,
                 Symbol=s.Symbol
                
                }).ToListAsync();
            return list;
        }

        public async Task<RResult>CurrencyDataDelete(int currencyID)
        {
            var result = new RResult();
            var dbObj = await accDbContext.Currency.FindAsync(currencyID);
            dbObj.IsActive = false;
            dbObj.IsRemoved = true;
            accDbContext.Currency.Update(dbObj);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.message = "Delete Successfully";
            return result;
        }

        public async Task<List<SelectListItem>> DDLCurrency(CancellationToken cancellationToken)
        {
            var list = await accDbContext.Currency.Where(b => b.IsActive == true && b.IsRemoved == false)
                 .Select(s => new SelectListItem()
                 {
                     Text = s.CurrencyName,
                     Value = s.CurrencyID.ToString(),
                 }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
