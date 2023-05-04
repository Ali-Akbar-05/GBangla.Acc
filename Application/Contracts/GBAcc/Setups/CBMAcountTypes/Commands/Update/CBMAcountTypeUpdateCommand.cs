using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.Update
{
   public class CBMAcountTypeUpdateCommand:IRequest<RResult>
    {
        public CBM_AcountTypeDTM CBM_AcountType { get; set; }
    }
    public class CBMAcountTypeUpdateCommandHandler : IRequestHandler<CBMAcountTypeUpdateCommand, RResult>
    {
        private readonly ICBM_AcountTypeService cBM_AcountTypeService;

        public CBMAcountTypeUpdateCommandHandler(ICBM_AcountTypeService _cBM_AcountTypeService)
        {
            cBM_AcountTypeService = _cBM_AcountTypeService;
        }
        public async Task<RResult> Handle(CBMAcountTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await cBM_AcountTypeService.UpdateAccountType(request.CBM_AcountType, cancellationToken);
        }
    }
}
