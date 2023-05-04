using Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface ICBMChequeService
    {
        Task<List<CBMChequeResponseModel>> GetChequeList(int chequeBookID, CancellationToken cancellationToken);
    }
}
