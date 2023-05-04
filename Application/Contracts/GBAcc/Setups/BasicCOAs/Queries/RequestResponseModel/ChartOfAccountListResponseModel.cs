using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel
{
    public class ChartOfAccountListResponseModel
    {
        public long Serial { get; set; }
        public int CompanyID { get; set; }
        public string Company { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int? SubCategoryID { get; set; }
        public string SubCategory { get; set; }

        public int? BroadGroupID { get; set; }
        public string BroadGroup { get; set; }

        public int? NarrowGroupID { get; set; }
        public string NarrowGroup { get; set; }

        public int? IdentificationID { get; set; }
        public string Identification { get; set; }

        public int? ItemID { get; set; }
        public string Item { get; set; }

    }
}
