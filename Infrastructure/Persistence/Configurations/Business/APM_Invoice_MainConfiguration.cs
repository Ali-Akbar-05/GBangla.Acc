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
    public class APM_Invoice_MainConfiguration : IEntityTypeConfiguration<APM_Invoice_Main>
    {
        public void Configure(EntityTypeBuilder<APM_Invoice_Main> builder)
        {
            builder.ToTable("APM_Invoice_Main", "Business");
            builder.HasKey(b => b.InvoiceID);
            builder.HasMany(a => a.APM_Invoice_Detail).WithOne(o => o.APM_Invoice_Main)
                .HasForeignKey(f => f.InvoiceID).HasPrincipalKey(p => p.InvoiceID);
        }
    }
}
