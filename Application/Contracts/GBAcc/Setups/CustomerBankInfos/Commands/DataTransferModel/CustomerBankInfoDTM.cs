using Application.Common.Mappings;
using Application.ViewModel.GBAcc.Setups.Customers.Create;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CustomerBankInfos.Commands.DataTransferModel
{
   public class CustomerBankInfoDTM:IMapFrom<CustomerBankInfo>,IMapFrom<CustomerBankInfoVM>
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerBankInfoDTM, CustomerBankInfo>().ReverseMap();
            profile.CreateMap<CustomerBankInfoDTM, CustomerBankInfoVM>().ReverseMap();
        }
    }
}
