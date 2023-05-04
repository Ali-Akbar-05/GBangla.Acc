using Application.Contracts.GBAcc.Business.POInfo.Queries.DataResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
    public interface IPOInfoRepository 
    {
        Task<List<POForAdvanceDRM>> GetPOForAdvance(int SupplierID, CancellationToken cancellationToken);
       

    }
}
