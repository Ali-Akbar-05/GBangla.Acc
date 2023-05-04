using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Views.Setups
{
    public class vw_BasicCOA
    {
        public long Serial { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryLevelID { get; set; }
        public int? SubCategoryID { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryLevelID { get; set; }
        public int? BroadGroupID { get; set; }
        public string BroadGroup { get; set; }
        public int BroadGroupLevelID { get; set; }
        public int? NarrowGroupID { get; set; }
        public string NarrowGroup { get; set; }
        public int NarrowGroupLevelID { get; set; }
        public int? IdentificationID { get; set; }
        public string Identification { get; set; }
        public int IdentificationLevelID { get; set; }
        public int? ItemID { get; set; }
        public string Item { get; set; }
        public int ItemLevelID { get; set; }

    }
}
