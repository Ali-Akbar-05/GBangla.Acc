using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel
{
    public class ChartOfAccountRequestModel
    {
        public int AccLevelID { get; set; }
        public int ParentID { get; set; }
        public string Predict { get; set; }

        public int CompanyID { get; set; }
    }
}
