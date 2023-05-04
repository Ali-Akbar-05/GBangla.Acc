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
    public class SignatoryRepository : GenericRepository<Signatory>, ISignatoryRepository
    {
        private GBAccDbContext accDbContext;
        public SignatoryRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<List<SelectListItem>> DDLGetSignatoryList(CancellationToken cancellationToken)
        {
            var rtnList = await accDbContext.Signatory.Where(b => b.IsActive == true && b.IsRemoved == false)
                 .Select(s => new SelectListItem()
                 {
                     Text = s.SignatoryName,
                     Value = s.ID.ToString()
                 }).ToListAsync(cancellationToken);
            return rtnList;
        }
    }
}
