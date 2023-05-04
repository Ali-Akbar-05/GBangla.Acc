using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.ChartOfAccounts.CreateCostCenter
{
   public class CostCenterVM
    {
        [Display(Name ="Business")]
        public int BusinessID { get; set; }
       

        public int CostCenterID { get; set; }
        [Display(Name = "Cost Center")]
        [Required]
        public string CostCenter { get; set; }
        public int LevelID { get; set; }
        public List<SelectListItem> DDLBusiness { get; set; }
    }
}
