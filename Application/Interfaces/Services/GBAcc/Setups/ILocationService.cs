using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Locations.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface ILocationService
    {
        Task<RResult> LocationSave(LocationDTM model, CancellationToken cancellationToken);
    }
}
