using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.Vouchers.Queries;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.AccReports.Controllers
{
    [Area("AccReports")]
    [Route("AccReports/[controller]/[action]")]
    public class CommonController : BaseController
    {
        private readonly IDropDownService dropDownService;
        private readonly ICurrentUserService currentUserService;

        public CommonController(IDropDownService _dropDownService, ICurrentUserService _currentUserService)
        {
            dropDownService = _dropDownService;
            currentUserService = _currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetVoucherNumber(DateTime dateFrom, DateTime dateTo, int voucherTypeID)
        {
            var result = dropDownService.RenderDDL(await Mediator.Send(new GetDateWiseVoucherNumberQuery() { CompanyID = currentUserService.CompanyID, BusinessID = currentUserService.BusinessID, DateFrom = dateFrom, DateTo = dateTo, VoucherType = voucherTypeID }), true);
            return Json(result);
        }
        public async Task<IActionResult> GetVoucherListForReportGenerate(int voucherID, int voucherType, DateTime dateFrom, DateTime dateTo)
        {
            var result = await Mediator.Send(new GetVoucherListForReportQuery() { VoucherID = voucherID, VoucherType = voucherType, DateFrom = dateFrom, DateTo = dateTo });
            return Json(result);
        }
    }
}
