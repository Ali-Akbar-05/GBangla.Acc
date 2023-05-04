using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum enum_AccLevels
    {
        Company = 1,
        Business = 2,
        Location = 3,
        Category = 4,
        SubCategory = 5,
        BroadGroup = 6,
        NarrowGroup = 7,
        Identification = 8,
        CostCenter = 11,
        Activity = 12,
        Item = 14,
    }
    public enum Enum_VoucherType
    {
        /// <summary>
        /// Cash Payment Voucher
        /// </summary>
        [Description("Cash Payment Voucher")]
        CPV =1,
        /// <summary>
        /// Bank Payment Voucher
        /// </summary>
        [Description("Bank Payment Voucher")]
        BPV = 2,
        JV = 3,
        GRV = 4,
        LSV = 5,
        ESV = 6,
        RV = 7,
        ICV = 9,
        BRV = 10,
        EV = 11,
        STV = 12,
        FAV = 13,
        BCA = 14,
        BDA = 15,
        IBC = 16,
        /// <summary>
        /// Debit Node Voucher
        /// </summary>
        DN = 17,
        CN = 18,
        RKV = 19,
        JVA = 20,
        WTV = 21,
        WRV = 22,
        BTV = 23,
        OJV = 24,
        /// <summary>
        /// Supplier Invoice Voucher
        /// </summary>
        SIV = 27,
        LC = 28,
        JVP = 29,
        EFV = 30,
        ERV = 31,
        CJV = 32,
        BLV = 33,
        ITV = 34,
        PRV = 35,
    }

    public enum Enum_VoucherAmountPaymentType
    {
        PaymentBank,
        CashReceipt,
        BankReceipt

    }
}
