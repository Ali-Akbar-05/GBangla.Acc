using Application.Common.Mappings;
using Application.Contracts.GBAcc.Business.APM_Invoice_Details.DataTransferModel;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel
{
  public  class APM_Invoice_MainDTM:IMapFrom<APM_Invoice_Main>
    {
        public APM_Invoice_MainDTM()
        {
            APM_Invoice_Detail = new List<APM_Invoice_DetailDTM>();
        }
        public long InvoiceID { get; set; }
        public string InvoiceSystemID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string PONum { get; set; }
        public int SupplierID { get; set; }
        public int CompanyID { get; set; }
        public int PreparedBy { get; set; }
        public DateTime PrepareDate { get; set; }
        public int? StatusID { get; set; }
        public decimal? ExDtyRate { get; set; }
        public int InvoiceType { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? CurrencyRate { get; set; }
        public decimal? AdvAdjusted { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string LcAcceptenceNo { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public List<APM_Invoice_DetailDTM> APM_Invoice_Detail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<APM_Invoice_MainDTM, APM_Invoice_Main>();
        }
    }
}
