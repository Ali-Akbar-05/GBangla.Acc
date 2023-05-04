using Application.Common.CommonModels;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
   public class OpeningBalancesRepository:GenericRepository<OpeningBalances>, IOpeningBalancesRepository
    {
        private readonly GBAccDbContext _dbCon;
        public OpeningBalancesRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<RResult>SaveOpeningBalance(OpeningBalances model)
        {
            var result = new RResult();
            int FiscalYear = 0;
            var fiscalYearInfo = await _dbCon.FiscalYear.FirstAsync();
            if (model.RDate.Month < fiscalYearInfo.StartMonth)
            {
                FiscalYear = model.RDate.AddYears(-1).Year;
            }
            else
            {
                FiscalYear = model.RDate.Year;
            }
            model.FiscalYear = FiscalYear;
            await _dbCon.OpeningBalances.AddAsync(model);
            await _dbCon.SaveChangesAsync();
            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            return result;
        }
    }
}
