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
    public class CBM_PrintedChequeStatusRepository : GenericRepository<CBM_PrintedChequeStatus>, ICBM_PrintedChequeStatusRepository
    {
        private readonly GBAccDbContext accDbContext;
        public CBM_PrintedChequeStatusRepository(GBAccDbContext _accDbContext) : base(_accDbContext)
        {
            accDbContext = _accDbContext;
        }
        public async Task<List<SelectListItem>> DDLGetCBMPrintedChequeStatus(CancellationToken cancellationToken)
        {
            var rtnList = await accDbContext.CBM_PrintedChequeStatus.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(s => new SelectListItem()
                {
                    Text=s.StatusName,
                    Value=s.StatusID.ToString()
                }).ToListAsync();
            return rtnList;
        }
    }
}
