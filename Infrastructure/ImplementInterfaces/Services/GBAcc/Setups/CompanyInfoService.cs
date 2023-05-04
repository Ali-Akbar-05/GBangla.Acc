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
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository companyInfoRepository;

        public CompanyInfoService(ICompanyInfoRepository _companyInfoRepository)
        {
            companyInfoRepository = _companyInfoRepository;
        }
        public async Task<List<SelectListItem>> DDLGetCompanyInfo(CancellationToken cancellationToken)
        {
            return await companyInfoRepository.DDLGetCompanyInfo(cancellationToken);
        }
    }
}
