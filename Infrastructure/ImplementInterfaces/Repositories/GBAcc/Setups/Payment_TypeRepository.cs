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
    public class Payment_TypeRepository : GenericRepository<Payment_Type>, IPayment_TypeRepository
    {
        private readonly GBAccDbContext _dbCon;
        public Payment_TypeRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetPaymentType(CancellationToken cancellationToken)
        {
            var rtnList = await _dbCon.Payment_Type.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(b => new SelectListItem()
                {
                    Text=b.PaymentType,
                    Value=b.ID.ToString()
                }).ToListAsync();
            return rtnList;
        }
    }
}
