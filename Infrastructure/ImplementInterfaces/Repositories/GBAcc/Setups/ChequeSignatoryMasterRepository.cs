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
    public class ChequeSignatoryMasterRepository : GenericRepository<ChequeSignatoryMaster>, IChequeSignatoryMasterRepository
    {
        private readonly GBAccDbContext dbCon;

        public ChequeSignatoryMasterRepository(GBAccDbContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyID,CancellationToken cancellationToken)
        {
            return await dbCon.ChequeSignatoryMaster.Where(x => x.IsActive == true && x.IsRemoved == false && x.CompanyID == companyID)
                .Select(row => new SelectListItem
                {
                    Text = row.Description,
                    Value = row.ID.ToString()
                }).ToListAsync(cancellationToken);            
        }
    }
}
