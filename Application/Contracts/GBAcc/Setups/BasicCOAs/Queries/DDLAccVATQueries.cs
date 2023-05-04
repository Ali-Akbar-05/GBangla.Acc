using Application.Common.Utilities;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries
{
    public class DDLAccVATQueries : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLAccVATQueriesHandler : IRequestHandler<DDLAccVATQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;
        private readonly IGeneralConfigurationService _generalConfigurationService;

        public DDLAccVATQueriesHandler(IBasicCOAService basicCOAService, IGeneralConfigurationService generalConfigurationService)
        {
            _basicCOAService = basicCOAService;
            _generalConfigurationService = generalConfigurationService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccVATQueries request, CancellationToken cancellationToken)
        {
            var accountItemList = await _generalConfigurationService.GetDefaultAccountID(GeneralConfigurationParameter.ItaxIdentification, request.CompanyID, 0, string.Empty, cancellationToken);
            return await _basicCOAService.DDLAccountItemList(accountItemList, request.CompanyID,request.Predict, cancellationToken);
        }
    }
}
