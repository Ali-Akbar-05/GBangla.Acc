using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Suppliers.Create
{
   public class SupplierDetailVM
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        [Display(Name = "Phone")]
        public string CellNumber { get; set; }
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }
    }
}
