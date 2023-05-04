using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Queries
{
   public class GetCBMBankListQuery:IRequest<List<CBM_BankResponseModel>>
    {
    }
    public class GetCBMBankListQueryHandler : IRequestHandler<GetCBMBankListQuery, List<CBM_BankResponseModel>>
    {
        private readonly ICBM_BankService cBM_BankService;

        public GetCBMBankListQueryHandler(ICBM_BankService _cBM_BankService)
        {
            cBM_BankService = _cBM_BankService;
        }
        public async Task<List<CBM_BankResponseModel>> Handle(GetCBMBankListQuery request, CancellationToken cancellationToken)
        {
            return await cBM_BankService.GetCBMBankList(cancellationToken);
        }
    }
}
