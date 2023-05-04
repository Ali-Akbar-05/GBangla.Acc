using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMAdvancePaymentRFP_Relate.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
  public  interface ICBMAdvancePaymentRepository:IGenericRepository<CBMAdvancePayment>
    {
        Task<List<CBMAdvancePaymentRFP_RelateDTM>> GetCBMAdvancePaymentRFP_Relate(List<long> VoucherID,List<long>InvoiceID);
        Task<RResult> SaveAdvancePayment(List<CBMAdvancePayment> model);
    }
}
