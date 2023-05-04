using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel;
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
   public interface ISupplierRepository:IGenericRepository<Supplier>
    {
        Task<RResult> SupplierSave(Supplier model);
        IQueryable<SupplierResponseModel> GetSupplierList();
        Task<Supplier> GetSupplierBySupplierID(int supplierID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLSupplierList(string Predict, CancellationToken cancellationToken);
    }
}
