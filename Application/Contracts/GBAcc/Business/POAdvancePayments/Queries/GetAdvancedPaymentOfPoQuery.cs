using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.POAdvancePayments.Queries
{
    public class GetAdvancedPaymentOfPoQuery : IRequest<List<AdvancedPoResponseModel>>
    {
        public int SupplierID { get; set; }
        public string PoNumver { get; set; }
    }
    public class GetAdvancedPaymentOfPoQueryHandler : IRequestHandler<GetAdvancedPaymentOfPoQuery, List<AdvancedPoResponseModel>>
    {
        private readonly IPOAdvancePaymentService pOAdvancePaymentService;

        public GetAdvancedPaymentOfPoQueryHandler(IPOAdvancePaymentService _pOAdvancePaymentService)
        {
            pOAdvancePaymentService = _pOAdvancePaymentService;
        }
        public async Task<List<AdvancedPoResponseModel>> Handle(GetAdvancedPaymentOfPoQuery request, CancellationToken cancellationToken)
        {
            return await pOAdvancePaymentService.GetPoAdvanced(request.SupplierID, request.PoNumver, cancellationToken);
        }
    }
}
