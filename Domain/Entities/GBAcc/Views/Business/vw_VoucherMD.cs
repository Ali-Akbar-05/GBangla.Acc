using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Views.Business
{
  public  class vw_VoucherMD
    {
        public long VoucherID { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public string FiscalYear { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public string VoucherDescription { get; set; }
        public int? Costcenter { get; set; }
        public int? LocationID { get; set; }
        public int? Activity { get; set; }
        public DateTime RDate { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int? Vindex { get; set; }
        public long VDetailsID { get; set; }
        public int? PreparedBy { get; set; }
        public int? CheckedBy { get; set; }
        public int? AuthorizedBy { get; set; }
        public int? IndividualVoucherId { get; set; }
        public int VoucherType { get; set; }
        public int? IdentificationID { get; set; }
        public int? NoOfDays { get; set; }
        public int? EntryType { get; set; }
        public decimal? CRate { get; set; }
        public int? CurrencyID { get; set; }
    }
}
