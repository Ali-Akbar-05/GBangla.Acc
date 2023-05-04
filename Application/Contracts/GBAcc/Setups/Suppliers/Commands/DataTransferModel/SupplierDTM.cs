using Application.Common.Mappings;
using Application.ViewModel.GBAcc.Setups.Suppliers.Create;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel
{
   public class SupplierDTM:IMapFrom<Supplier>,IMapFrom<SupplierVM>
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string SupplierCode { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }
        public int ParentID { get; set; }
        public int LevelID { get; set; }
        public int CompanyID { get; set; }
        public List<SupplierDetailDTM> SupplierDetail { get; set; }
        public List<SupplierBankInfoDTM> SupplierBankInfo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Supplier, SupplierDTM>().ReverseMap();
            profile.CreateMap<SupplierDTM, SupplierVM>().ReverseMap();
        }
    }
}
