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
  public  class CustomerBankInfoRepository:GenericRepository<CustomerBankInfo>, ICustomerBankInfoRepository
    {
        private GBAccDbContext accDbContext;
        public CustomerBankInfoRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
    }
}
