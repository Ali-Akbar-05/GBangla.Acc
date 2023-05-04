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
    public class DDLDiscountAccountsListQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLDiscountAccountsListQueryHandler : IRequestHandler<DDLDiscountAccountsListQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;
        private readonly IGeneralConfigurationService _generalConfigurationService;
        public DDLDiscountAccountsListQueryHandler(IBasicCOAService basicCOAService, IGeneralConfigurationService generalConfigurationService)
        {
            _basicCOAService = basicCOAService;
            _generalConfigurationService = generalConfigurationService;
        }
        public async Task<List<SelectListItem>> Handle(DDLDiscountAccountsListQuery request, CancellationToken cancellationToken)
        {
            var accountItemList = await _generalConfigurationService.GetDefaultAccountID(GeneralConfigurationParameter.DiscountAccount, request.CompanyID, 0, string.Empty, cancellationToken);
            return await _basicCOAService.DDLAccountItemList(accountItemList, request.CompanyID, request.Predict, cancellationToken);
        }
    }
}
