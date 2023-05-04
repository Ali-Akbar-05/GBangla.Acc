using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class Payment_TypeService : IPayment_TypeService
    {
        private readonly IPayment_TypeRepository payment_TypeRepository;

        public Payment_TypeService(IPayment_TypeRepository _payment_TypeRepository)
        {
            payment_TypeRepository = _payment_TypeRepository;
        }
        public async Task<List<SelectListItem>> DDLGetPaymentType(CancellationToken cancellationToken)
        {
            return await payment_TypeRepository.DDLGetPaymentType(cancellationToken);
        }
    }
}
