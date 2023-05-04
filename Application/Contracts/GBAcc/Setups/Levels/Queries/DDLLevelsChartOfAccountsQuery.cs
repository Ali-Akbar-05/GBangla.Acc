using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Levels.Queries
{
  public  class DDLLevelsChartOfAccountsQuery : IRequest<List<SelectListItem>>
    {
        public int[] ignoreLevel { get; set; } = { 0 };
    }
    public class DDLLevelsChartOfAccountsQueryHandler : IRequestHandler<DDLLevelsChartOfAccountsQuery, List<SelectListItem>>
    {
        private readonly ILevelsService _levelsService;
        public DDLLevelsChartOfAccountsQueryHandler(ILevelsService levelsService)
        {
            _levelsService = levelsService;
        }
        public async Task<List<SelectListItem>> Handle(DDLLevelsChartOfAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _levelsService.DDLLevelsChartOfAccounts(request.ignoreLevel, cancellationToken);
        }
    }
}
