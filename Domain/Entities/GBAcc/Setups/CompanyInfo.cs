using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CompanyInfo : AuditableEntity
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string NTN { get; set; }
        public string STN { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CompanyShortName { get; set; }
        public string MainFactoryAddress { get; set; }
    }
}
