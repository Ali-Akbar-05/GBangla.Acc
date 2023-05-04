using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.DataTransferModel
{
  public  class CBM_PrintedChequeDTM:IMapFrom<CBM_PrintedCheque> 
    {
        public long ChqID { get; set; }
        public string ReceivingPerson { get; set; }
        public string Identification { get; set; }
        public int? Status { get; set; }
        public DateTime? TransactionDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_PrintedChequeDTM, CBM_PrintedCheque>();
        }
    }
}
