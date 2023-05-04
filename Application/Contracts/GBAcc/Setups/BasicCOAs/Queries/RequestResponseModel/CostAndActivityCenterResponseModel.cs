using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel
{
   public class CostAndActivityCenterResponseModel
    {
        public int AccID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int BusinessID { get; set; }
        public string Business { get; set; }
        public int CostCenterID { get; set; }
        public string CostCenter { get; set; }
        public int ActivityID { get; set; }
        public string Activity { get; set; }
        public int LevelID { get; set; }

    }
}
