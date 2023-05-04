using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.Create
{
  public  class CBMChequeBookCreateCommand:IRequest<RResult>
    {
        public List<CBMChequeBookDTM> CBMChequeBook { get; set; }
    }
    public class CBMChequeBookCreateCommandHandler : IRequestHandler<CBMChequeBookCreateCommand, RResult>
    {
        private readonly ICBMChequeBookService iCBMChequeBookService;

        public CBMChequeBookCreateCommandHandler(ICBMChequeBookService _iCBMChequeBookService)
        {
            iCBMChequeBookService = _iCBMChequeBookService;
        }
        public async Task<RResult> Handle(CBMChequeBookCreateCommand request, CancellationToken cancellationToken)
        {
            return await iCBMChequeBookService.CreateChequeBook(request.CBMChequeBook, cancellationToken);
        }
    }
}
