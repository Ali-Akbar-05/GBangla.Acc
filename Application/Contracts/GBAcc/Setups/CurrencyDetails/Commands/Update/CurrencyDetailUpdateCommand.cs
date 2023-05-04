using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.Update
{
   public class CurrencyDetailUpdateCommand:IRequest<RResult>
    {
        public CurrencyDetailDTM CurrencyDetailDTM { get; set; }
    }
    public class CurrencyDetailUpdateCommandHandler : IRequestHandler<CurrencyDetailUpdateCommand, RResult>
    {
        private readonly ICurrencyDetailService currencyDetailService;

        public CurrencyDetailUpdateCommandHandler(ICurrencyDetailService _currencyDetailService)
        {
            currencyDetailService = _currencyDetailService;
        }
        public async Task<RResult> Handle(CurrencyDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await currencyDetailService.UpdateCurrencyDetail(request.CurrencyDetailDTM);
        }
    }
}
