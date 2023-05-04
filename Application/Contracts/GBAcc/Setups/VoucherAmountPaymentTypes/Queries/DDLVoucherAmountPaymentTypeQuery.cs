using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.VoucherAmountPaymentTypes.Queries
{
    public class DDLVoucherAmountPaymentTypeQuery : IRequest<List<SelectListItem>>
    {
        public string Type { get; set; }
    }

    public class DDLVoucherAmountPaymentTypeQueryHandler : IRequestHandler<DDLVoucherAmountPaymentTypeQuery, List<SelectListItem>>
    {
        private readonly IVoucherAmountPaymentTypeService _voucherAmountPaymentTypeService;

        public DDLVoucherAmountPaymentTypeQueryHandler(IVoucherAmountPaymentTypeService voucherAmountPaymentTypeService)
        {
            _voucherAmountPaymentTypeService = voucherAmountPaymentTypeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLVoucherAmountPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            return await _voucherAmountPaymentTypeService.DDLPaymentType(request.Type, cancellationToken);
        }
    }
}
