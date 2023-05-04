using Application.Common.Mappings;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Suppliers.Create
{
  public  class SupplierVM:IMapFrom<SupplierDTM>
    {
       
        public int SupplierID { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public string CompanyName { get; set; }
        public string SupplierCode { get; set; }
        public string Address { get; set; }
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Fax")]
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Sales Tax Registration Number")]
        public string SalesTaxRegNumber { get; set; }
        [Display(Name = "National Tax Payer Number")]
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Supplier Type")]
        public string SupplierType { get; set; }
        public int ParentID { get; set; }
        public int LevelID { get; set; }
        public int CompanyID { get; set; }
        public string SelectedItem { get; set; }
        public List<SupplierDetailVM> SupplierDetail { get; set; }
        public List<SupplierBankInfoVM> SupplierBankInfo { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<SupplierV>
        //}
    }
}
