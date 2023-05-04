using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
   public interface ICBMChequeBookRepository :IGenericRepository<CBMChequeBook>
    {
        Task<int> AvailableCheque(int AccountID, CancellationToken cancallationToken);
        Task<RResult> CreateChequeBook(CBMChequeBook model );
        Task<List<CBMChequeBookResponseModel>> GetChequeBookList(ChequeBookRequestModel model, CancellationToken cancellationToken);

        Task<ChequeInActiveInfoResponseModel> GetInactiveChequeInfo(int AccountID, CancellationToken cancellationToken);
    }
}
