using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.DataTransferModel
{
   public class CBM_AcountTypeDTM:IMapFrom<CBM_AcountType>
    {
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeComments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_AcountTypeDTM, CBM_AcountType>();
        }
    }
}
