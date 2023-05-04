using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.Create;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.CBMInstrumentTypes.Queries;
using Application.Contracts.GBAcc.Setups.ChequeSignatoryMasters.Queries;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Contracts.GBAcc.Setups.VoucherAmountPaymentTypes.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Business.BankPaymentVoucher.Create;
using Domain.Enums;
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
    public class BankPaymentVoucherController : BaseController
    {
        private readonly IDropDownService _dropDownService;

        private readonly ICurrentUserService _currentUserService;
        public BankPaymentVoucherController(IDropDownService dropDownService, ICurrentUserService currentUserService)
        {
            _dropDownService = dropDownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Create()
        {
            BankPaymentVoucherCreateViewModel model = new BankPaymentVoucherCreateViewModel();
            var companyID = _currentUserService.CompanyID;
            var businessID = _currentUserService.BusinessID;
            model.VoucherDate = DateTime.Now;

            model.DDLLocation = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccLocationQueries() { ParentID = companyID, CompanyID = companyID }), true);
            model.DDLCurrency = await Mediator.Send(new DDLCurrencyQuery());
            model.DDLPaymentType = await Mediator.Send(new DDLVoucherAmountPaymentTypeQuery() {Type= Enum_VoucherAmountPaymentType.PaymentBank.ToString() });
            model.DDLDebitAccount = _dropDownService.DefaultDDL();
            model.DDLDebitCostCenter = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCostCenterQueries() { ParentID = businessID, CompanyID = companyID }), true);
            model.DDLDebitActivity = _dropDownService.DefaultDDL();
            model.DDLCreditAcc = _dropDownService.DefaultDDL();
            model.DDLCreditCostCenter = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCostCenterQueries() { ParentID = businessID, CompanyID = companyID }), true);
            model.DDLCreditActivity = _dropDownService.DefaultDDL();
            model.DDLDiscountAcc = _dropDownService.RenderDDL(await Mediator.Send(new DDLDiscountAccountsListQuery (){ CompanyID=companyID}), false);
            model.DDLInstrumentType = _dropDownService.RenderDDL(await Mediator.Send(new DDLGetCBMInstrumentTypeListQuery()), true);
            model.DDLSignatory = _dropDownService.RenderDDL(await Mediator.Send(new DDLGetChequeSignatoryMasterListQuery() { CompanyID = companyID }), true);
            model.DDLVatAcc = _dropDownService.DefaultDDL();  //_dropDownService.RenderDDL(await Mediator.Send(new DDLAccVATQueries() { CompanyID = companyID }), false);
            model.DDLIncomeTax = _dropDownService.DefaultDDL(); //_dropDownService.RenderDDL(await Mediator.Send(new DDLAccITAXQueries() { CompanyID = companyID }), false);


            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> SaveBankPaymentVoucher(BankVouchersDTM BankVouchers)
        {
            var data = await Mediator.Send(new BankPaymentVoucherCreateCommand (){ BankVouchers = BankVouchers });
            return Json(data);
        }
    }
}
