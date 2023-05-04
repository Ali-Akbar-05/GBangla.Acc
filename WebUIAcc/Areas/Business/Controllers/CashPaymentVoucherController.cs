using Application.Common.Interfaces;
using Application.Interfaces.Services;
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
    public class CashPaymentVoucherController : BaseController
    {
        private readonly IDropDownService _dropDownService;

        private readonly ICurrentUserService _currentUserService;
        public CashPaymentVoucherController(IDropDownService dropDownService, ICurrentUserService currentUserService)
        {
            _dropDownService = dropDownService;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
