using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.Locations.Commands.DataTransferModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IBasicCOAService basicCOAService;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;

        public LocationService(ILocationRepository _locationRepository,IMapper _mapper
            , IBasicCOAService _basicCOAService, ICurrentUserService _currentUserService)
        {
            locationRepository = _locationRepository;
            mapper = _mapper;
            basicCOAService = _basicCOAService;
            currentUserService = _currentUserService;
        }
        public async Task<RResult> LocationSave(LocationDTM model, CancellationToken cancellationToken)
        {
            var dbModel = mapper.Map<LocationDTM, Location>(model);
            var basicCoa = new BasicCOA
            {
                AccName = model.LocationName,
                ParentID = currentUserService.CompanyID,
                CompanyID = currentUserService.CompanyID,
                LevelID = (int)enum_AccLevels.Location,
            };
             
            var saveLocationCoa = await basicCOAService.SaveBasicCoa(basicCoa);
            dbModel.SrNum = (int)saveLocationCoa.objectID;
            dbModel.LocationCode =(string)saveLocationCoa.objectCode;
            return await locationRepository.LocationSave(dbModel, cancellationToken);
        }
    }
}
