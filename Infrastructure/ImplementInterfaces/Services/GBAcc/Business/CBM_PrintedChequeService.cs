using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using AutoMapper;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class CBM_PrintedChequeService : ICBM_PrintedChequeService
    {
        private readonly ICBM_PrintedChequeRepository cBM_PrintedChequeRepository;
        private readonly IMapper mapper;

        public CBM_PrintedChequeService(ICBM_PrintedChequeRepository _cBM_PrintedChequeRepository,IMapper _mapper)
        {
            cBM_PrintedChequeRepository = _cBM_PrintedChequeRepository;
            mapper = _mapper;
        }
        public async Task<List<PrintedChequesResponseModel>> GetCBM_PrintedCheques(PrintedChequesRequestModel model, CancellationToken cancellationToken)
        {
            return await cBM_PrintedChequeRepository.GetCBM_PrintedCheques(model, cancellationToken);
        }

        public async Task<RResult> UpdatePrintedCheque(List<CBM_PrintedChequeDTM> model)
        {
            var dbprintedCheque = mapper.Map<List<CBM_PrintedChequeDTM>, List<CBM_PrintedCheque>>(model);

            return await cBM_PrintedChequeRepository.UpdatePrintedCheque(dbprintedCheque);
        }
    }
}
