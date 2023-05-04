using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface IGeneralConfigurationService
    {
        Task<int> GetDefaultAccountID(string parameter, int businessID, string pageName = null);
        Task<int[]> GetDefaultAccountID(string parameter, int CompanyID, int businessID, string pageName = null, CancellationToken cancellationToken = default);
    }
}
