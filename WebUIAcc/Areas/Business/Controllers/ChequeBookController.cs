
using Application.Common.CommonModels;
using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.Create;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMCheques.Queries;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries;
using Application.Contracts.GBAcc.Setups.Signatores.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups.ChequeBook.Create;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Business.Controllers
{
    [Area("Business")]
    [Route("Business/[controller]/[action]")]
    public class ChequeBookController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public ChequeBookController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        #region Action
        public async Task<IActionResult> Create()
        {
            var model = new ChequeBookVM();
            model.DDLBank = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCBMBankListQuery()), true);
            model.DDLIdentification = dropDownService.DefaultDDL();
            model.DDLBranch = dropDownService.DefaultDDL();
            model.DDLAccountNumber = dropDownService.DefaultDDL();
            model.DDLCurrency = dropDownService.DefaultDDL();
            model.DDLSignatory = await Mediator.Send(new DDLGetSignatoryListQuery());
            model.DDLAccountType =  new List<SelectListItem>() { new SelectListItem() { Text = "Cash with Banks", Value = "Cash with Banks" } };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChequeBook(List<CBMChequeBookDTM> cBMChequeBook)
        {
            var result = await Mediator.Send(new CBMChequeBookCreateCommand() { CBMChequeBook = cBMChequeBook });
            return Json(result);
        }

        public async Task<IActionResult> Index()
        {
            var model = new ChequeBookVM();
            model.DDLBank = await Mediator.Send(new DDLGetCBMBankListQuery());
            model.DDLIdentification = dropDownService.DefaultDDL();
            model.DDLBranch = dropDownService.DefaultDDL();
            model.DDLAccountNumber = dropDownService.DefaultDDL();
            model.DDLCurrency = dropDownService.DefaultDDL();
            model.DDLStatus = dropDownService.RenderDDL( new List<SelectListItem>() { new SelectListItem() { Text = "Used", Value = "Used" }, new SelectListItem() { Text = "Unused", Value = "Unused" } },true);
            return View(model);
        }
        #endregion Action

        #region Json
        public async Task<IActionResult>GetIdentificationByBranchID(int branchID)
        {
            var result = dropDownService.RenderDDL( await Mediator.Send(new DDLGetIdentificationByBranchIDQuery() { BranchID = branchID }),true);
            return Json(result);
        }
        public async Task<IActionResult> GetAccountNumberByAccountTypeID(int typeID)
        {
            var result = dropDownService.RenderDDL(await Mediator.Send(new DDLGetAccountNumberByTypeIDQuery() { AccountTypeID = typeID }), true);
            return Json(result);
        }
        public async Task<IActionResult> GetCurrencyByAccountID(int accountID)
        {
            var result = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCurrencyByAccountIDQuery() { AccountID = accountID }), true);
            return Json(result);
        }

        public async Task<JsonResult> GetAvailableCheque(int accountID)
        {
            RResult rr = new RResult();
            rr.data = await Mediator.Send(new GetAvailableChequeQuery() {AccountID = accountID });
            rr.result = 1;
            return Json(rr);
        }

        public async Task<IActionResult> GetChequeBookList(DataSourceLoadOptions loadOptions, ChequeBookRequestModel requestModel)
        {
            var data = await Mediator.Send(new GetChequeBookListQuery() { ChequeBook = requestModel });
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        public async Task<IActionResult> GetChequeList(int chequeBookID)
        {
            var result = await Mediator.Send(new GetChequeListQuery() { ChequeBookID = chequeBookID });
            return Json(result);
        }
        //
        #endregion Json
    }
}
