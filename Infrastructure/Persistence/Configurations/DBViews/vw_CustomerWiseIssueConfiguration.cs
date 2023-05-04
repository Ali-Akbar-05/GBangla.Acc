using Domain.Entities.GBAcc.Views.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.DBViews
{
    public class vw_CustomerWiseIssueConfiguration : IEntityTypeConfiguration<vw_CustomerWiseIssue>
    {
        public void Configure(EntityTypeBuilder<vw_CustomerWiseIssue> builder)
        {
            builder.ToTable("vw_CustomerWiseIssue", "Business");
            builder.HasNoKey();
        }
    }
}
