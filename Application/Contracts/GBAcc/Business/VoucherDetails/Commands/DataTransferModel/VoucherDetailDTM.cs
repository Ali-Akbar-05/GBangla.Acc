using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.VoucherDetails.Commands.DataTransferModel
{
 public   class VoucherDetailDTM:IMapFrom<VoucherDetail>
    {
        public long VDetailsID { get; set; }
        public long VoucherID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int? LocationID { get; set; }
        public int? Costcenter { get; set; }
        public int? Activity { get; set; }
        public int? VIndex { get; set; }
        public int Status { get; set; }
        public int? EntryType { get; set; }
        /// <summary>
        /// Debit=> Dr
        /// Credit=> Cr
        /// </summary>
        public string TransactionType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VoucherDetailDTM, VoucherDetail>();
        }
    }
}
