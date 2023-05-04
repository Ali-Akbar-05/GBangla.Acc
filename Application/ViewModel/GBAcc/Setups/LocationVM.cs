using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups
{
   public class LocationVM
    {
        public int SrNum { get; set; }
        public string LocationCode { get; set; }
        [Required]
        [Display(Name ="Location")]
        public string LocationName { get; set; }
        [Display(Name = "Description")]
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        [Display(Name = "Plot No")]
        public string PlotNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        [Display(Name = "Telephone 1")]
        public string Tel1 { get; set; }
        [Display(Name = "Telephone 2")]
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Location Initials")]
        public string LocationInitials { get; set; }
    }
}
