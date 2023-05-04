using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel
{
    public class BankVouchersDTM
    {
        public List<VoucherDTM> Vouchers { get; set; }
        public InstrumentDTM Instrument { get; set; }
        
    }
    public class InstrumentDTM {
        public int InstrumentTypeID { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public string Narration { get; set; }
        public int SignatoryID { get; set; }
       
    }
}
