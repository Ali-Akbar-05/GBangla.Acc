using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Locations.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Locations.Commands.Create
{
   public class LocationCreateCommand:IRequest<RResult>
    {
        public LocationDTM locationDTM { get; set; }
    }
    public class LocationCreateCommandHandler : IRequestHandler<LocationCreateCommand, RResult>
    {
        private readonly ILocationService locationService;

        public LocationCreateCommandHandler(ILocationService _locationService)
        {
            locationService = _locationService;
        }
        public async Task<RResult> Handle(LocationCreateCommand request, CancellationToken cancellationToken)
        {
            return await locationService.LocationSave(request.locationDTM, cancellationToken);
        }
    }
}
