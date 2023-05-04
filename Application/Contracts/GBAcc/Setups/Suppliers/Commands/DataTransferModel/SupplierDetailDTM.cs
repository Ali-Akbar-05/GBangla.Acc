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
   public class SupplierDetailDTM:IMapFrom<SupplierDetail>,IMapFrom<SupplierDetailVM>
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplierDetailDTM, SupplierDetail>().ReverseMap();
            profile.CreateMap<SupplierDetailDTM, SupplierDetailVM>().ReverseMap();
        }
    }
}
