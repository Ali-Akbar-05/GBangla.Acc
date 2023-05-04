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
    public class GetAvailableChequeQuery :IRequest<int>
    {
        public int AccountID { get; set; }
    }
    public class GetAvailableChequeQueryHandler : IRequestHandler<GetAvailableChequeQuery, int>
    {
        private readonly ICBMChequeBookService _cbmChequeBookService;

        public GetAvailableChequeQueryHandler(ICBMChequeBookService cbmChequeBookService)
        {
            _cbmChequeBookService = cbmChequeBookService;
        }

        public async Task<int> Handle(GetAvailableChequeQuery request, CancellationToken cancellationToken)
        {
            return await _cbmChequeBookService.AvailableCheque(request.AccountID,cancellationToken);
        }
    }
}
