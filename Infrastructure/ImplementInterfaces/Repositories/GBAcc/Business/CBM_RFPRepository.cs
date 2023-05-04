using Application.Common.CommonModels;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
  public  class CBM_RFPRepository:GenericRepository<CBM_RFP>, ICBM_RFPRepository
    {
        private GBAccDbContext accDbContext;
        public CBM_RFPRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

        public async Task<string> GetRFPNumber(int locationID,int businessID,int CompanyID,DateTime rfpDate)
        {
            var rFPInitial = "RFP";
            var rFPNumber = "";
            var locationInitial = (await accDbContext.Location.Where(b => b.SrNum == locationID && b.IsActive==true && b.IsRemoved==false).FirstAsync()).LocationInitials;
           
            var  rfpYear = rfpDate.Year.ToString().Substring(2);

            //long? maxId = await accDbContext.CBM_RFP.Where(b => b.LocationID == locationID 
            //&& b.BusinessID == businessID 
            //&& b.RFPDate.Year==rfpDate.Year
            //&& b.CompanyID == CompanyID && b.IsRemoved==false).MaxAsync(l => l.RFPID);

            long maxId = 0;
            var dbCBMRfp = await accDbContext.CBM_RFP.Where(b => b.LocationID == locationID
                  && b.BusinessID == businessID
                  && b.RFPDate.Year == rfpDate.Year
                  && b.CompanyID == CompanyID && b.IsRemoved == false).FirstOrDefaultAsync();
            if (dbCBMRfp == null)
            {
                maxId = 1;
            }
            else
            {
                 maxId = await accDbContext.CBM_RFP.Where(b => b.LocationID == locationID
                  && b.BusinessID == businessID
                  && b.CompanyID == CompanyID && b.IsRemoved == false).MaxAsync(B=>B.RFPID);
                maxId +=1;
            }

            rFPNumber = $"{rFPInitial}\\{locationInitial}\\{rfpYear}\\{maxId.ToString("000000")}";
            return rFPNumber;
        }

       

    }
}
