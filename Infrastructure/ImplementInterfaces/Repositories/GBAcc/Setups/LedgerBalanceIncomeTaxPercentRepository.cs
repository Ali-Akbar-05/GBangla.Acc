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
    public class LedgerBalanceIncomeTaxPercentRepository : GenericRepository<LedgerBalanceIncomeTaxPercent>, ILedgerBalanceIncomeTaxPercentRepository
    {
        private readonly GBAccDbContext _dbCon;
        public LedgerBalanceIncomeTaxPercentRepository(GBAccDbContext context)
            : base(context)
        {
            _dbCon = context;
        }
       
        public async Task<decimal> GetIncomeTaxPercent(decimal LedgerAmount, int CompanyID ,CancellationToken cancellationToken)
        {
        
            var qry =await _dbCon.LedgerBalanceIncomeTaxPercent
                 .Where(b => b.IsRemoved == false && b.IsActive == true
                   && (b.BalanceAmountFrom <= LedgerAmount && b.BalanceAmountTo >= LedgerAmount )
                   && b.CompanyID==CompanyID
                   )
                 .Select(b=> new { IncomeTaxPer = b.IncomeTaxPer})
                 .FirstOrDefaultAsync(cancellationToken);
            if (qry == null)
            {
                return 0;
            }
               return qry.IncomeTaxPer;
        }
    }
}
