using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries
{
   public class GetChequeBookListQuery:IRequest<List<CBMChequeBookResponseModel>>
    {
        public ChequeBookRequestModel ChequeBook { get; set; }
    }
    public class GetChequeBookListQueryHandler : IRequestHandler<GetChequeBookListQuery, List<CBMChequeBookResponseModel>>
    {
        private readonly ICBMChequeBookService cBMChequeBookService;

        public GetChequeBookListQueryHandler(ICBMChequeBookService _cBMChequeBookService)
        {
            cBMChequeBookService = _cBMChequeBookService;
        }
        public async Task<List<CBMChequeBookResponseModel>> Handle(GetChequeBookListQuery request, CancellationToken cancellationToken)
        {
            return await cBMChequeBookService.GetChequeBookList(request.ChequeBook, cancellationToken);
        }
    }
}
