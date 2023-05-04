
using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
    public interface IPOAdvancePaymentRepository : IGenericRepository<POAdvancePayment>
    {
       Task<List<AdvancedPoResponseModel>> GetPoAdvanced(int supplierID, string poNumberList, CancellationToken cancellationToken);
    }
}
