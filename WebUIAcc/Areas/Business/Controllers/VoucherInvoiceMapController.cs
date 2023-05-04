using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Commands.Create;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries;
using Application.Contracts.GBAcc.Business.POAdvancePayments.Queries;
using Application.Contracts.GBAcc.Business.VoucherGeneralInfos.Queries;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Business.VoucherInvoiceMap.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Business.Controllers
{
    [Area("Business")]
    [Route("Business/[controller]/[action]")]
    public class VoucherInvoiceMapController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropDownService dropDownService;

        public VoucherInvoiceMapController(ICurrentUserService _currentUserService, IDropDownService _dropDownService)
        {
            currentUserService = _currentUserService;
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new VoucherInvoiceMapViewModel();
            var CompanyID = currentUserService.CompanyID;
            // var businessID = currentUserService.BusinessID;
            model.DDLLocation = dropDownService.RenderDDL(await Mediator.Send(new DDLAccLocationQueries() { ParentID = CompanyID, CompanyID = CompanyID }), true);
            model.DDLCurrency = await Mediator.Send(new DDLCurrencyQuery());
            model.DDLChartOfAccount = dropDownService.RenderDDL(await Mediator.Send(new DDLSupplierQueries() { ParentList = new int[] { }, CompanyID = CompanyID }), true);
            model.DDLPaymentMode = new List<SelectListItem>() { new SelectListItem() { Text = "Bank", Value = "Cheque" }, new SelectListItem() { Text = "Cash", Value = "Cash" } };
            model.DateFrom = DateTime.Now.AddYears(-1).ToString("dd-MMM-yyyy");//.AddMonths(7)
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveVoucherInvoiceMap(VoucherInvoiceMapDTM voucherInvoiceMapDTM)
        {
            var result = await Mediator.Send(new VoucherInvoiceMapCreateCommand() { VoucherInvoiceMapDTM = voucherInvoiceMapDTM });
            return Json(result);
        }

        public async Task<IActionResult> GetPONumber(int accountID, DateTime dateFrom, DateTime dateTo, string Predict)
        {
            // accountID = 31931;
            // dateFrom = Convert.ToDateTime("01/07/2019");
            // dateTo = Convert.ToDateTime("01/12/2021");
            var poNumber = await Mediator.Send(new DDLGetPONumberByAccountIDQuery() { AccountID = accountID, DateFrom = dateFrom, DateTo = dateTo, Predict = Predict });
            return Json(poNumber);
        }
        public async Task<IActionResult> GetVendorVoucher(int accountID, DateTime dateFrom, DateTime dateTo, string poNumber)
        {
            //  accountID = 31167;
            //  poNumber = "10941";
            var result = await Mediator.Send(new GetVendorVoucherListQuery() { VendorID = accountID, DateFrom = dateFrom, DateTo = dateTo, PONumber = poNumber });
            return Json(result);
        }
        public async Task<IActionResult> GetAdvancedPO(int supplierID, string poNumber)
        {
            // supplierID = 31167;
            //   poNumber = "10941";
            var result = await Mediator.Send(new GetAdvancedPaymentOfPoQuery() { SupplierID = supplierID, PoNumver = poNumber });
            return Json(result);
        }
        //
    }
}
