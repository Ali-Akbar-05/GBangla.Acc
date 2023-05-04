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
    public class APM_Invoice_DetailConfiguration : IEntityTypeConfiguration<APM_Invoice_Detail>
    {
        public void Configure(EntityTypeBuilder<APM_Invoice_Detail> builder)
        {
            builder.ToTable("APM_Invoice_Detail", "Business");
            builder.HasKey(b => b.InvoiceDetailID);
        }
    }
}
