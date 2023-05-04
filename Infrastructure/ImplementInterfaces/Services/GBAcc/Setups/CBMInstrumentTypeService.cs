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
    public class CBMInstrumentTypeService : ICBMInstrumentTypeService
    {
        private readonly ICBMInstrumentTypeRepository instrumentTypeRepository;

        public CBMInstrumentTypeService(ICBMInstrumentTypeRepository _instrumentTypeRepository)
        {
            instrumentTypeRepository = _instrumentTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLGetCBMInstrumentTypeList(CancellationToken cancellationToken)
        {
            return await instrumentTypeRepository.DDLGetCBMInstrumentTypeList(cancellationToken);
        }
    }
}
