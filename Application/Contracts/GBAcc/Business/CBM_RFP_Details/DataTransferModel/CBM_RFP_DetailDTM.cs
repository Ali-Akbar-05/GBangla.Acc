using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBM_RFP_Details.DataTransferModel
{
   public class CBM_RFP_DetailDTM:IMapFrom<CBM_RFP_Detail>
    {
        public long ID { get; set; }
        public long RFPID { get; set; }
        public long InvoiceID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_RFP_DetailDTM, CBM_RFP_Detail>();
        }
    }
}
