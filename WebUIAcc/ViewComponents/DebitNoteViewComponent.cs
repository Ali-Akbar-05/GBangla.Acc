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
    public class DebitNoteViewComponent:ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropDownService dropDownService;
        private readonly ICurrentUserService currentUserService;
        private readonly IBasicCOAService basicCOAService;

        public DebitNoteViewComponent(IMediator _mediator, IDropDownService _dropDownService, ICurrentUserService _currentUserService,
            IBasicCOAService _basicCOAService)
        {
            mediator = _mediator;
            dropDownService = _dropDownService;
            currentUserService = _currentUserService;
            basicCOAService = _basicCOAService;
        }
        public async Task<IViewComponentResult> InvokeAsync(DebitNoteRequestVCM requestModel)
        {
            var model = new DebitNoteVCM();
            model.DDLAccCategory = dropDownService.RenderDDL(await mediator.Send(new DDLAccCategoryQueries() { CompanyID = currentUserService.CompanyID }), true);
            model.DDLAccSubCategory = dropDownService.DefaultDDL();
            model.DDLAccBroadGroup = dropDownService.DefaultDDL();
            model.DDLAccNarroGroup = dropDownService.DefaultDDL();
            model.DDLAccIdentification = dropDownService.DefaultDDL();
            model.DDLAccItem = dropDownService.DefaultDDL();
            model.SerialNo = requestModel.Serial;
            return View("DebitNoteVC", model);
        }
    }
}
