
using Application.Contracts.GBAcc.Business.POInfo.Queries.DataResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Infrastructure.Persistence;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class POInfoRepository : IPOInfoRepository
    {
        private GBAccDbContext _dbCon;
       
        public POInfoRepository(GBAccDbContext dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<POForAdvanceDRM>> GetPOForAdvance(int SupplierID, CancellationToken cancellationToken)
        {
            List<POForAdvanceDRM> poAdvancedList = new List<POForAdvanceDRM>();

            await _dbCon.LoadStoredProc("ajt.USP_GetPoForAdvanceInfo")
                .WithSqlParam("SupplierID", SupplierID)
                .ExecuteStoredProcAsync((handler) =>
                {
                  poAdvancedList = handler.ReadToList<POForAdvanceDRM>() as List<POForAdvanceDRM>;
                });
            return poAdvancedList;
        }
    }
}
