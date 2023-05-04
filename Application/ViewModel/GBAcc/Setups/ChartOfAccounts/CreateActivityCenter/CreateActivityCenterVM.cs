using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.ChartOfAccounts.CreateActivityCenter
{
   public class CreateActivityCenterVM
    {
        public int ActivityID { get; set; }

        [Display(Name = "Business")]
        public int BusinessID { get; set; }
        [Display(Name = "Cost Center")]
        [Required]
        public int CostCenterID { get; set; }
        [Display(Name = "Activity Center")]
        [Required]
        public string Activity { get; set; }
        public int LevelID { get; set; }
        public List<SelectListItem> DDLCostCenter { get; set; }
        public List<SelectListItem> DDLBusiness { get; set; }
    }
}
