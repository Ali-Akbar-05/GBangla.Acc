using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.Create;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Business.SupplierInvoiceVoucherCon.Create;
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
    public class SupplierInvoiceVoucherController : BaseController
    {
        public IDropDownService _dropDownService { get; }

        private readonly ICurrentUserService _currentUserService;

        public SupplierInvoiceVoucherController(IDropDownService dropDownService, ICurrentUserService currentUserService)
        {
            _dropDownService = dropDownService;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var dateFormat= StaticConfigs.GetConfig("DateFormat");
            SupplierInvoiceVoucherCreateViewModel model = new SupplierInvoiceVoucherCreateViewModel();
            var CompanyID = _currentUserService.CompanyID;
            var businessID = _currentUserService.BusinessID;
            model.DDLLocation = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccLocationQueries() {ParentID= CompanyID,CompanyID= CompanyID}), true);
            model.DDLCurrency = await Mediator.Send(new DDLCurrencyQuery());
            model.DDLSupplier = _dropDownService.RenderDDL( await Mediator.Send(new DDLSupplierQueries() {ParentList=new int[] { } ,CompanyID=CompanyID}),true);//DDLSupplierQueries GetDDLSupplierListQuery
            model.DDLCreditCostCenter = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCostCenterQueries() {ParentID= businessID,CompanyID=CompanyID }),true);
            model.DDLCreditActivity = _dropDownService.DefaultDDL();// DDLAccountItemListQuery
            model.DDLDebitAccount = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccountItemListQuery() { ParentList = new int[] { }, CompanyID = CompanyID }), true);
            model.VoucherDate = DateTime.Now.ToString(dateFormat);
            model.BillDate = DateTime.Now.ToString(dateFormat);
            model.CurrencyID = 1;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSupplierInvoiceVoucher(VoucherDTM voucherDTM)
        {
            var result = await Mediator.Send(new SupplierInvoiceVoucherCreateCommand() { VoucherDTM = voucherDTM });
            return Json(result);
        }
        public async Task<IActionResult> GetCurrencyExchangeRateByCurrencyIDQuery(int currencyID)
        {
            var result = await Mediator.Send(new GetCurrencyExchangeRateByCurrencyIDQuery() { CurrencyID = currencyID });
            return Json(result);
        }
        //
        public async Task<IActionResult>GetDDLActivityByCostCenter(int parentID, string predict)
        {
            var result = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccActivityQueries() { ParentID=parentID,CompanyID=_currentUserService.CompanyID,Predict= predict }),true);
            return Json(result);
        }
        public async Task<IActionResult> GetAccountList()
        {
           var list=  _dropDownService.RenderDDL(await Mediator.Send(new DDLAccountItemListQuery() { ParentList = new int[] { }, CompanyID = _currentUserService.CompanyID }), true);
            return Json( list);
        }
        public async Task<IActionResult> GetCostCenterList()
        {
            var result = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCostCenterQueries() { ParentID = _currentUserService.BusinessID, CompanyID = _currentUserService.CompanyID }), true);
            return Json(result);
        }
    }
}
