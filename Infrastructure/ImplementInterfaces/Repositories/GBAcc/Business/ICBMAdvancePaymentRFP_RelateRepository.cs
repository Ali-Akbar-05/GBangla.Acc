using Application.Common.CommonModels;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
   public class CBMAdvancePaymentRFP_RelateRepository :GenericRepository<CBMAdvancePaymentRFP_Relate>, ICBMAdvancePaymentRFP_RelateRepository
    {
        private readonly GBAccDbContext _dbCon;
        public CBMAdvancePaymentRFP_RelateRepository(GBAccDbContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

       public async Task<RResult> SaveList(List<CBMAdvancePaymentRFP_Relate> model)
        {
            RResult result = new RResult();
            _dbCon.AddRange(model);
            await _dbCon.SaveChangesAsync();

            result.result = 1;
            return result;
        }
    }
}
