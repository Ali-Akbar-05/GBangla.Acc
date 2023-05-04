using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CompanyInfos.Commands.Queries
{
  public  class DDLGetCompanyInfoQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLGetCompanyInfoQueryHandler : IRequestHandler<DDLGetCompanyInfoQuery, List<SelectListItem>>
    {
        private readonly ICompanyInfoService companyInfoService;

        public DDLGetCompanyInfoQueryHandler(ICompanyInfoService _companyInfoService)
        {
            companyInfoService = _companyInfoService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            return await companyInfoService.DDLGetCompanyInfo(cancellationToken);
        }
    }
}
