using Domain.Entities.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
    public interface IChequeSignatoryMasterRepository :IGenericRepository<ChequeSignatoryMaster>, IRequest<List<SelectListItem>>
    {
        Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyID,CancellationToken cancellationToken);
    }
}
