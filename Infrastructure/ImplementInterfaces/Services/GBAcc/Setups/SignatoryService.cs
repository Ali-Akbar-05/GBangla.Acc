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
    public class SignatoryService : ISignatoryService
    {
        private readonly ISignatoryRepository signatoryRepository;

        public SignatoryService(ISignatoryRepository _signatoryRepository)
        {
            signatoryRepository = _signatoryRepository;
        }
        public async Task<List<SelectListItem>> DDLGetSignatoryList(CancellationToken cancellationToken)
        {
            return await signatoryRepository.DDLGetSignatoryList(cancellationToken);
        }
    }
}
