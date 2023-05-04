using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Snickler.EFCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class POAdvancePaymentRepository : GenericRepository<POAdvancePayment>, IPOAdvancePaymentRepository
    {
        private GBAccDbContext accDbContext;
        public POAdvancePaymentRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

        public async Task<List<AdvancedPoResponseModel>> GetPoAdvanced(int supplierID, string poNumberList, CancellationToken cancellationToken)
        {
            var poAdvancedList = new List<AdvancedPoResponseModel>();

            await accDbContext.LoadStoredProc("Ajt.USP_GetAdvanceOfPo")
                .WithSqlParam("SupplierID", supplierID)

                   .WithSqlParam("PONumList", poNumberList)
                .ExecuteStoredProcAsync((handler) =>
                {
                    poAdvancedList = handler.ReadToList<AdvancedPoResponseModel>() as List<AdvancedPoResponseModel>;

                });
            return poAdvancedList;
        }
    }
}
