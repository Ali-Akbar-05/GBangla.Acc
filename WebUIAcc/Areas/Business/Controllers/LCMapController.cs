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
    public class LCMapController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
