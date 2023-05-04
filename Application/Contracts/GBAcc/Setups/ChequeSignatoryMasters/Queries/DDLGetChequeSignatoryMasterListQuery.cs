using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.ChequeSignatoryMasters.Queries
{
    public class DDLGetChequeSignatoryMasterListQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }
    public class DDLGetChequeSignatoryMasterListQueryHandler : IRequestHandler<DDLGetChequeSignatoryMasterListQuery, List<SelectListItem>>
    {
        private readonly IChequeSignatoryMasterService chequeSignatoryMasterService;

        public DDLGetChequeSignatoryMasterListQueryHandler(IChequeSignatoryMasterService _chequeSignatoryMasterService)
        {
            chequeSignatoryMasterService = _chequeSignatoryMasterService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetChequeSignatoryMasterListQuery request, CancellationToken cancellationToken)
        {
            return await chequeSignatoryMasterService.DDLChequeSignatoryMasterList(request.CompanyID, cancellationToken);
        }
    }
}
