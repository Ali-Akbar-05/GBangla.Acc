using Application.Contracts.GBAcc.Business.POInfo.Queries.DataResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.POInfo.Queries
{
    public class GetPOForAdvanceQuery :IRequest<List<POForAdvanceDRM>>
    {
        public int SupplierID { get; set; }
    }
    public class GetPOForAdvanceQueryHandler : IRequestHandler<GetPOForAdvanceQuery, List<POForAdvanceDRM>>
    {
        private readonly IPOInfoService _poInfoService;

        public GetPOForAdvanceQueryHandler(IPOInfoService poInfoService)
        {
            _poInfoService = poInfoService;
        }
        public async Task<List<POForAdvanceDRM>> Handle(GetPOForAdvanceQuery request, CancellationToken cancellationToken)
        {
            return await _poInfoService.GetPOForAdvance(request.SupplierID,cancellationToken);
        }
    }
}
