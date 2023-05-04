using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Queries
{
   public class DDLGetBranchListByBankIDQuery:IRequest<List<SelectListItem>>
    {
        public int BankID { get; set; }
    }
    public class DDLGetBranchListByBankIDQueryHandler : IRequestHandler<DDLGetBranchListByBankIDQuery, List<SelectListItem>>
    {
        private readonly ICBM_BranchService cBM_BranchService;

        public DDLGetBranchListByBankIDQueryHandler(ICBM_BranchService _cBM_BranchService)
        {
            cBM_BranchService = _cBM_BranchService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetBranchListByBankIDQuery request, CancellationToken cancellationToken)
        {
            return await cBM_BranchService.DDLGetBranchList(request.BankID, cancellationToken);
        }
    }
}
