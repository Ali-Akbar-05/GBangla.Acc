using Application.Common.Mappings;
using Application.Contracts.GBAcc.Setups.CustomerBankInfos.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CustomerDetails.Commands.DataTransferModel;
using Application.ViewModel.GBAcc.Setups.Customers.Create;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel
{
  public  class CustomerDTM:IMapFrom<Customer>,IMapFrom<CustomerVM>
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxNumber { get; set; }
        public string NationalTaxNumber { get; set; }
        public int ParentID { get; set; }
        public int LevelID { get; set; }
        public int CompanyID { get; set; }
        public List<CustomerDetailDTM> CustomerDetail { get; set; }
        public List<CustomerBankInfoDTM> CustomerBankInfo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerDTM, Customer>().ReverseMap();
            profile.CreateMap<CustomerDTM, CustomerVM>().ReverseMap();
        }
    }
}
