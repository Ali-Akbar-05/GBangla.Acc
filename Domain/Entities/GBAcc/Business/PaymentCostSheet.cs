using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class PaymentCostSheet
    {
        public int ID { get; set; }
        public string LCNo { get; set; }
        public int? COAID { get; set; }
        public decimal Amount { get; set; }
    }
}
