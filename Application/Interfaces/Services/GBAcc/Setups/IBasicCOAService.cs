using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface IBasicCOAService
    {
        Task<RResult> SaveBasicCoa(BasicCOA model);
        Task<RResult> UpdateBasicCoa(BasicCOA model);
        Task<long> GetLastChartOfAccountsID(int LevelID, int? CopmanyID);
        Task<string> GetLastChartOfAccCode(int LevelID, int? CopmanyID, int? ParentID);

        Task<List<SelectListItem>> DDLAccCategory(int CompanyID, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccCategoryCustome(int CompanyID, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLAccSubCategory(int ParentID, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccSubCategoryCustome(int ParentID, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLAccBroadGroup(int ParentID, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccBroadGroupCustome(int ParentID, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLAccNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccNarrowGroupCustome(int ParentID, string Predict, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLAccIdentification(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccIdentificationWithNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccIdentificationCustome(int ParentID, string Predict, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLAccItem(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccItemWithFullParentGroup(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccIdentificationGroup(int ParentID, string Predict, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccItemCustome(int ParentID, string Predict, CancellationToken cancellationToken);

        IQueryable<ChartOfAccountListResponseModel> GetChartOfAccountList(ChartOfAccountRequestModel ReqModel);

        Task<List<SelectListItem>> DDLAccLocation(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccCostCenter(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccActivity(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLSupplier(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<ChartOfAccountListResponseModel> GetChartOfAccountByItemID(int ItemID, CancellationToken cancellationToken);

        Task<BasicCOA> GetBasicCOAByID(int AccId);
        Task<List<SelectListItem>> DDLAccountItemList(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccountType(string predict,CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccBusiness(int parentID, int levelID, int companyID, CancellationToken cancellationToken);
        Task<List<CostAndActivityCenterResponseModel>> GetCostCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken);
        Task<List<CostAndActivityCenterResponseModel>> GetActivityCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken);


    }
}
