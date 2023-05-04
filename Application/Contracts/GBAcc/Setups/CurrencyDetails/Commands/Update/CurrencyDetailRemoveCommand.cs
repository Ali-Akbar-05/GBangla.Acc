using Application.Common.CommonModels;
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
   public class CurrencyDetailRemoveCommand:IRequest<RResult>
    {
        public int ID { get; set; }
        public bool SaveChange { get; set; } = true;
    }
    public class CurrencyDetailRemoveCommandHandler : IRequestHandler<CurrencyDetailRemoveCommand, RResult>
    {
        private readonly ICurrencyDetailService currencyDetailService;

        public CurrencyDetailRemoveCommandHandler(ICurrencyDetailService _currencyDetailService)
        {
            currencyDetailService = _currencyDetailService;
        }
        public async Task<RResult> Handle(CurrencyDetailRemoveCommand request, CancellationToken cancellationToken)
        {
            return await currencyDetailService.DeleteCurrencyDetail(request.ID, request.SaveChange);
           
        }
    }
}
