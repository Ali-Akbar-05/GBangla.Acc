using Application.Interfaces.Services;
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
    public class CommonController : BaseController
    {
        private readonly IDropDownService dropDownService;

        public CommonController(IDropDownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public  IActionResult DDLGetNumber()
        {
            var result = dropDownService.DDLNumberDuration(10, 75);
            return Json(result);
        }
    }
}
