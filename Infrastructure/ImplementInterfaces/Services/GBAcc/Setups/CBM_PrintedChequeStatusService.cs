using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class CBM_PrintedChequeStatusService : ICBM_PrintedChequeStatusService
    {
        private readonly ICBM_PrintedChequeStatusRepository cBM_PrintedChequeStatusRepository;

        public CBM_PrintedChequeStatusService(ICBM_PrintedChequeStatusRepository _cBM_PrintedChequeStatusRepository)
        {
            cBM_PrintedChequeStatusRepository = _cBM_PrintedChequeStatusRepository;
        }
        public async Task<List<SelectListItem>> DDLGetCBMPrintedChequeStatus(CancellationToken cancellationToken)
        {
            return await cBM_PrintedChequeStatusRepository.DDLGetCBMPrintedChequeStatus(cancellationToken);
        }
    }
}
