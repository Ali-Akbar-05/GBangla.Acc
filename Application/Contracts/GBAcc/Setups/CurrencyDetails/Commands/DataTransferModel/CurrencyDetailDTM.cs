using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.DataTransferModel
{
  public  class CurrencyDetailDTM:IMapFrom<CurrencyDetail>
    {
        public int ID { get; set; }
        public decimal RateInBDT { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CurrencyDetailDTM, CurrencyDetail>().ReverseMap();
        }
    }
}
