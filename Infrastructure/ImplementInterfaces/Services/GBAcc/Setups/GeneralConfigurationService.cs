using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class GeneralConfigurationService : IGeneralConfigurationService
    {
        private readonly IGeneralConfigurationRepository generalConfigurationRepository;

        public GeneralConfigurationService(IGeneralConfigurationRepository _generalConfigurationRepository)
        {
            generalConfigurationRepository = _generalConfigurationRepository;
        }
        public async Task<int> GetDefaultAccountID(string parameter, int businessID, string pageName = null)
        {
            return await generalConfigurationRepository.GetDefaultAccountID(parameter,  businessID,pageName);
        }

        public async Task<int[]> GetDefaultAccountID(string parameter, int CompanyID, int businessID, string pageName = null, CancellationToken cancellationToken = default)
        {
            return await generalConfigurationRepository.GetDefaultAccountID(parameter,CompanyID,businessID,pageName,cancellationToken);
        }
    }
}
