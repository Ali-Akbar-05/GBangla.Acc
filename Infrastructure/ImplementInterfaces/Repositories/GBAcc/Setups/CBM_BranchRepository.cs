using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class CBM_BranchRepository : GenericRepository<CBM_Branch>, ICBM_BranchRepository
    {
        private GBAccDbContext accDbContext;
        public CBM_BranchRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> BranchSave(CBM_Branch model)
        {
            try
            {
                model.BranchID = await GetTableMaxID();
                var result = new RResult();
                await accDbContext.CBM_Branch.AddAsync(model);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = "Save Successfully";
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
        public async Task<RResult> BranchUpdate(CBM_Branch model)
        {
            try
            {
                var result = new RResult();
                var dbObj = await accDbContext.CBM_Branch.FindAsync(model.BranchID);
                dbObj.BranchName = model.BranchName;
                dbObj.BankID = model.BankID;
                dbObj.BranchAddress = model.BranchAddress;
                accDbContext.CBM_Branch.Update(dbObj);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = "Update Successfully";
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public async Task<RResult> BranchDelete(int branchID)
        {
            var result = new RResult();
            var dbObj = await accDbContext.CBM_Branch.FindAsync(branchID);
            dbObj.IsActive = false;
            dbObj.IsRemoved = true;
            accDbContext.CBM_Branch.Update(dbObj);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.message = "Delete Successfully";
            return result;

        }

        public async Task<int> GetTableMaxID()
        {
            int ID = 1;
            var dbObj = await accDbContext.CBM_Branch.FirstOrDefaultAsync();
            if (dbObj!=null)
            {
                var dbID = accDbContext.CBM_Branch.Max(b => b.BranchID);
                ID += dbID;
            }
            return ID;

        }
        public async Task<List<CBM_BranchResponseModel>> GetCBMBranchList(CancellationToken cancellationToken)
        {
            try
            {
                var rtnList = await (from bnk in accDbContext.CBM_Bank
                                     join brn in accDbContext.CBM_Branch on bnk.BankID equals brn.BankID
                                     where brn.IsActive == true && brn.IsRemoved == false
                                     select new CBM_BranchResponseModel()
                                     {
                                         BranchID = brn.BranchID,
                                         BranchName = brn.BranchName,
                                         BranchAddress = brn.BranchAddress,
                                         BankID = bnk.BankID,
                                         BankName = bnk.BankName
                                     }).ToListAsync(cancellationToken);
                return rtnList;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }

        public async Task<List<SelectListItem>>DDLGetBranchList(int bankID, CancellationToken cancellationToken)
        {
            var rtnList = await accDbContext.CBM_Branch.Where(b => b.BankID == bankID && b.IsActive == true && b.IsRemoved == false)
                .Select(b => new SelectListItem()
                {
                    Text = b.BranchName,
                    Value = b.BranchID.ToString()
                }).ToListAsync(cancellationToken);
            return rtnList;
        }
    }
}
