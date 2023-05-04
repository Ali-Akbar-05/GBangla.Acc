using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
  public  class CBM_AcountTypeRepository:GenericRepository<CBM_AcountType>, ICBM_AcountTypeRepository
    {
        private readonly GBAccDbContext _dbCon;
        public CBM_AcountTypeRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<AccountTypeResponseModel>> GetAccountType(CancellationToken cancellationToken)
        {
            var rtnList = await (from acty in _dbCon.CBM_AcountType
                                 join bacT in _dbCon.BasicCOA on acty.AccountTypeID equals bacT.AccID
                                 join bb in _dbCon.BasicCOA on bacT.ParentID equals bb.AccID
                                 where acty.IsActive == true && acty.IsRemoved == false && bacT.LevelID==(int) enum_AccLevels.Identification
                                 && bb.LevelID==(int)enum_AccLevels.NarrowGroup
                                 select new AccountTypeResponseModel() {
                                 AccountTypeID=acty.AccountTypeID,
                                 AccountTypeName=acty.AccountTypeName,
                                 ParentID=bb.AccID,
                                 AccNarroGroup=bb.AccName,
                                 AccountTypeComments=acty.AccountTypeComments
                                 }).ToListAsync();
            return rtnList;
        }

        public async Task<RResult>UpdateAccountType(CBM_AcountType model)
        {
            var result = new RResult();
            var dbObj = await _dbCon.CBM_AcountType.FindAsync(model.AccountTypeID);
            dbObj.AccountTypeName = model.AccountTypeName;
            dbObj.AccountTypeComments = model.AccountTypeComments;
            await UpdateAsync(dbObj, true);
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
            return result;
        }
    }
}
