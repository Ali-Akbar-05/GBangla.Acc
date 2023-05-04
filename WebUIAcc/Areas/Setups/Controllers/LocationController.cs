using Application.Contracts.GBAcc.Setups.Locations.Commands.Create;
using Application.Contracts.GBAcc.Setups.Locations.Commands.DataTransferModel;
using Application.ViewModel.GBAcc.Setups;
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
    public class LocationController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            var model = new LocationVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>LocationCreate(LocationDTM locationDTM)
        {
            var result = await Mediator.Send(new LocationCreateCommand() { locationDTM = locationDTM });
            return Json(result);
        }
    }
}
