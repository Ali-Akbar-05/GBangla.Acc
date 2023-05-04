using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Currences.Commands.DataTransferModel
{
   public class CurrencyDTM:IMapFrom<Currency>
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CurrencyDTM, Currency>().ReverseMap();
        }
    }
}
