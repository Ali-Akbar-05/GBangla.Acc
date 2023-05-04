using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups
{
   public class CBM_BankVM
    {
        public int BankID { get; set; }
        [Required]
        [Display(Name ="Bank")]
        public string BankName { get; set; }
        public string Abbreviation { get; set; }
        [Required]
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        public List<SelectListItem> DDLCompanyList { get; set; }
    }
}
