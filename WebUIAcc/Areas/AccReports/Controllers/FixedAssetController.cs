using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.Vouchers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.AccReports.FixedAsset.FixedAssetVoucher;
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
    public class FixedAssetController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropDownService dropDownService;

        public FixedAssetController(ICurrentUserService _currentUserService, IDropDownService _dropDownService)
        {
            currentUserService = _currentUserService;
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> FixedAssetVoucher()
        {
            var date = DateTime.Today;
            var model = new FixedAssetVoucherVM();
            model.DDLVoucherType = dropDownService.RenderDDL(DDLGetVoucheType(), true);
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLVoucherNumber = dropDownService.RenderDDL(await Mediator.Send(new GetDateWiseVoucherNumberQuery() { CompanyID = currentUserService.CompanyID, BusinessID = currentUserService.BusinessID, DateFrom = date, DateTo = date }), true);
            return View();
        }
        public List<SelectListItem> DDLGetVoucheType()
        {
            var listOfVoucherType = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Fixed Asset Voucher",Value="13"},
                new SelectListItem(){Text="Lease Request for Payment",Value=""},
               
            };
            return listOfVoucherType;

        }
    }
}
