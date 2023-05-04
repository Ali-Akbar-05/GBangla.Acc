using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
  public  interface ISupplierService
    {
        Task<RResult> SupplierSave(SupplierDTM model);
        Task<RResult> SupplierUpdate(SupplierDTM model,CancellationToken cancellationToken);
        IQueryable<SupplierResponseModel> GetSupplierList();
        Task<SupplierDTM> GetSupplierBySupplierID(int supplierID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLSupplierList(string Predict, CancellationToken cancellationToken);
    }
}
