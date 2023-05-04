using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface ICBM_RFPService
    {
        Task<string> GetRFPNumber(int locationID, int businessID, int CompanyID,  DateTime date);
    }
}
