using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.Vouchers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.AccReports.GeneralLedgerReport.GeneralLedgerVoucher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.AccReports.Controllers
{
    [Area("AccReports")]
    [Route("AccReports/[controller]/[action]")]
    public class GeneralLedgerReportController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropDownService dropDownService;

        public GeneralLedgerReportController(ICurrentUserService _currentUserService, IDropDownService _dropDownService)
        {
            currentUserService = _currentUserService;
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> GeneralLedgerVoucher()
        {
            var date = DateTime.Today;
            var model = new GeneralLedgerVM();
            model.DDLVoucherType = dropDownService.RenderDDL(DDLGetVoucheType(), true);
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLVoucherNumber = dropDownService.RenderDDL(await Mediator.Send(new GetDateWiseVoucherNumberQuery() { CompanyID = currentUserService.CompanyID, BusinessID = currentUserService.BusinessID, DateFrom = date, DateTo = date }), true);
            return View(model);
        }
        public List<SelectListItem> DDLGetVoucheType()
        {
            var listOfVoucherType = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Journal Voucher",Value="3"},
                new SelectListItem(){Text="Asset Transfer Voucher",Value="20"},
                new SelectListItem(){Text="Goods Reciept Voucher", Value="4"},
                new SelectListItem(){Text="Return From Knitter",Value="19"},
                new SelectListItem(){Text="Consumption Voucher",Value="9"},
                new SelectListItem(){Text="Stock Transfer Voucher",Value="12"},
                new SelectListItem(){Text="Export Sales Voucher",Value="6"},
                new SelectListItem(){Text="Local Sales Voucher",Value="5"},
                new SelectListItem(){Text="Utility Expenditure Voucher",Value="11"},
                new SelectListItem(){Text="Internal Bill For Costing",Value="16"},
                new SelectListItem(){Text="Export Financeing Voucher",Value="30"},
                new SelectListItem(){Text="Export Realization Voucher",Value="31"},
            };
            return listOfVoucherType;

        }
    }
}
