using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
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
    public class BasicCOAService : IBasicCOAService
    {
        private readonly IBasicCOARepository _basicCOARepository;
        private readonly IGeneralConfigurationService generalConfigurationService;
        private readonly ICurrentUserService currentUserService;

        public BasicCOAService(IBasicCOARepository basicCOARepository, IGeneralConfigurationService _generalConfigurationService,
            ICurrentUserService _currentUserService)
        {
            _basicCOARepository = basicCOARepository;
            generalConfigurationService = _generalConfigurationService;
            currentUserService = _currentUserService;
        }

        public async Task<List<SelectListItem>> DDLAccActivity(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccActivity(ParentID, CompanyID, Predict,cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccBroadGroup(int ParentID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccBroadGroup(ParentID, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccBroadGroupCustome(int ParentID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccBroadGroupCustome(ParentID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccCategory(int CompanyID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccCategory(CompanyID, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccCategoryCustome(int CompanyID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccCategoryCustome(CompanyID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccCostCenter(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccCostCenter(ParentID, CompanyID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccIdentification(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccIdentification(ParentID, Predict, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccIdentificationCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccIdentificationCustome(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccIdentificationGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccIdentificationGroup(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccIdentificationWithNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccIdentificationWithNarrowGroup(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccItem(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccItem(ParentID, Predict, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccItemCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccItemCustome(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccItemWithFullParentGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccItemWithFullParentGroup(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccLocation(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccLocation(ParentID, CompanyID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccNarrowGroup(ParentID, Predict, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccNarrowGroupCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccNarrowGroupCustome(ParentID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccSubCategory(int ParentID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccSubCategory(ParentID, cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLAccSubCategoryCustome(int ParentID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccSubCategoryCustome(ParentID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLSupplier(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLSupplier(ParentList,CompanyID,Predict,cancellationToken);
        }

        public IQueryable<ChartOfAccountListResponseModel> GetChartOfAccountList(ChartOfAccountRequestModel ReqModel)
        {
            return _basicCOARepository.GetChartOfAccountList(ReqModel);
        }

        public async Task<string> GetLastChartOfAccCode(int LevelID, int? CopmanyID, int? ParentID)
        {
            return await _basicCOARepository.GetLastChartOfAccCode(LevelID, CopmanyID, ParentID);
        }

        public async Task<long> GetLastChartOfAccountsID(int LevelID, int? CopmanyID)
        {
            return await _basicCOARepository.GetLastChartOfAccountsID(LevelID, CopmanyID);
        }

        public async Task<RResult> SaveBasicCoa(BasicCOA model)
        {
            return await _basicCOARepository.SaveBasicCoa(model);
        }

        public async Task<ChartOfAccountListResponseModel> GetChartOfAccountByItemID(int ItemID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.GetChartOfAccountByItemID(ItemID, cancellationToken);
        }

        public async Task<RResult> UpdateBasicCoa(BasicCOA model)
        {
            return await _basicCOARepository.UpdateBasicCoa(model);
        }
        public async Task<BasicCOA> GetBasicCOAByID(int AccId)
        {
            return await _basicCOARepository.GetByIdAsync(AccId);
        }

        public async Task<List<SelectListItem>> DDLAccountItemList(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccountItemList(ParentList, CompanyID, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccountType(string predict, CancellationToken cancellationToken)
        {
            var accountID = await generalConfigurationService.GetDefaultAccountID(GeneralConfigurationParameter.BankBalances, currentUserService.BusinessID,null);
            return await _basicCOARepository.DDLAccIdentification(accountID, predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAccBusiness(int parentID, int levelID, int companyID, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.DDLAccBusiness(parentID,levelID, companyID, cancellationToken);
        }

        public async Task<List<CostAndActivityCenterResponseModel>> GetCostCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.GetCostCenterList(reqModel, cancellationToken);
        }

        public async Task<List<CostAndActivityCenterResponseModel>> GetActivityCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken)
        {
            return await _basicCOARepository.GetActivityCenterList(reqModel, cancellationToken);
        }
    }
}
