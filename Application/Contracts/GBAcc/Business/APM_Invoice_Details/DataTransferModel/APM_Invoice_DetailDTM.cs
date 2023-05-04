using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APM_Invoice_Details.DataTransferModel
{
  public  class APM_Invoice_DetailDTM:IMapFrom<APM_Invoice_Detail>
    {
        public long InvoiceDetailID { get; set; }
        public long InvoiceID { get; set; }
        public long VoucherID { get; set; }
        public int? InvoiceEffect { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<APM_Invoice_DetailDTM, APM_Invoice_Detail>();
        }
    }
}
