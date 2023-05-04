using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.Suppliers.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Queries
{
   public class GetSupplierListQuery:IRequest<LoadResult>
    {
        public DataSourceLoadOptions loadOptions { get; set; }
    }
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, LoadResult>
    {
        private readonly ISupplierService supplierService;

        public GetSupplierListQueryHandler(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }
        public async Task<LoadResult> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            request.loadOptions.PrimaryKey = new[] { "SupplierID" };
            request.loadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = supplierService.GetSupplierList();
            var data = await DataSourceLoader.LoadAsync(dataQuery, request.loadOptions, cancellationToken);
            return data;

        }
    }
}
