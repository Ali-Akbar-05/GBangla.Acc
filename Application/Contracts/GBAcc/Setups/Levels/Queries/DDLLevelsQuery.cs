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
  public  class DDLLevelsQuery :IRequest<List<SelectListItem>>
    {
    }
    public class DDLLevelsQueryHandler : IRequestHandler<DDLLevelsQuery, List<SelectListItem>>
    {
        private readonly ILevelsService _levelsService;
        public DDLLevelsQueryHandler(ILevelsService levelsService)
        {
            _levelsService = levelsService;
        }
        public async Task<List<SelectListItem>> Handle(DDLLevelsQuery request, CancellationToken cancellationToken)
        {
            return await _levelsService.DDLLevels(cancellationToken);
        }
    }
}
