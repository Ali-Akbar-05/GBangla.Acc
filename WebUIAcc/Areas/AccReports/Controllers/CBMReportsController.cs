using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Business.Vouchers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.AccReports.CBMReports;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.AccReports.Controllers
{
    [Area("AccReports")]
    [Route("AccReports/[controller]/[action]")]
    public class CBMReportsController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropDownService dropDownService;

        public CBMReportsController(ICurrentUserService _currentUserService,IDropDownService _dropDownService)
        {
            currentUserService = _currentUserService;
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> CBMVoucherReport()
        {
            var date = DateTime.Today;
            var model = new CBMReportsVM();
            model.DDLVoucherType = dropDownService.RenderDDL(DDLGetVoucheType(),true);
            model.DateFrom = DateTime.Now.AddDays(-20).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLVoucherNumber = dropDownService.RenderDDL(await Mediator.Send(new GetDateWiseVoucherNumberQuery() { CompanyID = currentUserService.CompanyID, BusinessID = currentUserService.BusinessID, DateFrom = date, DateTo = date }), true);
            return View(model);
        }
        public List<SelectListItem> DDLGetVoucheType()
        {
            var listOfVoucherType = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Bank Payment Voucher",Value="2"},
                new SelectListItem(){Text="Bank Transfer Voucher",Value="23"},
                new SelectListItem(){Text="Bank Receipt Voucher",Value="10"},
                new SelectListItem(){Text="Cash Payment Voucher",Value="1"},
                new SelectListItem(){Text="Cash Receipt Voucher",Value="7"},
                new SelectListItem(){Text="Journal Voucher",Value="3"},
                new SelectListItem(){Text="Bank Credit Advice",Value="14"},
                new SelectListItem(){Text="Bank Debit Advice",Value="15"},
                new SelectListItem(){Text="Request for Payment",Value=""},
                new SelectListItem(){Text="Supplier Invoice Voucher",Value="27"},
                new SelectListItem(){Text="Expense Claim",Value=""},
                new SelectListItem(){Text="LC Voucher",Value="28"},
                new SelectListItem(){Text="Journal Voucher Payment",Value="29"},
                new SelectListItem(){Text="Bank Lc Voucher",Value="33"},
            };
            return listOfVoucherType;

        }
        public async Task<IActionResult> GetVoucherNumber(DateTime dateFrom,DateTime dateTo,int voucherTypeID)
        {
            var result = dropDownService.RenderDDL( await Mediator.Send(new GetDateWiseVoucherNumberQuery() {CompanyID=currentUserService.CompanyID,BusinessID=currentUserService.BusinessID,DateFrom=dateFrom,DateTo=dateTo,VoucherType=voucherTypeID }),true);
            return Json(result);
        }
        public async Task<IActionResult> GetVoucherListForReportGenerate(int voucherID,int voucherType,DateTime dateFrom,DateTime dateTo)
        {
            var result = await Mediator.Send(new GetVoucherListForReportQuery() { VoucherID = voucherID, VoucherType = voucherType, DateFrom = dateFrom, DateTo = dateTo });
            return Json(result);
        }
        //
        public async Task<IActionResult> GetCBMVoucherReportPage(long voucherID, int voucherType,  string ReportFormat)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("VoucherID", voucherID);
            int connectionString = ServerConnectionString.GBAccConnection;
            string reportName = "Test2";
            switch (voucherType)
            {
                case (int)Enum_VoucherType.GRV:
                    reportName = "Goods_Receiving_Voucher_Report";
                    break;
                case (int)Enum_VoucherType.SIV:
                     reportName = "Supplier_Invoice_VoucherReport";
                    break;
                case (int)Enum_VoucherType.LC:
                    reportName = "LC_VoucherReport";
                    break;
                case (int)Enum_VoucherType.BLV:
                    reportName = "Bank_Lc_VoucherReport";
                    break;
                case (int)Enum_VoucherType.BPV:
                    reportName = "BankPaymentVoucherReport";
                    break;
                case (int)Enum_VoucherType.ICV:
                    reportName = "Consumption_Voucher_Report";
                    break;
                case (int)Enum_VoucherType.JV:
                    reportName = "Journal_VoucherReport";
                    break;
                default:
                    reportName = "Test2";
                    break;
            }
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString, "GBAccReport");


        }

    }
}
