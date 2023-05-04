using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class GeneralConfigurationRepository : GenericRepository<GeneralConfiguration>, IGeneralConfigurationRepository
    {
        private readonly GBAccDbContext _dbCon;
        public GeneralConfigurationRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<int> GetDefaultAccountID(string parameter,  int businessID, string pageName=null)
        {
            int activityID = 0;
            var generalConfigurationObj = await _dbCon.GeneralConfiguration.FirstAsync(b=>b.Parameter==parameter  && b.BusinessID==businessID && b.PageName == pageName);
            if (generalConfigurationObj!=null)
            {
                activityID = generalConfigurationObj.AccountID;
            }
            return activityID;
        }

        public async Task<int[]> GetDefaultAccountID(string parameter, int CompanyID, int businessID, string pageName = null, CancellationToken cancellationToken = default)
        {
 
            var qry =   _dbCon.GeneralConfiguration.Where(b => b.Parameter == parameter);
            if (CompanyID > 0)
            {
                qry = qry.Where(b => b.CompanyID == CompanyID);
            }
            if (businessID > 0)
            {
                qry = qry.Where(b => b.BusinessID == businessID);
            }
            if (pageName!=null && pageName.Length>0)
            {
                qry = qry.Where(b => b.PageName == pageName);
            }

            var data = await qry
                 .Select(b => b.AccountID)
                .ToArrayAsync(cancellationToken);
            return data;

        }

        
    }
}
