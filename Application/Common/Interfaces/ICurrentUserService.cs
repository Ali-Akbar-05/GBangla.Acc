using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserID { get; }
        int CompanyID { get; } 
        int BusinessID { get; }
        int FiscalYear { get; }
    }
}
