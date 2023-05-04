using Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel;
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
    public class CBMChequeService : ICBMChequeService
    {
        private readonly ICBMChequeRepository cBMChequeRepository;

        public CBMChequeService(ICBMChequeRepository _cBMChequeRepository)
        {
            cBMChequeRepository = _cBMChequeRepository;
        }
        public async Task<List<CBMChequeResponseModel>> GetChequeList(int chequeBookID, CancellationToken cancellationToken)
        {
            return await cBMChequeRepository.GetChequeList(chequeBookID, cancellationToken);
        }
    }
}
