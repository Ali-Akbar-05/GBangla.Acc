using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Interfaces.Services;
using Application.ViewModel.GBAcc.AccReports.ChartOfAccounts.ItemAccountSearch;

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
    public class ChartOfAccountsController : BaseController
    {
        private readonly IDropDownService _dropDownService;
        private readonly ICurrentUserService _currentUserService;
        public ChartOfAccountsController(IDropDownService dropDownService, ICurrentUserService currentUserService)
        {
            _dropDownService = dropDownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> ItemAccountSearch()
        {
            var model = new ItemAccountSearchVM();

            model.DDLAccCategory = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCategoryQueries() { CompanyID = _currentUserService.CompanyID }), true);
            model.DDLAccSubCategory = _dropDownService.DefaultDDL();
            model.DDLAccBroadGroup = _dropDownService.DefaultDDL();
            model.DDLAccNarroGroup = _dropDownService.DefaultDDL();
            model.DDLAccIdentification = _dropDownService.DefaultDDL();
            model.DDLAccItem = _dropDownService.DefaultDDL();
            var currentMonth = DateTime.Now.Month;
            if (currentMonth>6)
            {
                model.GLStartDate = new DateTime(DateTime.Now.Year, 7, 1).ToString("dd-MMM-yyyy");
                model.GLEndDate = new DateTime(DateTime.Now.AddYears(1).Year, 6, 1).ToString("dd-MMM-yyyy");
            }
            else
            {
                model.GLStartDate = new DateTime(DateTime.Now.AddYears(-1).Year, 7, 1).ToString("dd-MMM-yyyy");
                model.GLEndDate = new DateTime(DateTime.Now.Year, 6, 1).ToString("dd-MMM-yyyy");
            }
            model.DDLReportType = new List<SelectListItem>()
            {
                new SelectListItem(){Value="1",Text="General Ledger"},
                new SelectListItem(){Value="",Text="APM Ledger"},
                new SelectListItem(){Value="",Text="Ageing Report"},
                new SelectListItem(){Value="",Text="APM Ledger with OB"},
            };
            return View(model);
        }


        public async Task<IActionResult> GetAccountLedgerReportPage(string fromDate, string toDate, int accountID,  string ReportFormat, string CostCenter=null)
        {
            var companyID = _currentUserService.CompanyID;
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FromDate", fromDate);
            parameters.Add("ToDate", toDate);
            parameters.Add("AccountID", accountID);
            parameters.Add("CompanyID", companyID);
            parameters.Add("CostCenterList", CostCenter);
            int connectionString = ServerConnectionString.GBAccConnection;
            string reportName = "Account_Ledger_Report";
           
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString, "GBAccReport");


        }
    }
}
