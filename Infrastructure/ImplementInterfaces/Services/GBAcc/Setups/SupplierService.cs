using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Constants;
using Domain.Entities.GBAcc.Setups;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;
        private readonly IBasicCOAService basicCOAService;
        private readonly ICurrentUserService currentUserService;
        private readonly IBasicCOARepository basicCOARepository;
        private readonly ISupplierDetailRepository supplierDetailRepository;
        private readonly ISupplierBankInfoRepository supplierBankInfoRepository;

        public SupplierService(ISupplierRepository _supplierRepository, IMapper _mapper
            , IBasicCOAService _basicCOAService, ICurrentUserService _currentUserService,IBasicCOARepository _basicCOARepository
            , ISupplierDetailRepository _supplierDetailRepository, ISupplierBankInfoRepository _supplierBankInfoRepository)
        {
            supplierRepository = _supplierRepository;
            mapper = _mapper;
            basicCOAService = _basicCOAService;
            currentUserService = _currentUserService;
            basicCOARepository = _basicCOARepository;
            supplierDetailRepository = _supplierDetailRepository;
            supplierBankInfoRepository = _supplierBankInfoRepository;
        }

        public async Task<SupplierDTM> GetSupplierBySupplierID(int supplierID, CancellationToken cancellationToken)
        {
            var dbmodel = await supplierRepository.GetSupplierBySupplierID(supplierID, cancellationToken);
            var supplierDTM = mapper.Map<Supplier, SupplierDTM>(dbmodel);
            return supplierDTM;
        }

        public IQueryable<SupplierResponseModel> GetSupplierList()
        {
            return  supplierRepository.GetSupplierList();
        }

        public async Task<RResult> SupplierSave(SupplierDTM model)
        {
            var basicCoa = new BasicCOA
            {
                AccName = model.CompanyName,
                ParentID = model.ParentID,
                CompanyID = currentUserService.CompanyID,
                LevelID = (int)enum_AccLevels.Item,
            };
            var dbSupplier = mapper.Map<SupplierDTM, Supplier>(model);
            var saveItemCoa = await basicCOAService.SaveBasicCoa(basicCoa);
            if (saveItemCoa.result==1)
            {
                dbSupplier.SupplierID = (int)saveItemCoa.objectID;
                dbSupplier.SupplierCode = saveItemCoa.objectCode.ToString();
                return await supplierRepository.SupplierSave(dbSupplier);
              
            }
            else
            {
                return saveItemCoa;
            }

        }

        public async Task<RResult> SupplierUpdate(SupplierDTM model ,CancellationToken cancellationToken)
        {

            // var dbBasicCoa = await basicCOARepository.GetBasicCOAByAccID(model.SupplierID);
            BasicCOA dbBasicCoa = new BasicCOA(); 
            dbBasicCoa = await basicCOAService.GetBasicCOAByID(model.SupplierID);
            dbBasicCoa.AccName = model.CompanyName;
        
            var UpdateBasicCoa = await basicCOAService.UpdateBasicCoa(dbBasicCoa);
            if (UpdateBasicCoa.result == 1)
            {
                var result = new RResult();
                var dbSupplier = await supplierRepository.GetByIdAsync(model.SupplierID);
                dbSupplier.CompanyName = model.CompanyName;
                dbSupplier.Address = model.Address;
                dbSupplier.TelephoneNumber = model.TelephoneNumber;
                dbSupplier.MobileNumber = model.MobileNumber;
                dbSupplier.FaxNumber = model.FaxNumber;
                dbSupplier.Email = model.Email;
                dbSupplier.SalesTaxRegNumber = model.SalesTaxRegNumber;
                dbSupplier.NTNNumber = model.NTNNumber;
                dbSupplier.Comments = model.Comments;
               await supplierRepository.UpdateAsync(dbSupplier, true);
                foreach (var details in model.SupplierDetail)
                {
                    
                    if (details.ID > 0)
                    {
                        var dbSupplierDetails = await GetSupplierDetailsData(details);
                        await supplierDetailRepository.UpdateAsync(dbSupplierDetails, true);
                    }
                    else
                    {
                        var dbSupplierDetails = await GetSupplierDetailsData(details);
                        await supplierDetailRepository.InsertAsync(dbSupplierDetails, true);
                    }
                }
                foreach (var bankInfo in model.SupplierBankInfo)
                {
                    if (bankInfo.ID > 0)
                    {
                        var dbSupplierBankInfo = await GetSupplierBankInfoData(bankInfo);
                        await supplierBankInfoRepository.UpdateAsync(dbSupplierBankInfo, true);
                    }
                    else
                    {
                        var dbSupplierBankInfo = await GetSupplierBankInfoData(bankInfo);
                        await supplierBankInfoRepository.InsertAsync(dbSupplierBankInfo, true);
                    }
                }
                result.result = 1;
                result.message = ReturnMessage.UpdateMessage;
                return result;

            }
            else
            {
                return UpdateBasicCoa;
            }

           
        }


        private async Task<SupplierDetail> GetSupplierDetailsData( SupplierDetailDTM details)
        {
            
            if (details.ID>0)
            {
               var dbObject= await supplierDetailRepository.GetByIdAsync(details.ID);
                dbObject.ContactPerson = details.ContactPerson;
                dbObject.Designation = details.Designation;
                dbObject.Division = details.Division;
                dbObject.CellNumber = details.CellNumber;
                dbObject.ContactEmail = details.ContactEmail;
                return dbObject;
            }
            else
            {
                var dbObject = new SupplierDetail();
                dbObject.ContactPerson = details.ContactPerson;
                dbObject.Designation = details.Designation;
                dbObject.Division = details.Division;
                dbObject.CellNumber = details.CellNumber;
                dbObject.ContactEmail = details.ContactEmail;
                dbObject.SupplierID = details.SupplierID;
                return dbObject;
            }
        }
       
        private async Task<SupplierBankInfo> GetSupplierBankInfoData(SupplierBankInfoDTM bankInfo )
        {
            if (bankInfo.ID>0)
            {
                var dbObject = await supplierBankInfoRepository.GetByIdAsync(bankInfo.ID);
                dbObject.BankName = bankInfo.BankName;
                dbObject.BranchName = bankInfo.BranchName;
                dbObject.AccountNumber = bankInfo.AccountNumber;
                dbObject.RoutingNo = bankInfo.RoutingNo;
                dbObject.SwiftNo = bankInfo.SwiftNo;
                return dbObject;
            }
            else
            {
                var dbObject = new SupplierBankInfo();
                dbObject.BankName = bankInfo.BankName;
                dbObject.BranchName = bankInfo.BranchName;
                dbObject.AccountNumber = bankInfo.AccountNumber;
                dbObject.RoutingNo = bankInfo.RoutingNo;
                dbObject.SwiftNo = bankInfo.SwiftNo;
                dbObject.SupplierID = bankInfo.SupplierID;
                return dbObject;
            }
            
        }

        public async Task<List<SelectListItem>> GetDDLSupplierList(string Predict, CancellationToken cancellationToken)
        {
            return await supplierRepository.GetDDLSupplierList(Predict, cancellationToken);
        }
    }
}
