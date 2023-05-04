using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Customers.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
   public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<RResult> CustomerSave(Customer model);
        Task<List<CustomerResponseModel>> GetCustomerList(CancellationToken cancellationToken);
        Task<Customer> GetCustomerByCustomerID(int customerID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLCustomer(string predict, CancellationToken cancellationToken);
    }
}
