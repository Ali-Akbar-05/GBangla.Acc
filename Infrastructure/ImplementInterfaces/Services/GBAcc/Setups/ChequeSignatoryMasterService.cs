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
    public class ChequeSignatoryMasterService : IChequeSignatoryMasterService
    {
        private readonly IChequeSignatoryMasterRepository chequeSignatoryMasterRepository;

        public ChequeSignatoryMasterService(IChequeSignatoryMasterRepository _chequeSignatoryMasterRepository)
        {
            chequeSignatoryMasterRepository = _chequeSignatoryMasterRepository;
        }
        public async Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyID, CancellationToken cancellationToken)
        {
            return await chequeSignatoryMasterRepository.DDLChequeSignatoryMasterList(companyID, cancellationToken);
        }
    }
}
