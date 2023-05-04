using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.DataTransferModel
{
   public class CBM_BranchDTM:IMapFrom<CBM_Branch>
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public int BankID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_BranchDTM, CBM_Branch>().ReverseMap();
        }
    }
}
