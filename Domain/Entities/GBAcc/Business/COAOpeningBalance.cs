using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class COAOpeningBalance
    {
        public long ID { get; set; }
        public int CompanyID { get; set; }
        public int FiscalYear { get; set; }
        public int AccountID { get; set; }
        public decimal OpeningBalance { get; set; }

        public int? CostCenterID { get; set; }
        public int? ActivityID { get; set; }
        public int? LocationID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
