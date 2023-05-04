using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APMInvoiceMain.Commands.Create
{
   public class VoucherInvoiceMapCreateCommand:IRequest<RResult>
    {
        public VoucherInvoiceMapDTM VoucherInvoiceMapDTM { get; set; }
    }
    public class VoucherInvoiceMapCreateCommandHandler : IRequestHandler<VoucherInvoiceMapCreateCommand, RResult>
    {
        private readonly IAPM_Invoice_MainService aPM_Invoice_MainService;

        public VoucherInvoiceMapCreateCommandHandler(IAPM_Invoice_MainService _aPM_Invoice_MainService)
        {
            aPM_Invoice_MainService = _aPM_Invoice_MainService;
        }
        public async Task<RResult> Handle(VoucherInvoiceMapCreateCommand request, CancellationToken cancellationToken)
        {
            var result =  await aPM_Invoice_MainService.SaveVoucherInvoiceMap(request.VoucherInvoiceMapDTM, cancellationToken);
            if (result != null && result.result != 1)
            {
                result.message = "Found terrible Problem";
            }
            return result;
        }
    }
}
