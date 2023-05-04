using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries
{
  public  class GetAccountTypeQuery:IRequest<List<AccountTypeResponseModel>>
    {

    }
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAccountTypeQuery, List<AccountTypeResponseModel>>
    {
        private readonly ICBM_AcountTypeService cBM_AcountTypeService;

        public GetAccountTypeQueryHandler(ICBM_AcountTypeService _cBM_AcountTypeService)
        {
            cBM_AcountTypeService = _cBM_AcountTypeService;
        }
        public async Task<List<AccountTypeResponseModel>> Handle(GetAccountTypeQuery request, CancellationToken cancellationToken)
        {
            return await cBM_AcountTypeService.GetAccountType(cancellationToken);
        }
    }
}
