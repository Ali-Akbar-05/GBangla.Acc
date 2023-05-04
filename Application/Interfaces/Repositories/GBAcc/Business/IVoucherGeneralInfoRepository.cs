using Application.Common.CommonModels;
using Domain.Entities.GBAcc.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
   public interface IVoucherGeneralInfoRepository:IGenericRepository<VoucherGeneralInfo>
    {
        Task<List<SelectListItem>> DDlGetPONumberByAccountID(int accountID, DateTime dateFrom, DateTime dateTo, string Predict, CancellationToken cancellationToken);
        Task<RResult> UpdateVoucherGeneral(List<VoucherGeneralInfo> model);
    }
}
