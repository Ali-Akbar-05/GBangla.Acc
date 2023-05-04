using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Business;
//using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.Create
{
   public class SupplierInvoiceVoucherCreateCommand:IRequest<RResult>
    {
        public VoucherDTM VoucherDTM { get; set; }
    }
    public class SupplierInvoiceVoucherCreateCommandHandler : IRequestHandler<SupplierInvoiceVoucherCreateCommand, RResult>
    {
        private readonly IVoucherService voucherService;

        public SupplierInvoiceVoucherCreateCommandHandler(IVoucherService _voucherService)
        {
            voucherService = _voucherService;
        }
        public async Task<RResult> Handle(SupplierInvoiceVoucherCreateCommand request, CancellationToken cancellationToken)
        {
            return await voucherService.SaveSupplierInvoiceVoucher(request.VoucherDTM);
        }
    }

}
