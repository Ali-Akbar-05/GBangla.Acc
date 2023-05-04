using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.Create;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.Update;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries;
using Application.Contracts.GBAcc.Setups.CompanyInfos.Commands.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Setups.Controllers
{
    [Area("Setups")]
    [Route("Setups/[controller]/[action]")]
    public class CBMBankController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public CBMBankController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new CBM_BankVM();
            model.DDLCompanyList = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCompanyInfoQuery()),true);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BankCreate(CBM_BankDTM bankDTM)
        {
            var result = await Mediator.Send(new CBM_BankCreateCommand() { CBM_Bank = bankDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BankUpdate(CBM_BankDTM bankDTM)
        {
            var result = await Mediator.Send(new CBM_BankUpdateCommand() { CBMBankDTM = bankDTM });
            return Json(result);
        }
        public async Task<IActionResult> GetCBMBankList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetCBMBankListQuery());
            loadOptions.PrimaryKey = new[] { "BankID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData =  DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        //
        [HttpDelete]
        public async Task<IActionResult> BankDataDelete(int bankkID)
        {
            var result = await Mediator.Send(new CBM_BankRemovedCommand() { BankID = bankkID });
            return Json(result);
        }

    }
}
