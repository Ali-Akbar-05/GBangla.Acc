using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBMCheque : AuditableEntity
    {
        public long ChequeID { get; set; }
        public string ChequeNum { get; set; }
        public int? AccountID { get; set; }
        public int? ChequeStatusID { get; set; }
        public int? SignStatus { get; set; }
        public int ChequeBookID { get; set; }
        public decimal? ChequeAmount { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeDescription { get; set; }
        public string ChequeComments { get; set; }
        public long? VoucherID { get; set; }
        public int? ChequeSignatoryID { get; set; }

    }
}
