using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
    public interface ICBMChequeRepository : IGenericRepository<CBMCheque>
    {
        Task<RResult> UpdateCBMCheque(CBMCheque entity);
        Task<RResult> SaveCBMChequeList(List<CBMCheque> model);
        Task<List<CBMChequeResponseModel>> GetChequeList(int chequeBookID, CancellationToken cancellationToken);
    }
}
