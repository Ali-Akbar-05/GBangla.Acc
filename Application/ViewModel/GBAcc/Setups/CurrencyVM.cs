using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups
{
   public class CurrencyVM
    {
        public int CurrencyID { get; set; }
        [Required]
        [Display(Name ="Currency")]
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
    }
}
