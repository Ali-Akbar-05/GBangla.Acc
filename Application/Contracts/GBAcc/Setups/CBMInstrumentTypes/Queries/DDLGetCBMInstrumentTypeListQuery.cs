using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMInstrumentTypes.Queries
{
    public class DDLGetCBMInstrumentTypeListQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLGetCBMInstrumentTypeListQueryHandler : IRequestHandler<DDLGetCBMInstrumentTypeListQuery, List<SelectListItem>>
    {
        private readonly ICBMInstrumentTypeService instrumentTypeService;
        public DDLGetCBMInstrumentTypeListQueryHandler(ICBMInstrumentTypeService _instrumentTypeService)
        {
            instrumentTypeService = _instrumentTypeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCBMInstrumentTypeListQuery request, CancellationToken cancellationToken)
        {
            return await instrumentTypeService.DDLGetCBMInstrumentTypeList(cancellationToken);
        }
    }
}
