using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.DataTransferModel
{
    public class CBM_BankDTM :IMapFrom<CBM_Bank>
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int CompanyID { get; set; }
        public string Abbreviation { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_BankDTM, CBM_Bank>().ReverseMap();
        }
    }
}
