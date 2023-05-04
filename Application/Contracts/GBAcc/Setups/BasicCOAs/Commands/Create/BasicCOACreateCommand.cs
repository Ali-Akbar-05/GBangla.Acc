using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.Create
{
   public class BasicCOACreateCommand :IRequest<RResult>
    {
     public BasicCOADTM BasicCOA { get; set; }
    }

    public class BasicCOACreateCommandHandler : IRequestHandler<BasicCOACreateCommand, RResult>
    {
        private readonly IBasicCOARepository _basicCOARepository;
        private readonly IMapper _mapper;
        public BasicCOACreateCommandHandler(IBasicCOARepository basicCOARepository,IMapper mapper)
        {
            _basicCOARepository = basicCOARepository;
            _mapper = mapper;
        }
        public async Task<RResult> Handle(BasicCOACreateCommand request, CancellationToken cancellationToken)
        {
            var mapBasicCoa = _mapper.Map<BasicCOADTM, BasicCOA>(request.BasicCOA);
            return await _basicCOARepository.SaveBasicCoa(mapBasicCoa);
        }
    }
}
