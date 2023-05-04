using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.CBMAcountType.CreateAccountType
{
  public  class AccountTypeVM
    {
        public int AccountTypeID { get; set; }
        [Required]
        [Display(Name = "Account Type")]
        public string AccountTypeName { get; set; }
        [Display(Name = "Comments")]
        public string AccountTypeComments { get; set; }
    }
}
