using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Entities.GBAcc.Views.Business;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class vw_CustomerWiseIssueRepository : GenericRepository<vw_CustomerWiseIssue>, Ivw_CustomerWiseIssueRepository
    {
        private readonly GBAccDbContext dbcon;

        public vw_CustomerWiseIssueRepository(GBAccDbContext _dbcon)
            : base(_dbcon)
        {
            dbcon = _dbcon;

        }
        public async Task<List<SelectListItem>> DDLCustomerWiseIssue(int customerID, DateTime DateFrom, DateTime DateTo, string predict, CancellationToken cancellationToken)
        {
            var query = dbcon.vw_CustomerWiseIssue.Where(x => x.CustomerID == customerID && x.IssueDate>=DateFrom && x.IssueDate<=DateTo);

            if (!string.IsNullOrEmpty(predict))
            {
                query = query.Where(b => b.IssueNo.Contains(predict));
            }
            var data = await query.Select(s => new SelectListItem()
            {
                Text = s.IssueNo,
                Value = s.IssueMID.ToString()
            }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
