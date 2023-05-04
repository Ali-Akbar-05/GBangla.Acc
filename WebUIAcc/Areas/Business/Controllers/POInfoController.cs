using Application.Contracts.GBAcc.Business.POInfo.Queries;
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
    public class POInfoController : BaseController
    {
        public async Task<JsonResult> GetPOForAdvance(int AccountID)
        {
            var billToBillPaymentList = await Mediator.Send(new GetPOForAdvanceQuery() { SupplierID = AccountID});
            return Json(billToBillPaymentList);

        }

    }
}
