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
   public class CustomerDetailRepository:GenericRepository<CustomerDetail>, ICustomerDetailRepository
    {
        private GBAccDbContext accDbContext;
        public CustomerDetailRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
    }
}
