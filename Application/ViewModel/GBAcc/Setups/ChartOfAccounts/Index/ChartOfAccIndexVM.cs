using Application.Common.CommonModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.ChartOfAccounts.Index
{
  public  class ChartOfAccIndexVM
    {
        public List<SelectListItem> DDLAccLevel { get; set; }
        public List<SelectListItem> DDLAccCategory { get; set; }
        public List<SelectListItem> DDLAccSubCategory { get; set; }
        public List<SelectListItem> DDLAccBroadGroup { get; set; }
        public List<SelectListItem> DDLAccNarroGroup { get; set; }
        public List<SelectListItem> DDLAccIdentification { get; set; }

        public int AccID { get; set; }

        [Display(Name ="Acc Level")]
        public int AccLevelID { get; set; }
        [Display(Name = "Category")]
        public int AccCategoryID { get; set; }
        [Display(Name = "Sub Category")]
        public int SubCategoryID { get; set; }
        [Display(Name = "Broad Group")]
        public int BroadGroupID { get; set; }
        [Display(Name = "Narrow Group")]
        public int NarrowGroupID { get; set; }
        [Display(Name = "Identityfication")]
        public int IdentificationID { get; set; }


        [Required]
        [Display(Name = "Chart Of Accounts Name")]
        public string AccName { get; set; }



    }
}
