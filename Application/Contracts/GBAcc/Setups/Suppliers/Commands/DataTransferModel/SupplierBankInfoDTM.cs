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
  public  class SupplierBankInfoDTM:IMapFrom<SupplierBankInfo>,IMapFrom<SupplierBankInfoVM>
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplierBankInfoDTM, SupplierBankInfo>().ReverseMap();
            profile.CreateMap<SupplierBankInfoDTM, SupplierBankInfoVM>().ReverseMap();
        }
    }
}
