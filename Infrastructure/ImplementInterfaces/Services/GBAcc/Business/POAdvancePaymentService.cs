using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class POAdvancePaymentService : IPOAdvancePaymentService
    {
        private readonly IPOAdvancePaymentRepository pOAdvancePaymentRepository;

        public POAdvancePaymentService(IPOAdvancePaymentRepository _pOAdvancePaymentRepository)
        {
            pOAdvancePaymentRepository = _pOAdvancePaymentRepository;
        }
        public async Task<List<AdvancedPoResponseModel>> GetPoAdvanced(int supplierID, string poNumberList, CancellationToken cancellationToken)
        {
            return await pOAdvancePaymentRepository.GetPoAdvanced(supplierID, poNumberList, cancellationToken);
        }
    }
}
