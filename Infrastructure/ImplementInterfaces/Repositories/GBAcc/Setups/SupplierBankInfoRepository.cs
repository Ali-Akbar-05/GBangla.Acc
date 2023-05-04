using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
   public class SupplierBankInfoRepository:GenericRepository<SupplierBankInfo>, ISupplierBankInfoRepository
    {
        private GBAccDbContext accDbContext;
        public SupplierBankInfoRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
    }
}
