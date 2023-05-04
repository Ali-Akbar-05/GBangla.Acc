using Application.Common.CommonModels;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private GBAccDbContext accDbContext;
        public LocationRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> LocationSave(Location dbmodel, CancellationToken cancellationToken)
        {
            var result = new RResult();
            try
            {
                await accDbContext.Location.AddAsync(dbmodel);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = "Save Successfully";
            }catch(Exception e)
            {
                result.result = 0;
                result.message = e.Message;

            }
            return result;
        }
    }
}
