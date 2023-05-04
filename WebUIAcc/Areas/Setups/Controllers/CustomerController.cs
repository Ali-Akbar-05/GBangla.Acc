using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.Customers.Commands.Create;
using Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Customers.Commands.Update;
using Application.Contracts.GBAcc.Setups.Customers.Queries;
using Application.ViewModel.GBAcc.Setups.Customers.Create;
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
    public class CustomerController : BaseController
    {
        private readonly IMapper mapper;

        public CustomerController(IMapper _mapper)
        {
            mapper = _mapper;
        }   
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new CustomerVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> CustomerCreate(CustomerDTM customerDTM)
        {
            var result = await Mediator.Send(new CustomerCreateCommand() { CustomerDTM = customerDTM });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerUpdate(CustomerDTM customerDTM)
        {
            var result = await Mediator.Send(new CustomerUpdateCommand() { CustomerDTM = customerDTM });
            return Json(result);
        }
       

        public async Task<IActionResult> Edit(int customerID)
        {
            var customerDtm = await Mediator.Send(new GetCustomerByCustomerIDQuery() { CustomerID = customerID });
            var vModel = mapper.Map<CustomerDTM, CustomerVM>(customerDtm);

            return View("Create", vModel);
        }

        public async Task<IActionResult> GetCustomerList(DataSourceLoadOptions loadOptions)
        {
            var data = await Mediator.Send(new GetCustomerListListQuery());
            loadOptions.PrimaryKey = new[] { "CustomerID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
    }
}
