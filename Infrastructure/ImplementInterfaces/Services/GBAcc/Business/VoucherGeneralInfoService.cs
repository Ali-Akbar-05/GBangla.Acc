using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class VoucherGeneralInfoService : IVoucherGeneralInfoService
    {
        private readonly IVoucherGeneralInfoRepository voucherGeneralInfoRepository;

        public VoucherGeneralInfoService(IVoucherGeneralInfoRepository _voucherGeneralInfoRepository)
        {
            voucherGeneralInfoRepository = _voucherGeneralInfoRepository;
        }
        public async Task<List<SelectListItem>> DDlGetPONumberByAccountID(int accountID, DateTime dateFrom, DateTime dateTo, string Predict, CancellationToken cancellationToken)
        {
            return await voucherGeneralInfoRepository.DDlGetPONumberByAccountID(accountID,dateFrom,dateTo, Predict, cancellationToken);
        }
    }
}
