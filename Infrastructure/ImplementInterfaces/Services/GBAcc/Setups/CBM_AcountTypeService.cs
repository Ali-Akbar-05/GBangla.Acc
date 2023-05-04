using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Constants;
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
    public class CBM_AcountTypeService : ICBM_AcountTypeService
    {
        private readonly ICBM_AcountTypeRepository cBM_AcountTypeRepository;
        private readonly ICurrentUserService currentUserService;
     
        private readonly IGeneralConfigurationRepository generalConfigurationRepository;
        private readonly IBasicCOARepository basicCOARepository;
        private readonly IMapper mapper;

        public CBM_AcountTypeService(ICBM_AcountTypeRepository _cBM_AcountTypeRepository, ICurrentUserService  _currentUserService,
            IGeneralConfigurationRepository _generalConfigurationRepository,IBasicCOARepository _basicCOARepository,
            IMapper _mapper)
        {
            cBM_AcountTypeRepository = _cBM_AcountTypeRepository;
            currentUserService = _currentUserService;
          
            generalConfigurationRepository = _generalConfigurationRepository;
            basicCOARepository = _basicCOARepository;
            mapper = _mapper;
        }

        public async Task<List<AccountTypeResponseModel>> GetAccountType(CancellationToken cancellationToken)
        {
            return await cBM_AcountTypeRepository.GetAccountType(cancellationToken);
        }

        public async Task<RResult> SaveAccountType(CBM_AcountTypeDTM model,CancellationToken cancellationToken)
        {
            var result = new RResult();
            var parentID = await generalConfigurationRepository.GetDefaultAccountID(GeneralConfigurationParameter.BankBalances,  currentUserService.BusinessID);
            var dbBasicCoa = new BasicCOA()
            {
                AccName=model.AccountTypeName,
                ParentID=parentID,
                LevelID=(int) enum_AccLevels.Identification,
                CompanyID=currentUserService.CompanyID,
            };
            var basicCoaObj=  await basicCOARepository.SaveBasicCoa(dbBasicCoa);
            var dbAccountType = mapper.Map<CBM_AcountTypeDTM, CBM_AcountType>(model);
            dbAccountType.AccountTypeID = (int)basicCoaObj.objectID;
            await cBM_AcountTypeRepository.InsertAsync(dbAccountType, true);
            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            return result;
        }

        public async Task<RResult> UpdateAccountType(CBM_AcountTypeDTM model, CancellationToken cancellationToken)
        {
            var result = new RResult();
            var parentID = await generalConfigurationRepository.GetDefaultAccountID(GeneralConfigurationParameter.BankBalances, currentUserService.BusinessID);
            var dbBasicCoa = new BasicCOA()
            {
                AccID=model.AccountTypeID,
                AccName = model.AccountTypeName,
                ParentID = parentID,
                LevelID = (int)enum_AccLevels.Identification,
                CompanyID = currentUserService.CompanyID,
            };
            await basicCOARepository.UpdateBasicCoa(dbBasicCoa);
            var dbAccountType = mapper.Map<CBM_AcountTypeDTM, CBM_AcountType>(model);
            await cBM_AcountTypeRepository.UpdateAccountType(dbAccountType);
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
            return result;
        }
    }
}
