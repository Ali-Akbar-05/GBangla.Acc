using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.JournalVoucherInfos.Commands.DataTransferModel
{
  public  class JournalVoucherInfoDTM:IMapFrom<JournalVoucherInfo>
    {
        public int ID { get; set; }
        public long VoucherID { get; set; }
        public int ItemID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public int? Vindex { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JournalVoucherInfoDTM, JournalVoucherInfo>();
        }
    }
}
