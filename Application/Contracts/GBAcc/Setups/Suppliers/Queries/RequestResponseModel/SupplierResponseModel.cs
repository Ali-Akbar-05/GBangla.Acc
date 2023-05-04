using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel
{
  public  class SupplierResponseModel 
    {
        public int AccID { get; set; }
        public string AccCategory { get; set; }
        public string AccSubCategory { get; set; }
        public string AccBroadGroup { get; set; }
        public string AccNarrowGroup { get; set; }
        public string AccIdentification { get; set; }
        public string SupplierName { get; set; }
        public int SupplierID { get; set; }

    }
}
