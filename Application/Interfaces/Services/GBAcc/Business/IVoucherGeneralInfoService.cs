using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
  public  interface IVoucherGeneralInfoService
    {
        Task<List<SelectListItem>> DDlGetPONumberByAccountID(int accountID, DateTime dateFrom,DateTime dateTo, string Predict, CancellationToken cancellationToken);
    }
}
