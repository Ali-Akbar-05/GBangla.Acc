using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class CBM_BranchService : ICBM_BranchService
    {
        private readonly ICBM_BranchRepository cBM_BranchRepository;
        private readonly IMapper mapper;

        public CBM_BranchService(ICBM_BranchRepository _cBM_BranchRepository,IMapper _mapper)
        {
            cBM_BranchRepository = _cBM_BranchRepository;
            mapper = _mapper;
        }

        public async Task<RResult> BranchDelete(int branchID)
        {
            return await cBM_BranchRepository.BranchDelete(branchID);
        }

        public async Task<RResult> BranchSave(CBM_BranchDTM model)
        {
            var dbModel = mapper.Map<CBM_BranchDTM, CBM_Branch>(model);
            return await cBM_BranchRepository.BranchSave(dbModel);
        }

        public async Task<RResult> BranchUpdate(CBM_BranchDTM model)
        {
            var dbModel = mapper.Map<CBM_BranchDTM, CBM_Branch>(model);
            return await cBM_BranchRepository.BranchUpdate(dbModel);
        }

        public async Task<List<SelectListItem>> DDLGetBranchList(int bankID, CancellationToken cancellationToken)
        {
            return await cBM_BranchRepository.DDLGetBranchList(bankID, cancellationToken);
        }

        public async Task<List<CBM_BranchResponseModel>> GetCBMBranchList(CancellationToken cancellationToken)
        {
            return await cBM_BranchRepository.GetCBMBranchList(cancellationToken);
        }
      
    }
}
