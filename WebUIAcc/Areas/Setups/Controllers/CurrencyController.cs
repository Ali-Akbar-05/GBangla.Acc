using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.Currences.Commands.Create;
using Application.Contracts.GBAcc.Setups.Currences.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Currences.Commands.Update;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
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
    public class CurrencyController : BaseController
    {
        public IActionResult Create()
        {
            var model = new CurrencyVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CurrencyCreate(CurrencyDTM currencyDTM)
        {
            var result = await Mediator.Send(new CurrencyCreateCommand() { CurrencyDTM = currencyDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CurrencyUpdate(CurrencyDTM currencyDTM)
        {
            var result = await Mediator.Send(new CurrencyUpdateCommand() { CurrencyDTM = currencyDTM });
            return Json(result);
        }
        public async Task<IActionResult> GetCurrencyList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetCurrencyListQuery());
            loadOptions.PrimaryKey = new[] { "CurrencyID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        //
        [HttpDelete]
        public async Task<IActionResult> CurrencyDataDelete(int currencyID)
        {
            var result = await Mediator.Send(new CurrencyRemoveCommand() { CurrencyID = currencyID });
            return Json(result);
        }
    }
}
