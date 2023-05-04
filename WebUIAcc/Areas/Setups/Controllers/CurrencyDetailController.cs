using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.Create;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.Update;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups.CurrencyDetails.Create;
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
    public class CurrencyDetailController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public CurrencyDetailController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CurrencyDetailVM();
            model.DDLCurrencyList = dropDownService.RenderDDL( await Mediator.Send(new DDLCurrencyQuery()),true);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> CurrencyDetailSave(CurrencyDetailDTM currencyDetailDTM)
        {
            var result = await Mediator.Send(new CurrencyDetailCreateCommand() { CurrencyDetailDTM = currencyDetailDTM });
            return Json(result);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CurrencyDetailUpdate(CurrencyDetailDTM currencyDetailDTM)
        {
            var result = await Mediator.Send(new CurrencyDetailUpdateCommand() { CurrencyDetailDTM = currencyDetailDTM });
            return Json(result);
        }
        public async Task<IActionResult> GetCurrencyDetailList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetAllCurrencyDetailListQuery());
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        
        [HttpDelete]
        public async Task<IActionResult> CurrencyDetailDelete(int Id)
        {
            var result = await Mediator.Send(new CurrencyDetailRemoveCommand() { ID=Id});
            return Json(result);
        }
    }
}
