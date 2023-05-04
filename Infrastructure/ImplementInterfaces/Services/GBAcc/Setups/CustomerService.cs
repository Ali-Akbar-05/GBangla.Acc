using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Setups.CustomerBankInfos.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CustomerDetails.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Customers.Queries.RequestResponseModel;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        private readonly IBasicCOAService basicCOAService;
        private readonly ICustomerDetailRepository customerDetailRepository;
        private readonly ICustomerBankInfoRepository customerBankInfoRepository;

        public CustomerService(ICustomerRepository _customerRepository,IMapper _mapper, ICurrentUserService _currentUserService,
            IBasicCOAService _basicCOAService,ICustomerDetailRepository _customerDetailRepository,ICustomerBankInfoRepository _customerBankInfoRepository)
        {
            customerRepository = _customerRepository;
            mapper = _mapper;
            currentUserService = _currentUserService;
            basicCOAService = _basicCOAService;
            customerDetailRepository = _customerDetailRepository;
            customerBankInfoRepository = _customerBankInfoRepository;
        }
        public async Task<RResult> CustomerSave(CustomerDTM model)
        {
            var basicCoa = new BasicCOA()
            {
                AccName=model.CustomerName,
                ParentID=model.ParentID,
                CompanyID=currentUserService.CompanyID,
                LevelID= (int)enum_AccLevels.Item
            };
            var dbCustomer = mapper.Map<CustomerDTM, Customer>(model);
            var saveItemCoa = await basicCOAService.SaveBasicCoa(basicCoa);
            if (saveItemCoa.result == 1)
            {
                dbCustomer.CustomerID = (int)saveItemCoa.objectID;
                dbCustomer.CustomerCode = saveItemCoa.objectCode.ToString();
                return await customerRepository.CustomerSave(dbCustomer);

            }
            else
            {
                return saveItemCoa;
            }
        }



        public async Task<CustomerDTM> GetCustomerByCustomerID(int customerID, CancellationToken cancellationToken)
        {
            var dbCustomer = await customerRepository.GetCustomerByCustomerID(customerID, cancellationToken);
            var customerDTM = mapper.Map<Customer, CustomerDTM>(dbCustomer);
            return customerDTM;
        }

        public async Task<List<CustomerResponseModel>> GetCustomerList(CancellationToken cancellationToken)
        {
            return await customerRepository.GetCustomerList(cancellationToken);
        }
        public async Task<RResult> CustomerUpdate(CustomerDTM model)
        {

            // var dbBasicCoa = await basicCOARepository.GetBasicCOAByAccID(model.SupplierID);
            BasicCOA dbBasicCoa = new BasicCOA();
            dbBasicCoa = await basicCOAService.GetBasicCOAByID(model.CustomerID);
            dbBasicCoa.AccName = model.CustomerName;

            var UpdateBasicCoa = await basicCOAService.UpdateBasicCoa(dbBasicCoa);
            if (UpdateBasicCoa.result == 1)
            {
                var result = new RResult();
                var dbCustomer = await customerRepository.GetByIdAsync(model.CustomerID);
                dbCustomer.CustomerName = model.CustomerName;
                dbCustomer.Address = model.Address;
                dbCustomer.TelephoneNumber = model.TelephoneNumber;
                dbCustomer.MobileNumber = model.MobileNumber;
                dbCustomer.FaxNumber = model.FaxNumber;
                dbCustomer.Email = model.Email;
                dbCustomer.SalesTaxNumber = model.SalesTaxNumber;
                dbCustomer.NationalTaxNumber = model.NationalTaxNumber;
            
                await customerRepository.UpdateAsync(dbCustomer, true);
                foreach (var details in model.CustomerDetail)
                {

                    if (details.ID > 0)
                    {
                        var dbCustomerDetails = await GetSupplierDetailsData(details);
                        await customerDetailRepository.UpdateAsync(dbCustomerDetails, true);
                    }
                    else
                    {
                        var dbCustomerDetails = await GetSupplierDetailsData(details);
                        await customerDetailRepository.InsertAsync(dbCustomerDetails, true);
                    }
                }
                foreach (var bankInfo in model.CustomerBankInfo)
                {
                    if (bankInfo.ID > 0)
                    {
                        var dbCustomerBankInfo = await GetSupplierBankInfoData(bankInfo);
                        await customerBankInfoRepository.UpdateAsync(dbCustomerBankInfo, true);
                    }
                    else
                    {
                        var dbCustomerBankInfo = await GetSupplierBankInfoData(bankInfo);
                        await customerBankInfoRepository.InsertAsync(dbCustomerBankInfo, true);
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


        private async Task<CustomerDetail> GetSupplierDetailsData(CustomerDetailDTM details)
        {

            if (details.ID > 0)
            {
                var dbObject = await customerDetailRepository.GetByIdAsync(details.ID);
                dbObject.ContactPerson = details.ContactPerson;
                dbObject.Designation = details.Designation;
                dbObject.Division = details.Division;
                dbObject.CellNumber = details.CellNumber;
                dbObject.ContactEmail = details.ContactEmail;
                return dbObject;
            }
            else
            {
                var dbObject = new CustomerDetail();
                dbObject.ContactPerson = details.ContactPerson;
                dbObject.Designation = details.Designation;
                dbObject.Division = details.Division;
                dbObject.CellNumber = details.CellNumber;
                dbObject.ContactEmail = details.ContactEmail;
                dbObject.CustomerID = details.CustomerID;
                return dbObject;
            }
        }

        private async Task<CustomerBankInfo> GetSupplierBankInfoData(CustomerBankInfoDTM bankInfo)
        {
            if (bankInfo.ID > 0)
            {
                var dbObject = await customerBankInfoRepository.GetByIdAsync(bankInfo.ID);
                dbObject.BankName = bankInfo.BankName;
                dbObject.BranchName = bankInfo.BranchName;
                dbObject.AccountNumber = bankInfo.AccountNumber;
                dbObject.RoutingNo = bankInfo.RoutingNo;
                dbObject.SwiftNo = bankInfo.SwiftNo;
                return dbObject;
            }
            else
            {
                var dbObject = new CustomerBankInfo();
                dbObject.BankName = bankInfo.BankName;
                dbObject.BranchName = bankInfo.BranchName;
                dbObject.AccountNumber = bankInfo.AccountNumber;
                dbObject.RoutingNo = bankInfo.RoutingNo;
                dbObject.SwiftNo = bankInfo.SwiftNo;
                dbObject.CustomerID = bankInfo.CustomerID;
                return dbObject;
            }

        }

        public async Task<List<SelectListItem>> DDLCustomer(string predict, CancellationToken cancellationToken)
        {
            return await customerRepository.DDLCustomer(predict, cancellationToken);
        }
    }
}
