using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
    public interface IBasicCOARepository:IGenericRepository<BasicCOA>
    {
        Task<RResult> SaveBasicCoa(BasicCOA model);
        Task<RResult> UpdateBasicCoa(BasicCOA model);
        Task<int> GetLastChartOfAccountsID(int LevelID, int? CopmanyID);
        Task<string> GetLastChartOfAccCode(int LevelID, int? CopmanyID, int? ParentID);
        Task<bool> IsExistsChartOfAccounts(int LevelID, int ParentID, int CopmanyID,string AccountName,int?CurrentAccID );

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
        Task<List<SelectListItem>> DDLAccIdentificationGroup(int ParentID,string Predict, CancellationToken cancellationToken);
        Task<List<DropDownItem>> DDLAccItemCustome(int ParentID,string Predict, CancellationToken cancellationToken);

        IQueryable<ChartOfAccountListResponseModel> GetChartOfAccountList(ChartOfAccountRequestModel ReqModel);

        Task<List<SelectListItem>> DDLAccLocation(int ParentID,int CompanyID,string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccCostCenter(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccActivity(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken);

        Task<List<SelectListItem>> DDLSupplier(int[]ParentList,int CompanyID,string Predict,CancellationToken cancellationToken);
        Task<ChartOfAccountListResponseModel> GetChartOfAccountByItemID(int ItemID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccountItemList(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAccBusiness(int parentID, int levelID, int companyID, CancellationToken cancellationToken);
        Task<List<CostAndActivityCenterResponseModel>> GetCostCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken);
        Task<List<CostAndActivityCenterResponseModel>> GetActivityCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken);
        //  Task<BasicCOA> GetBasicCOAByAccID(int accID);
    }
}
