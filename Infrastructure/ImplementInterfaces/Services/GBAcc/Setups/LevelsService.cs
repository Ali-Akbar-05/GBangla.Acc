using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class LevelsService : ILevelsService
    {
        private readonly ILevelsRepository _levelRepository;
        public LevelsService(ILevelsRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        public async Task<List<SelectListItem>> DDLLevels(CancellationToken cancellationToken)
        {
            return await _levelRepository.DDLLevels(cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLLevelsChartOfAccounts(int[] ignoreLevel, CancellationToken cancellationToken)
        {
            return await _levelRepository.DDLLevelsChartOfAccounts(ignoreLevel,cancellationToken);
        }
    }
}
