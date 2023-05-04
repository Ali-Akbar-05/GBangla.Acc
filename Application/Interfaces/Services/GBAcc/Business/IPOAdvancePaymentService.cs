
using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
    public interface IPOAdvancePaymentService
    {
        Task<List<AdvancedPoResponseModel>> GetPoAdvanced(int supplierID, string poNumberList, CancellationToken cancellationToken);
    }
}
