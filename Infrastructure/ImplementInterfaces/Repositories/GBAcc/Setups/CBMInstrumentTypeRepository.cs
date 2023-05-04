using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class CBMInstrumentTypeRepository : GenericRepository<CBMInstrumentType>, ICBMInstrumentTypeRepository
    {
        private GBAccDbContext dbCon;
        public CBMInstrumentTypeRepository(GBAccDbContext _dbCon)
            : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetCBMInstrumentTypeList(CancellationToken cancellationToken)
        {
            var data = await dbCon.CBMInstrumentType.Where(x => x.IsActive == true && x.IsRemoved == false)
               .Select(row => new SelectListItem
               {
                   Text = row.InstrumentType,
                   Value = row.InstrumentTypeID.ToString()
               }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
