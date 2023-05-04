using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
    public interface ICBMInstrumentTypeRepository:IGenericRepository<CBMInstrumentType>
    {
        Task<List<SelectListItem>> DDLGetCBMInstrumentTypeList(CancellationToken cancellationToken);
    }
}
