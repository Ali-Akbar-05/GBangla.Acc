using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BankContactInfos.Commands.DataTransferModel
{
  public  class BankContactInfoDTM:IMapFrom<BankContactInfo>
    {
        public int AccountID { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BankContactInfoDTM, BankContactInfo>();
        }
    }
}
