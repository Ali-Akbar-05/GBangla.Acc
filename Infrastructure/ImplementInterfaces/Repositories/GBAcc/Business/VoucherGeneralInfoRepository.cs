using Application.Common.CommonModels;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Constants;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class VoucherGeneralInfoRepository : GenericRepository<VoucherGeneralInfo>, IVoucherGeneralInfoRepository
    {
        private GBAccDbContext accDbContext;
        public VoucherGeneralInfoRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> UpdateVoucherGeneral(List<VoucherGeneralInfo> model)
        {
            var result = new RResult();
            try
            {
                 accDbContext.VoucherGeneralInfo.UpdateRange(model);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
            return result;
        }

        public async Task<List<SelectListItem>> DDlGetPONumberByAccountID(int accountID, DateTime dateFrom, DateTime dateTo, string Predict, CancellationToken cancellationToken)
        {

            //var status = new List<int> { 1, 5, 10, 15, 95 };
            //var rtnPoNumber = await (from vgi in accDbContext.VoucherGeneralInfo
            //                         join v in accDbContext.Voucher on vgi.VoucherID equals v.VoucherID
            //                         join vd in accDbContext.VoucherDetail on v.VoucherID equals vd.VoucherID
            //                         where (v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo)
            //                         && vgi.ReferenceNo.Length > 0
            //                         && vd.AccountID == accountID
            //                         //&& apmi.InvoiceEffect != 1
            //                         && vgi.LCNumber == null
            //                         && !vgi.ReferenceNo.Contains("RFP")
            //                         && !v.PaymentTerm.Contains("L/C")
            //                         && status.Contains(vd.Status)
            //                         select new SelectListItem()
            //                         {
            //                             Text = vgi.ReferenceNo,
            //                             Value = vgi.ReferenceNo
            //                         }).Distinct().ToListAsync();
            //Embro.usp_APM_PONumbers_GET
            /*
            var status = new List<int> { 1, 5, 10, 15, 95 };
            var rtnPoNumber =  (from vgi in accDbContext.VoucherGeneralInfo
                                     join v in accDbContext.Voucher on vgi.VoucherID equals v.VoucherID
                                     join vd in accDbContext.VoucherDetail on v.VoucherID equals vd.VoucherID
                                     where (v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo)
                                     && vgi.ReferenceNo.Length > 0
                                     && vd.AccountID == accountID
                                     //&& apmi.InvoiceEffect != 1
                                     && vgi.LCNumber == null
                                     && !vgi.ReferenceNo.Contains("RFP")
                                     && !v.PaymentTerm.Contains("L/C")
                                     && status.Contains(vd.Status)
                                     select new 
                                     {
                                         PONumber = vgi.ReferenceNo,
                                         
                                     }).Distinct();

            if (!string.IsNullOrEmpty(Predict))
            {
                rtnPoNumber = rtnPoNumber.Where(b => b.PONumber.Contains(Predict));

            }
              var retnItem = await rtnPoNumber.Select(s => new SelectListItem() { Text = s.PONumber, Value = s.PONumber }).ToListAsync();
            // var poNumber = await rtnPoNumber.Select(s => new SelectListItem() { Text = s.PoNumber, Value = s.PoNumber }).ToListAsync( cancellationToken);
            return  retnItem;
            */

            var poAdvancedList = new List<SelectListItem>();

            await accDbContext.LoadStoredProc("Ajt.USP_APM_GetPONumbers")
                .WithSqlParam("AccountID", accountID)
                .WithSqlParam("DateFrom", dateFrom)
                .WithSqlParam("DateTo", dateTo)
                .WithSqlParam("Predict", Predict)
                .ExecuteStoredProcAsync((handler) =>
                {
                    poAdvancedList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;

                });
            return poAdvancedList;

          
        }
    }
}
