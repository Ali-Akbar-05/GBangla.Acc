using Domain.Entities.GBAcc.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Business
{
    public class CBM_RFPConfiguration : IEntityTypeConfiguration<CBM_RFP>
    {
        public void Configure(EntityTypeBuilder<CBM_RFP> builder)
        {
            builder.ToTable("CBM_RFP", "Business");
            builder.HasKey(b => b.RFPID);
            builder.HasMany(m => m.CBM_RFP_Detail).WithOne(a => a.CBM_RFP).HasForeignKey(f => f.RFPID).HasPrincipalKey(p => p.RFPID);
        }
    }
}
