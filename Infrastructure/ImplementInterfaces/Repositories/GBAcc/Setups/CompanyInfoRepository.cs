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
    public class CompanyInfoRepository : GenericRepository<CompanyInfo>, ICompanyInfoRepository
    {
        private readonly GBAccDbContext accDbContext;
        public CompanyInfoRepository(GBAccDbContext _accDbContext):base(_accDbContext)
        {
            accDbContext = _accDbContext;
        }
        public async Task<List<SelectListItem>> DDLGetCompanyInfo(CancellationToken cancellationToken)
        {
            var rtnList = await accDbContext.CompanyInfo.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(x => new SelectListItem()
                {
                    Text=x.CompanyName,
                    Value=x.CompanyID.ToString()
                }).ToListAsync();
            return rtnList;
        }
    }
}
