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

namespace Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.Create
{
  public  class CurrencyDetailCreateCommand:IRequest<RResult>
    {
        public CurrencyDetailDTM CurrencyDetailDTM { get; set; }
    }
    public class CurrencyDetailCreateCommandHandler : IRequestHandler<CurrencyDetailCreateCommand, RResult>
    {
        private readonly ICurrencyDetailService currencyDetailService;

        public CurrencyDetailCreateCommandHandler(ICurrencyDetailService _currencyDetailService)
        {
            currencyDetailService = _currencyDetailService;
        }
        public async Task<RResult> Handle(CurrencyDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await currencyDetailService.SaveCurrencyDetail(request.CurrencyDetailDTM);
        }
    }
}
