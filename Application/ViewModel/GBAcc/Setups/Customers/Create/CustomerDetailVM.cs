using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Customers.Create
{
   public class CustomerDetailVM
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Division { get; set; }
    }
}
