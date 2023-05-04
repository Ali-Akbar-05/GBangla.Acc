using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class BasicCOARepository : GenericRepository<BasicCOA>, IBasicCOARepository
    {
        private readonly GBAccDbContext _dbCon;
        public BasicCOARepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<SelectListItem>> DDLAccCategory(int CompanyID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.LevelID == 4
                           && w.CompanyID == CompanyID)
             .Select(s => new SelectListItem()
             {
                 Text = s.AccName,
                 Value = s.AccID.ToString()
             })
              .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropDownItem>> DDLAccCategoryCustome(int CompanyID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                               && w.IsActive == true
                                 && w.LevelID == 4
                               && w.CompanyID == CompanyID)
                 .Select(s => new DropDownItem()
                 {
                     Text = s.AccCode + "-" + s.AccName,
                     Value = s.AccID.ToString(),
                     Custom1 = s.ParentID.ToString(),
                     Custom2 = s.LevelID.ToString(),
                     Custom3 = s.AccCode,
                     Custom4 = s.AccName,
                     Custom5 = s.CompanyID.ToString()
                 })
                  .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccSubCategory(int ParentID, CancellationToken cancellationToken)
        {

            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.ParentID == ParentID);
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),

            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccBusiness(int parentID, int levelID, int companyID, CancellationToken cancellationToken)
        {

            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.ParentID == parentID
                           && w.CompanyID==companyID
                           && w.LevelID==levelID);
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),

            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public Task<List<DropDownItem>> DDLAccSubCategoryCustome(int ParentID, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }


        public async Task<List<SelectListItem>> DDLAccBroadGroup(int ParentID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                              && w.IsActive == true
                              && w.ParentID == ParentID)
                .Select(s => new SelectListItem()
                {
                    Text = s.AccCode + "-" + s.AccName,
                    Value = s.AccID.ToString()
                })
                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropDownItem>> DDLAccBroadGroupCustome(int ParentID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                              && w.IsActive == true
                              && w.ParentID == ParentID)
                .Select(s => new DropDownItem()
                {
                    Text = s.AccCode + "-" + s.AccName,
                    Value = s.AccID.ToString(),
                    Custom1 = s.ParentID.ToString(),
                    Custom2 = s.LevelID.ToString(),
                    Custom3 = s.AccCode,
                    Custom4 = s.AccName,
                    Custom5 = s.CompanyID.ToString()


                })
                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = from iden in _dbCon.BasicCOA
                            join parent in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)iden.ParentID }
                                                       equals new { w1 = parent.IsActive, w2 = parent.IsRemoved, w3 = parent.AccID }
                            where iden.IsActive == true && iden.IsRemoved == false && iden.ParentID == ParentID
                            select new
                            {
                                AccID = iden.AccID,
                                AccName = iden.AccName,
                                AccCode = iden.AccCode,
                                ParrentAccCode = parent.AccCode,
                                ParrentAccName = parent.AccName,
                                ParentAccID = parent.AccID
                            };


            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict)
                                          || w.ParrentAccCode.Contains(Predict) || w.ParrentAccName.Contains(Predict));
            }
            var parentGropu = await dataQuery.Select(b => $"{b.ParrentAccCode}-{b.ParrentAccName}")
                         .Distinct()
                         .Select(groupName => new SelectListGroup { Name = groupName })
                         .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Group = parentGropu[s.ParrentAccCode + "-" + s.ParrentAccName]
            }).ToListAsync(cancellationToken);

            return data;
        }

        public Task<List<DropDownItem>> DDLAccNarrowGroupCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<SelectListItem>> DDLAccIdentification(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.ParentID == ParentID);
            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),

            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropDownItem>> DDLAccIdentificationCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                        && w.IsActive == true
                        && w.ParentID == ParentID);
            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new DropDownItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Custom1 = s.ParentID.ToString(),
                Custom2 = s.LevelID.ToString(),
                Custom3 = s.AccCode,
                Custom4 = s.AccName,
                Custom5 = s.CompanyID.ToString()
            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccIdentificationGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = from iden in _dbCon.BasicCOA
                            join parent in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)iden.ParentID }
                                                       equals new { w1 = parent.IsActive, w2 = parent.IsRemoved, w3 = parent.AccID }
                            where iden.IsActive == true && iden.IsRemoved == false && iden.ParentID == ParentID
                            select new
                            {
                                AccID = iden.AccID,
                                AccName = iden.AccName,
                                AccCode = iden.AccCode,
                                ParrentAccCode = parent.AccCode,
                                ParrentAccName = parent.AccName,
                                ParentAccID = parent.AccID
                            };


            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict)
                                          || w.ParrentAccCode.Contains(Predict) || w.ParrentAccName.Contains(Predict));
            }
            var parentGropu = await dataQuery.Select(b => $"{b.ParrentAccCode}-{b.ParrentAccName}")
                         .Distinct()
                         .Select(groupName => new SelectListGroup { Name = groupName })
                         .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Group = parentGropu[s.ParrentAccCode + "-" + s.ParrentAccName]
            }).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<List<SelectListItem>> DDLAccIdentificationWithNarrowGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = from iden in _dbCon.BasicCOA
                            join parent in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)iden.ParentID }
                                                       equals new { w1 = parent.IsActive, w2 = parent.IsRemoved, w3 = parent.AccID }
                            where iden.IsActive == true && iden.IsRemoved == false && iden.ParentID == ParentID
                            select new
                            {
                                AccID = iden.AccID,
                                AccName = iden.AccName,
                                AccCode = iden.AccCode,
                                ParrentAccCode = parent.AccCode,
                                ParrentAccName = parent.AccName,
                                ParentAccID = parent.AccID
                            };


            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict)
                                          || w.ParrentAccCode.Contains(Predict) || w.ParrentAccName.Contains(Predict));
            }
            var parentGropu = await dataQuery.Select(b => $"{b.ParrentAccCode}-{b.ParrentAccName}")
                          .Distinct()
                          .Select(groupName => new SelectListGroup { Name = groupName })
                          .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Group = parentGropu[s.ParrentAccCode + "-" + s.ParrentAccName]
            }).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<List<SelectListItem>> DDLAccItem(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.ParentID == ParentID);
            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),

            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropDownItem>> DDLAccItemCustome(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                           && w.IsActive == true
                           && w.ParentID == ParentID);
            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new DropDownItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Custom1 = s.ParentID.ToString(),
                Custom2 = s.LevelID.ToString(),
                Custom3 = s.AccCode,
                Custom4 = s.AccName,
                Custom5 = s.CompanyID.ToString()
            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public Task<List<SelectListItem>> DDLAccItemWithFullParentGroup(int ParentID, string Predict, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
            /*
            var dataQuery = from item in _dbCon.BasicCOA
                            join iden in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)item.ParentID }
                                                       equals new { w1 = iden.IsActive, w2 = iden.IsRemoved, w3 = iden.AccID }
                            join narro in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)iden.ParentID }
                                                        equals new { w1 = narro.IsActive, w2 = narro.IsRemoved, w3 = narro.AccID }
                            join broad in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)narro.ParentID }
                                                        equals new { w1 = broad.IsActive, w2 = broad.IsRemoved, w3 = broad.AccID }
                            join sub in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)broad.ParentID }
                                                    equals new { w1 = sub.IsActive, w2 = sub.IsRemoved, w3 = sub.AccID }
                            join cat in _dbCon.BasicCOA on new { w1 = true, w2 = false, w3 = (int)sub.ParentID }
                                                    equals new { w1 = cat.IsActive, w2 = cat.IsRemoved, w3 = cat.AccID }

                            where item.IsActive == true && item.IsRemoved == false && iden.ParentID == ParentID
                            select new
                            {
                                AccID = iden.AccID,
                                AccName = iden.AccName,
                                AccCode = iden.AccCode,
                                ParrentAccCode = parent.AccCode,
                                ParrentAccName = parent.AccName,
                                ParentAccID = parent.AccID
                            };


            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict)
                                          || w.ParrentAccCode.Contains(Predict) || w.ParrentAccName.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),
                Group = new SelectListGroup() { Name = s.ParrentAccCode + "-" + s.ParrentAccName }
            }).ToListAsync(cancellationToken);

            return data;
            */
        }

        public async Task<string> GetLastChartOfAccCode(int LevelID, int? CompanyID, int? ParentID)
        {
            string lastAccCode = "";
            var levelInfo = await _dbCon.Levels.FindAsync(LevelID);

            var coaQuery = _dbCon.BasicCOA.Where(b => b.LevelID == LevelID
                                                   && b.CompanyID == CompanyID
                                                   && b.ParentID == ParentID);

            var totalHead = await coaQuery.CountAsync();
            if (totalHead == 0)
            {
                var previousCoaInfo = await _dbCon.BasicCOA.Where(b => b.AccID == ParentID.Value).FirstAsync();
                string previousAccCode = previousCoaInfo.AccCode;
                string AccAdditionCode = 1.ToString(levelInfo.COAOwnCodeDigit);
                lastAccCode = string.Concat(previousAccCode, AccAdditionCode);
            }
            else
            {
                var maxCode = await coaQuery.MaxAsync(b => Convert.ToInt64(b.AccCode));
                var newHead = maxCode + 1;
                lastAccCode = newHead.ToString(levelInfo.COAFullCodeDigit);
            }

            return lastAccCode;
        }

        public async Task<int> GetLastChartOfAccountsID(int LevelID, int? CompanyID)
        {
            var CoaLevelIns = await _dbCon.Levels.FirstAsync(b => b.LevelID == LevelID && b.IsRemoved == false);

            var newAccID = await _dbCon.BasicCOA.Where(b => b.LevelID == LevelID).CountAsync();
            if (newAccID == 0)
            {
                newAccID = CoaLevelIns.COAIDStart;
            }
            else
            {
                newAccID += CoaLevelIns.COAIDStart;
            }

            return newAccID;
        }
        public async Task<bool> IsExistsChartOfAccounts(int LevelID, int ParentID, int CopmanyID, string AccountName, int? CurrentAccID)
        {
            var dataQuery = _dbCon.BasicCOA.Where(b => b.LevelID == LevelID
             && b.ParentID == ParentID
             && b.CompanyID == CopmanyID
             && b.AccName == AccountName
             );
            if (CurrentAccID.HasValue == true && CurrentAccID > 0)
            {
                dataQuery = dataQuery.Where(b => b.AccID != CurrentAccID);
            }
            var data = await dataQuery.AnyAsync();

            return data;
        }

        public async Task<RResult> SaveBasicCoa(BasicCOA model)
        {
            var result = new RResult();
            var isExists = await IsExistsChartOfAccounts(model.LevelID, model.ParentID.Value, model.CompanyID.Value, model.AccName, model.AccID);

            if (string.IsNullOrWhiteSpace(model.AccName) && model.AccName.Length < 2)
            {
                result.result = 0;
                result.message = $"Chart of Accounts is not empty.";
                return result;
            }
            if (isExists == true)
            {
                result.result = 0;
                result.message = $"{model.AccName} is already exist.";

                return result;
            }

            var LastAccID = await GetLastChartOfAccountsID(model.LevelID, model.CompanyID);
            model.AccCode = await GetLastChartOfAccCode(model.LevelID, model.CompanyID, model.ParentID);

            model.AccID = LastAccID + 1;
            var save = await InsertAsync(model, true);

            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            result.objectID = model.AccID;
            result.objectCode = model.AccCode;
            return result;

        }
        //public async Task<RResult> UpdateBasicCoa(BasicCOA model)
        //{
        //    var result = new RResult();
        //    var basiCoa = await _dbCon.BasicCOA.FindAsync(model.AccID);
        //    basiCoa.AccName = model.AccName;
        //    basiCoa.ParentID = model.ParentID;
        //     _dbCon.BasicCOA.Update(basiCoa);
        //    await _dbCon.SaveChangesAsync();
        //    result.result = 1;
        //    result.message = ReturnMessage.UpdateMessage;
        //    return result;
        //}
        public async Task<RResult> UpdateBasicCoa(BasicCOA model)
        {
            var result = new RResult();
            var isExists = await IsExistsChartOfAccounts(model.LevelID, model.ParentID.Value, model.CompanyID.Value, model.AccName, model.AccID);
            if (string.IsNullOrWhiteSpace(model.AccName) && model.AccName.Length < 2)
            {
                result.result = 0;
                result.message = $"Chart of Accounts is not empty.";
                return result;
            }
            if (isExists == true)
            {
                result.result = 0;
                result.message = $"{model.AccName} is already exist.";

                return result;
            }
               var basiCoa = await _dbCon.BasicCOA.FindAsync(model.AccID);
                basiCoa.AccName = model.AccName;
                basiCoa.ParentID = model.ParentID;
            await UpdateAsync(basiCoa, true);
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
            result.objectID = model.AccID;
            result.objectCode = model.AccCode;
            return result;
        }
        //public async Task<BasicCOA> GetBasicCOAByAccID(int accID)
        //{
        //    return await _dbCon.BasicCOA.FindAsync(accID);
        //}

        public IQueryable<ChartOfAccountListResponseModel> GetChartOfAccountList(ChartOfAccountRequestModel ReqModel)
        {
            var dataquery = _dbCon.vw_BasicCOA.Where(b => b.CompanyID == ReqModel.CompanyID);
            if (ReqModel.AccLevelID == 5)
            {
                dataquery = dataquery.Where(b => b.SubCategoryLevelID == 5);
                if (ReqModel.ParentID > 0)
                {
                    dataquery = dataquery.Where(b => b.CategoryID == ReqModel.ParentID);
                    if (!string.IsNullOrEmpty(ReqModel.Predict))
                    {
                        dataquery = dataquery.Where(w => w.SubCategory.Contains(ReqModel.Predict));
                    }
                }
            }
            else if (ReqModel.AccLevelID == 6)
            {
                dataquery = dataquery.Where(b => b.BroadGroupLevelID == 6);
                if (ReqModel.ParentID > 0)
                {
                    dataquery = dataquery.Where(b => b.SubCategoryID == ReqModel.ParentID);
                    if (!string.IsNullOrEmpty(ReqModel.Predict))
                    {
                        dataquery = dataquery.Where(w => w.BroadGroup.Contains(ReqModel.Predict));
                    }
                }
            }
            else if (ReqModel.AccLevelID == 7)
            {
                dataquery = dataquery.Where(b => b.NarrowGroupLevelID == 7);
                if (ReqModel.ParentID > 0)
                {
                    dataquery = dataquery.Where(b => b.BroadGroupID == ReqModel.ParentID);
                    if (!string.IsNullOrEmpty(ReqModel.Predict))
                    {
                        dataquery = dataquery.Where(w => w.NarrowGroup.Contains(ReqModel.Predict));
                    }
                }
            }
            else if (ReqModel.AccLevelID == 8)
            {
                dataquery = dataquery.Where(b => b.IdentificationLevelID == 8);
                if (ReqModel.ParentID > 0)
                {
                    dataquery = dataquery.Where(b => b.NarrowGroupID == ReqModel.ParentID);
                    if (!string.IsNullOrEmpty(ReqModel.Predict))
                    {
                        dataquery = dataquery.Where(w => w.Identification.Contains(ReqModel.Predict));
                    }
                }
            }

            else if (ReqModel.AccLevelID == 14)
            {
                dataquery = dataquery.Where(b => b.ItemLevelID == 8);
                if (ReqModel.ParentID > 0)
                {
                    dataquery = dataquery.Where(b => b.IdentificationID == ReqModel.ParentID);
                    if (!string.IsNullOrEmpty(ReqModel.Predict))
                    {
                        dataquery = dataquery.Where(w => w.Item.Contains(ReqModel.Predict));
                    }
                }
            }
            var _dataquery = dataquery.Select(s => new ChartOfAccountListResponseModel()
            {
                Serial = s.Serial,
                CategoryID = s.CategoryID,
                Category = s.CategoryName,
                SubCategoryID = s.SubCategoryID,
                SubCategory = s.SubCategory,
                BroadGroupID = s.BroadGroupID,
                BroadGroup = s.BroadGroup,
                NarrowGroupID = s.NarrowGroupID,
                NarrowGroup = s.NarrowGroup,
                IdentificationID = s.IdentificationID,
                Identification = s.Identification,
                ItemID = s.ItemID,
                Item = s.Item,
                CompanyID = s.CompanyID,
                Company = s.CompanyName
            });


            return _dataquery;
        }


        public async Task<List<SelectListItem>> DDLAccLocation(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = _dbCon.BasicCOA.Where(w => w.IsRemoved == false
                             && w.IsActive == true
                             && w.ParentID == ParentID && w.LevelID==(int)enum_AccLevels.Location);
            if (CompanyID > 0)
            {
                dataQuery = dataQuery.Where(w => w.CompanyID == CompanyID);
            }

            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccName.Contains(Predict) || w.AccCode.Contains(Predict));
            }
            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = s.AccCode + "-" + s.AccName,
                Value = s.AccID.ToString(),

            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccCostCenter(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = from bus in _dbCon.BasicCOA
                            join cost in _dbCon.BasicCOA on new { w1 = bus.AccID, w2 = bus.IsRemoved, w3 = bus.IsActive }
                                                     equals new { w1 = cost.ParentID.Value, w2 = false, w3 = true }
                            where cost.LevelID == (int)enum_AccLevels.CostCenter
                            && bus.AccID == ParentID
                            select new
                            {
                                BusinessName = bus.AccName,
                                CostCenterName = cost.AccName,
                                CostCenterCode = cost.AccCode,
                                CostCenterID = cost.AccID,
                                CompanyID = bus.CompanyID,
                                AccFullName = string.Concat(bus.AccCode,'-',bus.AccName)
                            };
            if (CompanyID > 0)
            {
                dataQuery = dataQuery.Where(w => w.CompanyID == CompanyID);
            }

            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccFullName.Contains(Predict)|| w.CostCenterCode.Contains(Predict));
            }
            var parentGropu = await dataQuery.Select(b => b.AccFullName)
                           .Distinct()
                           .Select(groupName => new SelectListGroup { Name = groupName })
                           .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = $"{s.CostCenterCode}-{s.CostCenterName}",
                Value = s.CostCenterID.ToString(),
                Group = parentGropu[s.AccFullName],
            })
             .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccActivity(int ParentID, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            var dataQuery = from cost in _dbCon.BasicCOA
                            join acct in _dbCon.BasicCOA on new { w1 = cost.AccID, w2 = cost.IsRemoved, w3 = cost.IsActive }
                                                     equals new { w1 = acct.ParentID.Value, w2 = false, w3 = true }
                            where acct.LevelID == (int)enum_AccLevels.Activity
                            && acct.ParentID == ParentID
                            select new
                            {
                                CostCenterName = cost.AccName,
                                AcctivityName = acct.AccName,
                                ActivityCode = acct.AccCode,
                                AcctivityID = acct.AccID,
                                CompanyID = cost.CompanyID,
                                AccFullName = string.Concat(cost.AccCode,'-',cost.AccName)
                            };
            if (CompanyID > 0)
            {
                dataQuery = dataQuery.Where(w => w.CompanyID == CompanyID);
            }

            if (!string.IsNullOrEmpty(Predict))
            {
                dataQuery = dataQuery.Where(w => w.AccFullName.Contains(Predict) || w.ActivityCode.Contains(Predict));
            }

            var parentGropu = await dataQuery.Select(b => b.AccFullName)
                            .Distinct()
                            .Select(groupName => new SelectListGroup { Name = groupName })
                            .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await dataQuery.Select(s => new SelectListItem()
            {
                Text = $"{s.ActivityCode}-{s.AcctivityName}",
                Value = s.AcctivityID.ToString(),
                Group = parentGropu[s.AccFullName],

            }).ToListAsync(cancellationToken);
            return data;
        }
        public async Task<List<SelectListItem>> DDLSupplier(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            var query = from cat in _dbCon.BasicCOA
                        join subcat in _dbCon.BasicCOA on new { j1 = (int)cat.ParentID, j2 = cat.AccID }
                                                   equals new { j1 = CompanyID, j2 = (int)subcat.ParentID }

                        join broad in _dbCon.BasicCOA on new { j1 = subcat.AccID, j2 = subcat.IsRemoved, j3 = subcat.IsActive }
                                                   equals new { j1 = (int)broad.ParentID, j2 = false, j3 = true }

                        join narro in _dbCon.BasicCOA on new { j1 = broad.AccID, j2 = broad.IsRemoved, j3 = broad.IsActive }
                                                   equals new { j1 = (int)narro.ParentID, j2 = false, j3 = true }

                        join iden in _dbCon.BasicCOA on new { j1 = narro.AccID, j2 = narro.IsRemoved, j3 = narro.IsActive }
                                                   equals new { j1 = (int)iden.ParentID, j2 = false, j3 = true }

                        join item in _dbCon.BasicCOA on new { j1 = iden.AccID, j2 = iden.IsRemoved, j3 = iden.IsActive }
                                                equals new { j1 = (int)item.ParentID, j2 = false, j3 = true }

                        join sup in _dbCon.Supplier on new { j1 = item.AccID, j2 = subcat.IsRemoved, j3 = subcat.IsActive }
                                                   equals new { j1 = (int)sup.SupplierID, j2 = false, j3 = true }

                        select new
                        {
                            Category = cat.AccName,
                            SubCategory = subcat.AccName,
                            Broad = broad.AccName,
                            Narrow = narro.AccName,
                            Identity = iden.AccName,
                            IdentityID = iden.AccID,
                            Supplier = item.AccName,
                            SupplierID = item.AccID,
                            SupplierCode= item.AccCode,
                            FullName = $"{iden.AccName}>>{narro.AccName}>>{broad.AccName}>>{subcat.AccName}>>{cat.AccName}",
                        };

            if (ParentList.Count() > 0)
            {
                query = query.Where(b => ParentList.Contains(b.IdentityID));
            }

            if (!string.IsNullOrEmpty(Predict))
            {
                query = query.Where(b => b.Supplier.Contains(Predict)|| b.SupplierCode.Contains(Predict));
            }

            var parentGropu = await query.Select(b => b.FullName)
                .Distinct()
                .Select(groupName => new SelectListGroup { Name = groupName })
                .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken); 


            var data =await query.Select(s => new SelectListItem()
            {
                Text = $"{s.SupplierCode}-{s.Supplier}",
                Value = s.SupplierID.ToString(),
                Group = parentGropu[s.FullName], // new SelectListGroup { Name = s.FullName }
            }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLAccountItemList(int[] ParentList, int CompanyID, string Predict, CancellationToken cancellationToken)
        {
            var query = from cat in _dbCon.BasicCOA
                        join subcat in _dbCon.BasicCOA on new { j1 = (int)cat.ParentID, j2 = cat.AccID }
                                                   equals new { j1 = CompanyID, j2 = (int)subcat.ParentID }

                        join broad in _dbCon.BasicCOA on new { j1 = subcat.AccID, j2 = subcat.IsRemoved, j3 = subcat.IsActive }
                                                   equals new { j1 = (int)broad.ParentID, j2 = false, j3 = true }

                        join narro in _dbCon.BasicCOA on new { j1 = broad.AccID, j2 = broad.IsRemoved, j3 = broad.IsActive }
                                                   equals new { j1 = (int)narro.ParentID, j2 = false, j3 = true }

                        join iden in _dbCon.BasicCOA on new { j1 = narro.AccID, j2 = narro.IsRemoved, j3 = narro.IsActive }
                                                   equals new { j1 = (int)iden.ParentID, j2 = false, j3 = true }

                        join item in _dbCon.BasicCOA on new { j1 = iden.AccID, j2 = iden.IsRemoved, j3 = iden.IsActive }
                                                equals new { j1 = (int)item.ParentID, j2 = false, j3 = true }
                        select new
                        {
                            Category = cat.AccName,
                            SubCategory = subcat.AccName,
                            Broad = broad.AccName,
                            Narrow = narro.AccName,
                            Identity = iden.AccName,
                            IdentityID = iden.AccID,
                            AccountName = item.AccName,
                            AccountID = item.AccID,
                            AccountCode = item.AccCode,
                            FullName = $"{iden.AccName}>>{narro.AccName}>>{broad.AccName}>>{subcat.AccName}>>{cat.AccName}",
                        };

            if (ParentList.Count() > 0)
            {
                query = query.Where(b => ParentList.Contains(b.IdentityID));
            }

            if (!string.IsNullOrEmpty(Predict))
            {
                query = query.Where(b => b.AccountName.Contains(Predict) || b.AccountCode.Contains(Predict));
            }
            var parentGropu = await query.Select(b => b.FullName)
               .Distinct()
               .Select(groupName => new SelectListGroup { Name = groupName })
               .ToDictionaryAsync(group => group.Name, StringComparer.Ordinal, cancellationToken);

            var data = await query.Select(s => new SelectListItem()
            {
                Text = $"{s.AccountCode}-{s.AccountName}",
                Value = s.AccountID.ToString(),
                Group = parentGropu[s.FullName],
            }).ToListAsync(cancellationToken);
            return data;
        }
        //ChartOfAccountListResponseModel
        public async Task<ChartOfAccountListResponseModel> GetChartOfAccountByItemID(int ItemID ,CancellationToken cancellationToken)
        {
            var rtnList = await (from accCat in _dbCon.BasicCOA
                                 join accSubcat in _dbCon.BasicCOA on accCat.AccID equals accSubcat.ParentID
                                 join accBroad in _dbCon.BasicCOA on accSubcat.AccID equals accBroad.ParentID
                                 join accNarrow in _dbCon.BasicCOA on accBroad.AccID equals accNarrow.ParentID
                                 join accIden in _dbCon.BasicCOA on accNarrow.AccID equals accIden.ParentID
                                 join accItem in _dbCon.BasicCOA on accIden.AccID equals accItem.ParentID
                                 where accCat.LevelID == (int)enum_AccLevels.Category && accSubcat.LevelID == (int)enum_AccLevels.SubCategory
                                 && accBroad.LevelID == (int)enum_AccLevels.BroadGroup && accNarrow.LevelID == (int)enum_AccLevels.NarrowGroup
                                 && accIden.LevelID == (int)enum_AccLevels.Identification && accItem.LevelID == (int)enum_AccLevels.Item
                                 && accItem.AccID==ItemID && accItem.IsActive==true && accItem.IsRemoved==false
                                 select new ChartOfAccountListResponseModel()
                                 {
                                     CategoryID = accCat.AccID,
                                     Category = accCat.AccName,
                                     SubCategoryID=accBroad.ParentID,
                                     SubCategory = accSubcat.AccName,
                                     BroadGroupID=accNarrow.ParentID,
                                     BroadGroup = accBroad.AccName,
                                     NarrowGroupID=accIden.ParentID,
                                     NarrowGroup = accNarrow.AccName,
                                     IdentificationID=accItem.ParentID,
                                     Identification = accIden.AccName,
                                     Item = accItem.AccName,
                                     ItemID = accItem.ParentID

                                 }).FirstAsync();
            return rtnList;
        }

        public async Task<List<CostAndActivityCenterResponseModel>> GetCostCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken)
        {
            var rtnList = await (from bus in _dbCon.BasicCOA
                                 join com in _dbCon.CompanyInfo on bus.CompanyID equals com.CompanyID
                                 join cos in _dbCon.BasicCOA on bus.AccID equals cos.ParentID
                                 where cos.IsActive == true && cos.IsRemoved == false
                                 && cos.LevelID == reqModel.AccLevelID
                               //  && cos.ParentID == reqModel.ParentID
                                 && cos.CompanyID == reqModel.CompanyID
                                 select new CostAndActivityCenterResponseModel()
                                 {
                                     CompanyID=cos.CompanyID.Value,
                                     CompanyName=com.CompanyName,
                                     Business=bus.AccName,
                                     BusinessID=bus.AccID,
                                     CostCenter=cos.AccName,
                                     CostCenterID=cos.AccID,
                                     LevelID=cos.LevelID
                                 }).ToListAsync(cancellationToken);



            return rtnList;
                
        }
        public async Task<List<CostAndActivityCenterResponseModel>> GetActivityCenterList(ChartOfAccountRequestModel reqModel, CancellationToken cancellationToken)
        {
            var rtnList = await (from bus in _dbCon.BasicCOA
                                 join com in _dbCon.CompanyInfo on bus.CompanyID equals com.CompanyID
                                 join cos in _dbCon.BasicCOA on bus.AccID equals cos.ParentID
                                 join act in _dbCon.BasicCOA on cos.AccID equals act.ParentID
                                 where act.IsActive == true && act.IsRemoved == false
                                 && act.LevelID == reqModel.AccLevelID
                                 //  && cos.ParentID == reqModel.ParentID
                                 && cos.CompanyID == reqModel.CompanyID
                                 select new CostAndActivityCenterResponseModel()
                                 {
                                     CompanyID = cos.CompanyID.Value,
                                     CompanyName = com.CompanyName,
                                     Business = bus.AccName,
                                     BusinessID = bus.AccID,
                                     CostCenter = cos.AccName,
                                     CostCenterID = cos.AccID,
                                     LevelID = act.LevelID,
                                     ActivityID=act.AccID,
                                     Activity=act.AccName

                                 }).ToListAsync(cancellationToken);



            return rtnList;

        }
    }
}
