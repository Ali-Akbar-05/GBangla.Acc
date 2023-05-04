using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.Create;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.Update;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries;
using Application.ViewModel.GBAcc.Setups.CBMAcountType.CreateAccountType;
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
    public class CBMAcountTypeController : BaseController
    {
        public IActionResult CreateAccountType()
        {
            var model = new AccountTypeVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAccountType(CBM_AcountTypeDTM cBMAcountTypeDTM)
        {
            var result = await Mediator.Send(new CBMAcountTypeCreateCommand() { CBM_AcountType = cBMAcountTypeDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccountType(CBM_AcountTypeDTM cBMAcountTypeDTM)
        {
            var result = await Mediator.Send(new CBMAcountTypeUpdateCommand() { CBM_AcountType = cBMAcountTypeDTM });
            return Json(result);
        }
        //

        public async Task<IActionResult> GetAccountType(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetAccountTypeQuery());
            loadOptions.PrimaryKey = new[] { "AccountTypeID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
    }
}
