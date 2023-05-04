using Application.Common.DevExtremeModelBinds;

using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.Create;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups.CBMBankAccount.Create;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Setups.Controllers
{
    [Area("Setups")]
    [Route("Setups/[controller]/[action]")]
    public class CBMBankAccountController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public CBMBankAccountController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new CBMBankAccountVM();
            model.DDLAccountType = dropDownService.RenderDDL(await Mediator.Send(new DDLGetAccountTypeQuery()), true);
            model.DDLBank = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCBMBankListQuery()), true);
            model.DDLCurrency = await Mediator.Send(new DDLCurrencyQuery());
            model.DDLBranch = dropDownService.DefaultDDL();

            return View(model);
        }
        public async Task<IActionResult> GetBranchListByBankID(int bankID)
        {
            var result = dropDownService.RenderDDL(await Mediator.Send(new DDLGetBranchListByBankIDQuery() { BankID = bankID }),true);
            return Json(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>SaveBankAccount(CBM_BankAccountDTM cBMBankAccount)
        {
            var result = await Mediator.Send(new CBMBankAccountCreateCommand() { CBM_BankAccount = cBMBankAccount });
            return Json(result);
        }
        //public async Task<IActionResult> GetBankAccountList()
        //{
        //    var bankAcountList = await Mediator.Send(new GetBankAccountListQuery());
        //}
        public async Task<IActionResult> GetBankAccountList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetBankAccountListQuery());
            loadOptions.PrimaryKey = new[] { "BAccountID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }

        
    }
}
