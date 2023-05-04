using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GBAcc.Setups;
using Application.ViewModel.GBAcc.Setups.ViewComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAcc.ViewComponents
{
    public class ChartOfAccountsViewComponent: ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropDownService dropDownService;
        private readonly ICurrentUserService currentUserService;
        private readonly IBasicCOAService basicCOAService;

        public ChartOfAccountsViewComponent(IMediator _mediator,IDropDownService _dropDownService, ICurrentUserService _currentUserService,
            IBasicCOAService _basicCOAService)
        {
            mediator = _mediator;
            dropDownService = _dropDownService;
            currentUserService = _currentUserService;
            basicCOAService = _basicCOAService;
        }
        public async Task<IViewComponentResult> InvokeAsync(ChartOfAccountRequestVCM requestModel)
        {
            var model = new ChartOfAccountVM();
            if (requestModel.ItemID>0)
            {
                var obj = await mediator.Send(new GetChartOfAccountByItemIDQuery() { AccID = requestModel.ItemID });
                model.DDLAccIdentification = await mediator.Send(new DDLAccIdentificationQueries() { ParentID = obj.NarrowGroupID.Value });
                model.DDLAccNarroGroup = await mediator.Send(new DDLAccNarrowGroupQueries() {ParentID=obj.BroadGroupID.Value });
                model.DDLAccBroadGroup = await mediator.Send(new DDLAccBroadGroupQueries() {ParentID=obj.SubCategoryID.Value }); 
                model.DDLAccSubCategory = await mediator.Send(new DDLAccSubCategoryQueries() {ParentID=obj.CategoryID });
                model.DDLAccCategory = dropDownService.RenderDDL(await mediator.Send(new DDLAccCategoryQueries() { CompanyID = currentUserService.CompanyID }), true);
                model.AccCategoryID = obj.CategoryID;
                model.SubCategoryID = obj.SubCategoryID.Value;
                model.BroadGroupID = obj.BroadGroupID.Value;
                model.NarrowGroupID = obj.NarrowGroupID.Value;
                model.IdentificationID = obj.IdentificationID.Value;
               
            }
            else
            {
                model.DDLAccCategory = dropDownService.RenderDDL(await mediator.Send(new DDLAccCategoryQueries() { CompanyID = currentUserService.CompanyID }), true);
                model.DDLAccSubCategory = dropDownService.DefaultDDL();
                model.DDLAccBroadGroup = dropDownService.DefaultDDL();
                model.DDLAccNarroGroup = dropDownService.DefaultDDL();
                model.DDLAccIdentification = dropDownService.DefaultDDL();
                model.SerialNo = requestModel.Serial;
            }
           
           
            return View("ChartOfAccountsVC", model);
        }
    }
}
