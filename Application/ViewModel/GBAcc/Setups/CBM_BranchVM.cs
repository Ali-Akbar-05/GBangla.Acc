using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups
{
   public class CBM_BranchVM
    {
        public int BranchID { get; set; }
        [Required]
        [Display(Name ="Branch")]
        public string BranchName { get; set; }
        [Display(Name = "Address")]
        public string BranchAddress { get; set; }
        [Required]
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        public List<SelectListItem> DDLBankList{ get; set; }
    }
}
