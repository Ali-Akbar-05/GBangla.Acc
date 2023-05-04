using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface ICBMChequeBookService
    {
        Task<int> AvailableCheque(int AccountID, CancellationToken cancallationToken);
        Task<RResult> CreateChequeBook( List<CBMChequeBookDTM> model, CancellationToken cancellationToken);
        Task<List<CBMChequeBookResponseModel>> GetChequeBookList(ChequeBookRequestModel model,CancellationToken cancellationToken);
        //
    }
}
