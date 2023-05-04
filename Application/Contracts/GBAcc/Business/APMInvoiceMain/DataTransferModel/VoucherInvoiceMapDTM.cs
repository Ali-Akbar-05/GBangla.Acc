using Application.Contracts.GBAcc.Business.CBMRFPs.DataTransferModel;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel
{
  public  class VoucherInvoiceMapDTM
    {
        public decimal DebitNoteAmount { get; set; }
        public APM_Invoice_MainDTM APM_Invoice_Main { get; set; }
        public CBM_RFP_DTM CBM_RFP { get; set; }
        public VoucherDTM Voucher { get; set; }
    }
}
