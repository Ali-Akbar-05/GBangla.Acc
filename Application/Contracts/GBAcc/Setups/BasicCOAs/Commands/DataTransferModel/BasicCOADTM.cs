using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel
{
    public class BasicCOADTM : IMapFrom<BasicCOA>
    {
        public long AccID { get; set; }
        public string AccName { get; set; }
        public string AccCode { get; set; }
        public int? ParentID { get; set; }
        public int LevelID { get; set; }
        public long? NaturalAccountID { get; set; }
        public int? CompanyID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasicCOADTM, BasicCOA>();
        }
    }
}
