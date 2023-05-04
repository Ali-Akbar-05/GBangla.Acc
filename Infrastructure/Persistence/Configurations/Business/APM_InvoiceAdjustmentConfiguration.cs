using Domain.Entities.GBAcc.Business;
using Domain.Entities.GBAcc.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Business
{
    public class APM_InvoiceAdjustmentConfiguration : IEntityTypeConfiguration<APM_InvoiceAdjustment>
    {
        public void Configure(EntityTypeBuilder<APM_InvoiceAdjustment> builder)
        {
            builder.ToTable("APM_InvoiceAdjustment", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
