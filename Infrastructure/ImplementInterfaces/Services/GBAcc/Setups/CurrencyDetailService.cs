using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class CurrencyDetailService : ICurrencyDetailService
    {
        private readonly ICurrencyDetailRepository currencyDetailRepository;
        private readonly IMapper mapper;

        public CurrencyDetailService(ICurrencyDetailRepository _currencyDetailRepository,IMapper _mapper)
        {
            currencyDetailRepository = _currencyDetailRepository;
            mapper = _mapper;
        }

        public async Task<List<CurrencyDetailResponseModel>> GetAllCurrencyDetailList(CancellationToken cancellationToken)
        {
            return await currencyDetailRepository.GetAllCurrencyDetailList(cancellationToken);
        }

        public async Task<RResult> SaveCurrencyDetail(CurrencyDetailDTM model)
        {
            var result = new RResult();
            var dbmodel = mapper.Map<CurrencyDetailDTM, CurrencyDetail>(model);
            await currencyDetailRepository.InsertAsync(dbmodel, true);
            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            return result;

        }

        public async Task<RResult> UpdateCurrencyDetail(CurrencyDetailDTM model)
        {
            var result = new RResult();
            var dbCurrencyDetail = await currencyDetailRepository.GetByIdAsync(model.ID);
            dbCurrencyDetail.CurrencyID = model.CurrencyID;
            dbCurrencyDetail.RateInBDT = model.RateInBDT;
            dbCurrencyDetail.Date = model.Date;
            await currencyDetailRepository.UpdateAsync(dbCurrencyDetail, true);
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
            return result;


        }
        public async Task<RResult> DeleteCurrencyDetail(int ID,bool saveChange)
        {
            var result = new RResult();
            var dbCurrencyDetail = await currencyDetailRepository.GetByIdAsync(ID);
            dbCurrencyDetail.IsActive = false;
            dbCurrencyDetail.IsRemoved = true;
            await currencyDetailRepository.UpdateAsync(dbCurrencyDetail, saveChange);
            result.result = 1;
            result.message = ReturnMessage.DeleteMessage;
            return result;


        }

        public async Task<decimal> GetCurrencyExchangeRateByCurrencyID(int currencyID, CancellationToken cancellationToken)
        {
           var currencydetail= await currencyDetailRepository.GetCurrencyDetailByCurrencyID(currencyID, cancellationToken);
            return currencydetail.RateInBDT;
        }
    }
}
