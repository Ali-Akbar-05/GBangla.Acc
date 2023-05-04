using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.COATransactions.Queries;
using Application.Contracts.GBAcc.Setups.LedgerBalanceIncomeTaxPercnts.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Business.Controllers
{
    [Area("Business")]
    [Route("Business/[controller]/[action]")]
    public class COATransactionController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        public COATransactionController(ICurrentUserService _currentUserService)
        {
            currentUserService = _currentUserService;
        }
        public async Task<JsonResult> APM_InvoiceForPayment(int AccountID)
        {
            RResult rr = new()
            {
                data = await Mediator.Send(new APM_InvoiceForPaymentQuery() { AccountID = AccountID, BusinessID = currentUserService.BusinessID })
            };
            return Json(rr);
        }
        public async Task<JsonResult> GetAdvanceForAdjustment(int AccountID)
        {
            RResult rr = new()
            {
                data = await Mediator.Send(new AdvanceForAdjustmentQuery() { AccountID = AccountID, BusinessID = currentUserService.BusinessID })
            };
            return Json(rr);
        }
        public async Task<JsonResult> GetLedgerBalance(int AccBalanceType,int AccountID)
        {
            
            RResult rr = new()
            {
                data = await Mediator.Send(new GetLedgerBalanceQuery() { AccBalanceType = AccBalanceType, AccountID = AccountID, FiscalYear = currentUserService.FiscalYear, BusinessID = currentUserService.BusinessID })
            };

            return Json(rr);
        }
        public async Task<JsonResult> GetLedgerBalanceIncomeTax(decimal LedgerAmount)
        {
            RResult rr = new()
            {
                data = await Mediator.Send(new GetLedgerBalanceIncomeTaxPercntQuery() { LedgerAmount = LedgerAmount, CompanyID = currentUserService.CompanyID }),
                result = 1
            };
            return Json(rr);
        }
        
    }
}
