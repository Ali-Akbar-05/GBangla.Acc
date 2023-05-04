using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.Update;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries;
using Application.Contracts.GBAcc.Setups.CBMPrintedChequeStatus.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Business.PrintedChequesStatus.PrintedStatusSet;
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
    public class PrintedChequesStatusController : BaseController
    {
        private readonly IDropDownService dropDownService;
        private readonly ICurrentUserService currentUserService;

        public PrintedChequesStatusController(IDropDownService _dropDownService,ICurrentUserService _currentUserService)
        {
            dropDownService = _dropDownService;
            currentUserService = _currentUserService;
        }
        public async Task<IActionResult> PrintedStatusSet()
        {
            var model = new PrintedChequesStatusVM();
            model.DDLBank = dropDownService.RenderDDL( await Mediator.Send(new DDLGetCBMBankListQuery() { CompanyID=currentUserService.CompanyID}),true);
            model.DDLAccountNumber = dropDownService.DefaultDDL();
            model.DDLStatus = dropDownService.RenderDDL(await Mediator.Send(new DDLGetCBMPrintedChequeStatusQuery()), true);
            model.DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.ClearingDate = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> GetBankAccountNumberByBankID(int bankID)
        {
            var result = await Mediator.Send(new GetBankAccountNumberByBankIDQuery() { BankID = bankID });
       
            return Json(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CBMPrintedChequeUpdate(List<CBM_PrintedChequeDTM> cBMPrintedChequeDTM)
        {
            var result = await Mediator.Send(new CBMPrintedChequeUpdateCommand() { CBM_PrintedCheque = cBMPrintedChequeDTM });
            return Json(result);
        }
        //
        [HttpPost]
        public async Task<IActionResult> GetPrintedCheque(PrintedChequesRequestModel reqModel)
        {
          //  reqModel.AccountID = 32621;
          //  reqModel.DateFrom = "8 july 2010";
            var result = await Mediator.Send(new CBMPrintedChequesQuery() { ReqModel = reqModel });
            return Json(result);
        
        }
    }
}
