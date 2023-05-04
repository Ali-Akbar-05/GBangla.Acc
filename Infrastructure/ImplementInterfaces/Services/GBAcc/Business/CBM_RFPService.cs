using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
  public  class CBM_RFPService: ICBM_RFPService
    {
        private readonly ICBM_RFPRepository cBM_RFPRepository;

        public CBM_RFPService(ICBM_RFPRepository _cBM_RFPRepository)
        {
            cBM_RFPRepository = _cBM_RFPRepository;
        }

        public async Task<string> GetRFPNumber(int locationID, int businessID, int CompanyID, DateTime date)
        {
            return await cBM_RFPRepository.GetRFPNumber(locationID, businessID, CompanyID, date);
        }
    }
}
