using Application.Common.Mappings;
using Application.ViewModel.GBAcc.Setups.Customers.Create;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CustomerDetails.Commands.DataTransferModel
{
   public class CustomerDetailDTM:IMapFrom<CustomerDetail>,IMapFrom<CustomerVM>
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Division { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerDetailDTM, CustomerDetail>().ReverseMap();
            profile.CreateMap<CustomerDetailDTM, CustomerDetailVM>().ReverseMap();
        }
    }
}
