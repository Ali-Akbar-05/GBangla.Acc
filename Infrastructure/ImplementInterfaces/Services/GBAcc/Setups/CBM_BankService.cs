using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel;
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
    public class CBM_BankService : ICBM_BankService
    {
        private readonly ICBM_BankRepository _cbm_BankRepository;
        private readonly IMapper _mapper;
        public CBM_BankService(ICBM_BankRepository cbm_BankRepository, IMapper mapper)
        {
            _cbm_BankRepository = cbm_BankRepository;
            _mapper = mapper;
        }

        public async Task<RResult> BankDataDelete(int bankID)
        {
            return await _cbm_BankRepository.BankDataDelete(bankID);
        }

        public async Task<List<SelectListItem>> DDLGetBankList(int companyID, CancellationToken cancellationToken)
        {
            return await _cbm_BankRepository.DDLGetBankList(companyID,cancellationToken);
        }

        public async Task<List<CBM_BankResponseModel>> GetCBMBankList(CancellationToken cancellationToken)
        {
            return await _cbm_BankRepository.GetCBMBankList(cancellationToken);
        }

        public async Task<RResult> SaveCBMBank(CBM_BankDTM model, CancellationToken cancellationToken)
        {
            RResult oResult = new RResult();
            var dbEntry = _mapper.Map<CBM_BankDTM, CBM_Bank>(model);
            var rtnData = await _cbm_BankRepository.InsertAsync(dbEntry,true);
            oResult.result = 1;
            oResult.succeeded = true;
            oResult.message = "Successfully data insert";
            return oResult;
        }

        public  async Task<RResult> UpdateCBMBank(CBM_BankDTM model,CancellationToken cancellationToken)
        {
            RResult oResult = new RResult();
            var bankObj = await _cbm_BankRepository.FindAsync(b=>b.BankID==model.BankID && b.IsActive==true && b.IsRemoved==false, cancellationToken);
            if (bankObj !=null)
            {
                bankObj.BankID = model.BankID;
                bankObj.BankName = model.BankName;
                bankObj.CompanyID = model.CompanyID;
                bankObj.Abbreviation = model.Abbreviation;
                var rtnData = _cbm_BankRepository.UpdateAsync(bankObj, true);
                oResult.result = 1;
                oResult.succeeded = true;
                oResult.message = "Successfully data Update";
            }
            else
            {
                oResult.result = 0;
                oResult.message = "Required Valid Data";
            }
           
           
            return  oResult;
        }
    }
}
