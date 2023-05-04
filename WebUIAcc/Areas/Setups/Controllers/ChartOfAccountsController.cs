using Application.Common.DevExtremeModelBinds;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.Create;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.Update;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Setups.Levels.Queries;
using Application.Interfaces.Services;

using Application.ViewModel.GBAcc.Setups.ChartOfAccounts.CreateActivityCenter;
using Application.ViewModel.GBAcc.Setups.ChartOfAccounts.CreateCostCenter;
using Application.ViewModel.GBAcc.Setups.ChartOfAccounts.Index;

using DevExtreme.AspNet.Data;
using Domain.Enums;
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
    public class ChartOfAccountsController : BaseController
    {
        private readonly IDropDownService _dropDownService;
        private readonly ICurrentUserService _currentUserService;
        public ChartOfAccountsController(IDropDownService dropDownService, ICurrentUserService currentUserService)
        {
            _dropDownService = dropDownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            ChartOfAccIndexVM model = new ChartOfAccIndexVM();
            model.DDLAccLevel = _dropDownService.RenderDDL(await Mediator.Send(new DDLLevelsChartOfAccountsQuery() {ignoreLevel=new int[]{4} }), true);
            model.DDLAccCategory = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCategoryQueries() { CompanyID = _currentUserService.CompanyID }), true);
            model.DDLAccSubCategory = _dropDownService.DefaultDDL();
            model.DDLAccBroadGroup = _dropDownService.DefaultDDL();
            model.DDLAccNarroGroup = _dropDownService.DefaultDDL();
            model.DDLAccIdentification = _dropDownService.DefaultDDL();
            
            return View(model);
        }
        public async Task<IActionResult> CreateCostCenter()
        {
            var model = new CostCenterVM();
            model.LevelID= (int)enum_AccLevels.CostCenter;
            model.DDLBusiness = _dropDownService.RenderDDL(await Mediator.Send(new DDLGetAccBusinessQuery() { ParentID = _currentUserService.CompanyID,LevelID= (int)enum_AccLevels.Business, CompanyID = _currentUserService.CompanyID }), true);
            
            return View(model);
        }
        public async Task<IActionResult> CreateActivityCenter()
        {
            var model = new CreateActivityCenterVM();
            model.LevelID = (int)enum_AccLevels.Activity;
            model.DDLBusiness = _dropDownService.RenderDDL(await Mediator.Send(new DDLGetAccBusinessQuery() { ParentID = _currentUserService.CompanyID, LevelID = (int)enum_AccLevels.Business, CompanyID = _currentUserService.CompanyID }), true);
            model.DDLCostCenter = _dropDownService.DefaultDDL();

            return View(model);
        }
       
        //BasicCoaUpdate
        #region Ajax
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> BasicCoaSave(BasicCOADTM ReqModel)
        { 
            ReqModel.CompanyID = _currentUserService.CompanyID;
            var result = await Mediator.Send(new BasicCOACreateCommand() { BasicCOA = ReqModel });
            return Json(result);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> BasicCoaUpdate(BasicCOADTM ReqModel)
        {
            ReqModel.CompanyID = _currentUserService.CompanyID;
            var result = await Mediator.Send(new BasicCOAUpdateCommand() { BasicCOA = ReqModel });
            return Json(result);
        }

        //
        #endregion


        #region DataList
        public async Task<JsonResult> GetChartOfAccountList(DataSourceLoadOptions loadOptions, ChartOfAccountRequestModel  reqModel)
        {
            reqModel.CompanyID = _currentUserService.CompanyID;
            var returnData = await Mediator.Send(new GetChartOfAccountListQuery() { loadOptions = loadOptions, ReqModel = reqModel });
            return Json(returnData);
        }
        public async Task<IActionResult> GetCostCenterList(DataSourceLoadOptions loadOptions)
        {
            var requestModel = new ChartOfAccountRequestModel();
            requestModel.CompanyID = _currentUserService.CompanyID;
            requestModel.AccLevelID =(int) enum_AccLevels.CostCenter;
            var data = await Mediator.Send(new GetCostCenterListQuery() { RequestModel= requestModel });
            loadOptions.PrimaryKey = new[] { "CostCenterID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        public async Task<IActionResult> GetActivityCenterList(DataSourceLoadOptions loadOptions)
        {
            var requestModel = new ChartOfAccountRequestModel();
            requestModel.CompanyID = _currentUserService.CompanyID;
            requestModel.AccLevelID = (int)enum_AccLevels.Activity;
            var data = await Mediator.Send(new GetActivityCenterListQuery() { RequestModel = requestModel });
            loadOptions.PrimaryKey = new[] { "ActivityID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var finalData = DataSourceLoader.Load(data, loadOptions);
            return Json(finalData);
        }
        //
        #endregion

        #region Drop Down
        public async Task<JsonResult> DDLCategoryWiseSubCategory(int CategoryID)
        {
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccSubCategoryQueries() {ParentID = CategoryID }),true);
            return Json(data);
        }
        public async Task<JsonResult> DDLSubCategoryWiseBroadGroup(int SubCategoryID)
        {
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccBroadGroupQueries() { ParentID = SubCategoryID }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLBroadGroupWiseNarrowGroup(int BroadGroupID,string Predict)
        {
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccNarrowGroupQueries() { ParentID = BroadGroupID,Predict=Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLNarrowGroupWiseIdentification(int NarrowGroupID,string Predict)
        {
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccIdentificationQueries() { ParentID = NarrowGroupID ,Predict= Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLIdentificationWiseItem(int IdentificationID,string Predict)
        {
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccItemQueries() { ParentID = IdentificationID,Predict=Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLSupplier(int[] ParentList , string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLSupplierQueries() { ParentList = ParentList,CompanyID=CompanyID, Predict = Predict }), true);
            return Json(data);
        }

        public async Task<JsonResult> DDLCostCenter(int BusinessID, string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
          //  BusinessID = _currentUserService.BusinessID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccCostCenterQueries() { ParentID = BusinessID, CompanyID= CompanyID, Predict = Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLActivity(int CostCenterID, string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccActivityQueries() { ParentID = CostCenterID, CompanyID = CompanyID, Predict = Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLCOAItem(int[] ParentList, string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccountItemListQuery() { ParentList = ParentList, CompanyID = CompanyID, Predict = Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLCoaVatItem(string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccVATQueries() {  CompanyID = CompanyID, Predict = Predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> DDLCoaITaxItem(string Predict)
        {
            var CompanyID = _currentUserService.CompanyID;
            var data = _dropDownService.RenderDDL(await Mediator.Send(new DDLAccITAXQueries() { CompanyID = CompanyID, Predict = Predict }), true);
            return Json(data);
        }

        #endregion
    }
}
