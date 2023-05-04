using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMAdvancePaymentRFP_Relate.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Entities.GBAcc.Business;
using Infrastructure.ImplementInterfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class CBMAdvancePaymentRepository : GenericRepository<CBMAdvancePayment>, ICBMAdvancePaymentRepository
    {
        private readonly GBAccDbContext _dbCon;

        public CBMAdvancePaymentRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<CBMAdvancePaymentRFP_RelateDTM>> GetCBMAdvancePaymentRFP_Relate(List<long> VoucherID, List<long> InvoiceID)
        {

            var _AdvQuery = from adv in _dbCon.CBMAdvancePayment
                            where VoucherID.Contains(adv.VoucherID)
                            select adv;

            var query = from rfpDet in _dbCon.CBM_RFP_Detail
                        join rfp in _dbCon.CBM_RFP on rfpDet.RFPID equals rfp.RFPID
                        join advPay in _AdvQuery on rfp.SupplierID equals advPay.AccountID
                        where InvoiceID.Contains(rfpDet.InvoiceID)
                        select new CBMAdvancePaymentRFP_RelateDTM
                        {
                            AdvancePaymentID = advPay.ID,
                            InvoiceID = rfpDet.InvoiceID,
                            RFPID = rfpDet.RFPID,
                            VoucherID = advPay.VoucherID

                        };
            return await query.ToListAsync();
        }

        public async Task<RResult> SaveAdvancePayment(List<CBMAdvancePayment> model)
        {
            RResult result = new RResult();
            _dbCon.CBMAdvancePayment.AddRange(model);
            await _dbCon.SaveChangesAsync();
            result.result = 1;
            return result;

        }
    }


}
