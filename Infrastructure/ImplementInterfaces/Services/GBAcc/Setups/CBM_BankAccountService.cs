using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.BankContactInfos.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class CBM_BankAccountService : ICBM_BankAccountService
    {
        private readonly ICBM_BankAccountRepository cBM_BankAccountRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly IBasicCOAService basicCOAService;
        private readonly IMapper mapper;
        private readonly IBankContactInfoRepository bankContactInfoRepository;
        private readonly IOpeningBalancesRepository openingBalancesRepository;

        public CBM_BankAccountService(ICBM_BankAccountRepository _cBM_BankAccountRepository, ICurrentUserService _currentUserService,
            IBasicCOAService _basicCOAService,IMapper _mapper, IBankContactInfoRepository _bankContactInfoRepository,
            IOpeningBalancesRepository _openingBalancesRepository)
        {
            cBM_BankAccountRepository = _cBM_BankAccountRepository;
            currentUserService = _currentUserService;
            basicCOAService = _basicCOAService;
            mapper = _mapper;
            bankContactInfoRepository = _bankContactInfoRepository;
            openingBalancesRepository = _openingBalancesRepository;
        }

        public async Task<List<SelectListItem>> GetAccountNumberByTypeID(int AccountTypeID, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountRepository.GetAccountNumberByTypeID(AccountTypeID, cancellationToken);
        }

        public async Task<List<BankAccountResponseModel>> GetBankAccountList(CancellationToken cancellationToken)
        {
            return await cBM_BankAccountRepository.GetBankAccountList(cancellationToken);
        }

        public async Task<List<SelectListItem>> GetBankAccountNumberByBankID(int bankID, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountRepository.GetBankAccountNumberByBankID(bankID, cancellationToken);
        }

        public async Task<List<SelectListItem>> GetCurrencyByAccountID(int AccountID, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountRepository.GetCurrencyByAccountID(AccountID, cancellationToken);
        }

        public async Task<List<SelectListItem>> GetIdentification(int branchID, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountRepository.GetIdentification(branchID, cancellationToken);
        }

        public async Task<RResult> SaveBankAccount(CBM_BankAccountDTM model, CancellationToken cancellationToken)
        {
           // var result = new RResult();
            var basicCoa = new BasicCOA
            {
                AccName = model.BAccountName,
                ParentID = model.TypeID,
                CompanyID = currentUserService.CompanyID,
                LevelID = (int)enum_AccLevels.Item,
            };
            var saveItemCoa = await basicCOAService.SaveBasicCoa(basicCoa);
            if (saveItemCoa.result == 1)
            {
                var bankAccountObj = mapper.Map<CBM_BankAccountDTM, CBM_BankAccount>(model);
                bankAccountObj.BAccountID = (int)saveItemCoa.objectID;
                await cBM_BankAccountRepository.InsertAsync(bankAccountObj, true);
                var bankInfoObj = mapper.Map<BankContactInfoDTM, BankContactInfo>(model.BankContactInfo);
                bankInfoObj.AccountID= (int)saveItemCoa.objectID;
                await bankContactInfoRepository.InsertAsync(bankInfoObj, true);
                var openingBal = new OpeningBalances()
                {
                    AccountID= (int)saveItemCoa.objectID,
                    ActivityID=0,
                    CostCenterID=0,
                    OpeningBalance=0,
                    RDate=DateTime.Now,
                    LocationID=0,
            };
                await openingBalancesRepository.SaveOpeningBalance(openingBal);
                return saveItemCoa;
            }
            else
            {
                return saveItemCoa;
            }
          
        }
    }
}
