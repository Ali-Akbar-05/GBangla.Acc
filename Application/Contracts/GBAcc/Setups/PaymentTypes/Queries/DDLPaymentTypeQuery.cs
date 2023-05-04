using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.PaymentTypes.Queries
{
   public class DDLPaymentTypeQuery:IRequest<List<SelectListItem>>
    {

    }

    public class DDLPaymentTypeQueryHandler : IRequestHandler<DDLPaymentTypeQuery, List<SelectListItem>>
    {
        private readonly IPayment_TypeService payment_TypeService;

        public DDLPaymentTypeQueryHandler(IPayment_TypeService _payment_TypeService)
        {
            payment_TypeService = _payment_TypeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            return await payment_TypeService.DDLGetPaymentType(cancellationToken);
        }
    }
}
