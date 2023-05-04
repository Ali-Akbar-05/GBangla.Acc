using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Locations.Commands.DataTransferModel
{
   public class LocationDTM:IMapFrom<Location>
    {
        public int SrNum { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string PlotNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string LocationInitials { get; set; }
       
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationDTM, Location>().ReverseMap();
        }
    }
}
