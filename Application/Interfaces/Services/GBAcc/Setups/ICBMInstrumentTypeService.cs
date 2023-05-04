using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
    public interface ICBMInstrumentTypeService
    {
        Task<List<SelectListItem>> DDLGetCBMInstrumentTypeList(CancellationToken cancellationToken);
    }
}
