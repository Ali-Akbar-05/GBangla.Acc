using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.Update
{
   public class BasicCOAUpdateCommand : IRequest<RResult>
    {
        public BasicCOADTM BasicCOA { get; set; }
    }
    public class BasicCOAUpdateCommandHandle : IRequestHandler<BasicCOAUpdateCommand, RResult>
    {
        private readonly IBasicCOARepository basicCOARepository;
        private readonly IMapper mapper;

        public BasicCOAUpdateCommandHandle(IBasicCOARepository _basicCOARepository, IMapper _mapper)
        {
            basicCOARepository = _basicCOARepository;
            mapper = _mapper;
        }
        public async Task<RResult> Handle(BasicCOAUpdateCommand request, CancellationToken cancellationToken)
        {
            var mapBasicCoa = mapper.Map<BasicCOADTM, BasicCOA>(request.BasicCOA);
            return await basicCOARepository.UpdateBasicCoa(mapBasicCoa);
        }
    }

}
