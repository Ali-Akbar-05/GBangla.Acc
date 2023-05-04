using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.vw_CustomerWiseIssue.Queries;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.Currences.Queries;
using Application.Contracts.GBAcc.Setups.Customers.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.Business.ChallanInvoiceMap.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUIAcc.Controllers;

namespace WebUIAcc.Areas.Business.Controllers
{
    [Area("Business")]
    [Route("Business/[controller]/[action]")]
    public class ChallanInvoiceMapController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropDownService dropDownService;

        public ChallanInvoiceMapController(ICurrentUserService _currentUserService, IDropDownService _dropDownService)
        {
            currentUserService = _currentUserService;
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new ChallanInvoiceMapViewModel();
            var CompanyID = currentUserService.CompanyID;
            //// var businessID = currentUserService.BusinessID;
            model.DDLLocation = dropDownService.RenderDDL(await Mediator.Send(new DDLAccLocationQueries() { ParentID = CompanyID, CompanyID = CompanyID }), true);
            model.DDLCurrency = await Mediator.Send(new DDLCurrencyQuery());
            model.DDLCustomer = dropDownService.RenderDDL(await Mediator.Send(new GetDDLCustomersQuery() {}), true);
            model.DDLPaymentMode = new List<SelectListItem>() { new SelectListItem() { Text = "Bank", Value = "Cheque" }, new SelectListItem() { Text = "Cash", Value = "Cash" } };
            model.DateFrom = DateTime.Now.AddYears(-1).ToString("dd-MMM-yyyy");//.AddMonths(7)
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> GetIssueNumber(int customerID, DateTime dateFrom, DateTime dateTo, string Predict)
        {            
            var poNumber = await Mediator.Send(new GetDDLCustomerWiseIssueQuery() { CustomerID = customerID, DateFrom = dateFrom, DateTo = dateTo, Predict = Predict });
            return Json(poNumber);
        }
    }
}
