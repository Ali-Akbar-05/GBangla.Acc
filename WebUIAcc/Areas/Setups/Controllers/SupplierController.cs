using Application.Common.CommonModels;
using Application.Common.DevExtremeModelBinds;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.Create;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.Update;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Setups.Suppliers.Create;
using AutoMapper;
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
    public class SupplierController : BaseController
    {
        private readonly IDropDownService dropDownService;
        private readonly ICurrentUserService currentUserService;
        private readonly IMapper mapper;

        public SupplierController(IDropDownService _dropDownService, ICurrentUserService _currentUserService,IMapper _mapper)
        {
            dropDownService = _dropDownService;
            currentUserService = _currentUserService;
            mapper = _mapper;
        }
        public  IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new SupplierVM();
            return View(model);
        }
        public async Task<IActionResult> Edit(int supplierID)
        {
            var supplierDtm = await Mediator.Send(new GetSupplierBySupplierIDQuery() {SupplierID= supplierID });
            var vModel = mapper.Map<SupplierDTM, SupplierVM>(supplierDtm);
           
            return View("Create", vModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierCreate(SupplierDTM supplierDTM)
        {
            var result = await Mediator.Send(new SupplierCreateCommand() { SupplierDTM = supplierDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierUpdate(SupplierDTM supplierDTM)
        {
            var result = await Mediator.Send(new SupplierUpdateCommand() { SupplierDTM = supplierDTM });
            return Json(result);
        }

        public async Task<IActionResult> GetSupplierList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetSupplierListQuery() { loadOptions = loadOptions }) ;
            return Json(data);
        }
    }
}
