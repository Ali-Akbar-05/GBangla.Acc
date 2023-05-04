using Application.Contracts.GBAcc.Business.POInfo.Queries.DataResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class POInfoService : IPOInfoService
    {
        private readonly IPOInfoRepository _poInfoRepository;

        public POInfoService(IPOInfoRepository poInfoRepository)
        {
            _poInfoRepository = poInfoRepository;
        }
        public async Task<List<POForAdvanceDRM>> GetPOForAdvance(int SupplierID, CancellationToken cancellationToken)
        {
            return await _poInfoRepository.GetPOForAdvance(SupplierID,cancellationToken);
        }
    }
}
