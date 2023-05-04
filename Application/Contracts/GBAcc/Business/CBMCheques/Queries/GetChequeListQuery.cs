using Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMCheques.Queries
{
   public class GetChequeListQuery:IRequest<List<CBMChequeResponseModel>>
    {
        public int ChequeBookID { get; set; }
    }
    public class GetChequeListQueryHandler : IRequestHandler<GetChequeListQuery, List<CBMChequeResponseModel>>
    {
        private readonly ICBMChequeService cBMChequeService;

        public GetChequeListQueryHandler(ICBMChequeService _cBMChequeService)
        {
            cBMChequeService = _cBMChequeService;
        }
        public async Task<List<CBMChequeResponseModel>> Handle(GetChequeListQuery request, CancellationToken cancellationToken)
        {
            return await cBMChequeService.GetChequeList(request.ChequeBookID, cancellationToken);
        }
    }
}
