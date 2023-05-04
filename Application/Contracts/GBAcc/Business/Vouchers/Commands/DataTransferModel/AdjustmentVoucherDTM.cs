using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel
{
  public  class AdjustmentVoucherDTM
    {
        public long VoucherID { get; set; }
        public long InvoiceID { get; set; }
        public decimal Deduction { get; set; }

    }
}
