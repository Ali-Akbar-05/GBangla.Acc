using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Currences.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMapper mapper;

        public CurrencyService(ICurrencyRepository _currencyRepository,IMapper _mapper)
        {
            currencyRepository = _currencyRepository;
            mapper = _mapper;
        }

        public async Task<RResult> CurrencyDataDelete(int currencyID)
        {
            return await currencyRepository.CurrencyDataDelete(currencyID);
        }

        public async Task<RResult> CurrencySave(CurrencyDTM model)
        {
            var result = new RResult();
            var dbObj = mapper.Map<CurrencyDTM, Currency>(model);
            await currencyRepository.InsertAsync(dbObj, true);
            result.result = 1;
            result.message = "Save Successfully";
            return result;
        }

        public async  Task<RResult> CurrencyUpdate(CurrencyDTM model)
        {
            var dbObj = mapper.Map<CurrencyDTM, Currency>(model);
            return await currencyRepository.CurrencyUpdate(dbObj);
        }

        public async Task<List<SelectListItem>> DDLCurrency(CancellationToken cancellationToken)
        {
            return await currencyRepository.DDLCurrency(cancellationToken);
        }

        public async Task<List<CurrencyResponseModel>> GetCurrencyList(CancellationToken cancellationToken)
        {
            return await currencyRepository.GetCurrencyList(cancellationToken);
        }
    }
}
