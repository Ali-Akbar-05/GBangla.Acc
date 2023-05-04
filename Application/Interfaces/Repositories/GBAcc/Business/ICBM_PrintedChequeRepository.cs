using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
   public interface ICBM_PrintedChequeRepository:IGenericRepository<CBM_PrintedCheque>
    {
        Task<List<PrintedChequesResponseModel>> GetCBM_PrintedCheques(PrintedChequesRequestModel model, CancellationToken cancellationToken);
        Task<RResult> UpdatePrintedCheque(List<CBM_PrintedCheque> model);
    }
}
