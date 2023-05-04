using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Queries
{
   public class DDLGetCBMBankListQuery:IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }
    public class DDLGetCBMBankListQueryHandler : IRequestHandler<DDLGetCBMBankListQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankService cBM_BankService;

        public DDLGetCBMBankListQueryHandler(ICBM_BankService _cBM_BankService)
        {
            cBM_BankService = _cBM_BankService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCBMBankListQuery request, CancellationToken cancellationToken)
        {
            return await  cBM_BankService.DDLGetBankList(request.CompanyID,cancellationToken);
        }
    }
}
