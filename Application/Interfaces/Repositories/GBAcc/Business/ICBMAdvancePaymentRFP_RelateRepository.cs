using Application.Common.CommonModels;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
   public interface ICBMAdvancePaymentRFP_RelateRepository :IGenericRepository<CBMAdvancePaymentRFP_Relate>
    {
        Task<RResult> SaveList(List<CBMAdvancePaymentRFP_Relate> model);
    }
}
