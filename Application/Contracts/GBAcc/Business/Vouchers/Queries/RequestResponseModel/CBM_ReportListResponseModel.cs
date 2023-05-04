using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel
{
  public  class CBM_ReportListResponseModel
    {
        public long VoucherID { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public int VoucherType { get; set; }
    }
}
