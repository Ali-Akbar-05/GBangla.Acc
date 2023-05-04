using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.CurrencyDetails.Create
{
  public  class CurrencyDetailVM
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Rate (BDT)")]
        public decimal RateInBDT { get; set; }
        [Required]
        public string Date { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        public List<SelectListItem> DDLCurrencyList { get; set; }
    }
}
