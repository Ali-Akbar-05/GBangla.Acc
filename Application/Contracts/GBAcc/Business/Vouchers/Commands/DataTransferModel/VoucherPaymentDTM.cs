using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel
{
  public  class VoucherPaymentDTM
    {
        public long InvoiceID { get; set; }
        public decimal Deduction { get; set; }
        public decimal VatAmount { get; set; }
        public decimal ITaxAmount { get; set; }
    }
}
