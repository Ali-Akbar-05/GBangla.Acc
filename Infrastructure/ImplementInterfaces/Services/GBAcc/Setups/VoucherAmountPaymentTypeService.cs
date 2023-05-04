using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class VoucherAmountPaymentTypeService : IVoucherAmountPaymentTypeService
    {
        private readonly IVoucherAmountPaymentTypeRepository _voucherAmountPaymentTypeRepository;

        public VoucherAmountPaymentTypeService(IVoucherAmountPaymentTypeRepository voucherAmountPaymentTypeRepository)
        {
            _voucherAmountPaymentTypeRepository = voucherAmountPaymentTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLPaymentType(string type, CancellationToken cancelationToken)
        {
            return await _voucherAmountPaymentTypeRepository.DDLPaymentType(type,cancelationToken);
        }
    }
}
