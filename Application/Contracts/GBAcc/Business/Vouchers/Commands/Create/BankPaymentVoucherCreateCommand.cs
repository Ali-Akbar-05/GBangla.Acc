using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.Create
{
   public class BankPaymentVoucherCreateCommand:IRequest<RResult>
    {
        public BankVouchersDTM BankVouchers { get; set; }
    }
    public class BankPaymentVoucherCreateCommandHandler : IRequestHandler<BankPaymentVoucherCreateCommand, RResult>
    {
        private readonly IVoucherService voucherService;

        public BankPaymentVoucherCreateCommandHandler(IVoucherService _voucherService)
        {
            voucherService = _voucherService;
        }
        public async Task<RResult> Handle(BankPaymentVoucherCreateCommand request, CancellationToken cancellationToken)
        {
            return await voucherService.SaveBankPaymentVoucher(request.BankVouchers,cancellationToken);
        }
    }
}
