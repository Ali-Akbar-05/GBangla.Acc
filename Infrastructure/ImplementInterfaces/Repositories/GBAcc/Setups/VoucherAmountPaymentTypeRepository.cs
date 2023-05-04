using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
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
    public class VoucherAmountPaymentTypeRepository : GenericRepository<VoucherAmountPaymentType>, IVoucherAmountPaymentTypeRepository
    {
        private readonly GBAccDbContext _context;

        public VoucherAmountPaymentTypeRepository(GBAccDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<SelectListItem>> DDLPaymentType(string type, CancellationToken cancelationToken)
        {
            var data = await _context.VoucherAmountPaymentType.Where(b => b.IsRemoved == false && b.IsActive == true && b.TypeCondition==type)
                .Select(s=> new SelectListItem
                {
                    Text = s.PaymentName,
                    Value = s.PaymentTypeID.ToString(),
                })
                .ToListAsync(cancelationToken);
            return data;
        }
    }
}
