using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Customers.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
  public  interface ICustomerService
    {
        Task<RResult> CustomerSave(CustomerDTM model);
        Task<RResult> CustomerUpdate(CustomerDTM model);
        Task<List<CustomerResponseModel>> GetCustomerList(CancellationToken cancellationToken);
        Task<CustomerDTM> GetCustomerByCustomerID(int customerID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLCustomer(string predict, CancellationToken cancellationToken);
    }
}
