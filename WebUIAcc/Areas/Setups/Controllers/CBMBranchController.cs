using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.Create;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.Update;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups;
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
    public class CBMBranchController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public CBMBranchController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new CBM_BranchVM();
            model.DDLBankList = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCBMBankListQuery()), true);
            return View(model);
        }
        //CBM_BranchCreateCommand

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BranchCreate(CBM_BranchDTM branchDTM)
        {
            var result = await Mediator.Send(new CBM_BranchCreateCommand() { CBM_BranchDTM = branchDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BranchUpdate(CBM_BranchDTM branchDTM)
        {
            var result = await Mediator.Send(new CBM_BranchUpdateCommand() { CBM_BranchDTM = branchDTM });
            return Json(result);
        }
        public async Task<IActionResult> GetCBMBranchList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetCBMBranchListQuery());
            loadOptions.PrimaryKey = new[] { "BranchID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        //
        [HttpDelete]
        public async Task<IActionResult> BranchDataDelete(int branchID)
        {
            var result = await Mediator.Send(new CBM_BranchRemoveCommand() { BranchID = branchID });
            return Json(result);
        }
    }
}
