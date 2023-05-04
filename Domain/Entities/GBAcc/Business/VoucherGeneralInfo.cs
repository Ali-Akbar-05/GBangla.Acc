using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class VoucherGeneralInfo : AuditableEntity
    {
        public long ID { get; set; }
        public long VoucherID { get; set; }
        public int AccountID { get; set; }
        public string Description { get; set; }
        public string Billno { get; set; }
        public DateTime? Billdate { get; set; }
        public string ReferenceNo { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? InTaxPercent { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QuantityRate { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public string Comments { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? ConversionRate { get; set; }
        public string SupplierDONumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? GRNDate { get; set; }
        public DateTime? DCDate { get; set; }
        public int? InvoiceEffect { get; set; }
        public int? VIndex { get; set; }
        public decimal? ExciseDuty { get; set; }
        public string LCNumber { get; set; }
        public int? LCID { get; set; }
        public int? BankAccID { get; set; }

        public Voucher Voucher { get; set; }

    }
}
