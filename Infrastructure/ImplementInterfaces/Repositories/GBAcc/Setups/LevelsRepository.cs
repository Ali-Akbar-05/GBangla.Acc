using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class LevelsRepository : GenericRepository<Levels>, ILevelsRepository
    {
        private readonly GBAccDbContext _dbCon;
        public LevelsRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLLevels(CancellationToken cancellationToken)
        {
            var data = await _dbCon.Levels.Where(b => b.IsRemoved == false && b.IsActive == true)
                                 .Select(s=>new SelectListItem()
                                 {
                                     Text=s.DisplayLevelName,
                                     Value=s.LevelID.ToString()
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLLevelsChartOfAccounts(int[] IgnoreLevel, CancellationToken cancellationToken)
        {
            int[] chartOfAccountsLevel = {4,5,6,7,8,14 };
           var ignorechartOfAccountsLevel = chartOfAccountsLevel.Except(IgnoreLevel);

            var data = await _dbCon.Levels.Where(b => b.IsRemoved == false && b.IsActive == true && ignorechartOfAccountsLevel.Contains(b.LevelID))
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.DisplayLevelName,
                                    Value = s.LevelID.ToString()
                                })
                                .ToListAsync(cancellationToken);
            return data;
        }
    }
}
