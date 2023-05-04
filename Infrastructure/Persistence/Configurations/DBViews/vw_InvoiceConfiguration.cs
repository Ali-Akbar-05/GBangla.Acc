using Domain.Entities.GBAcc.Views.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.DBViews
{
    public class VW_InvoiceConfiguration : IEntityTypeConfiguration<vw_Invoice>
    {
        public void Configure(EntityTypeBuilder<vw_Invoice> builder)
        {
            builder.ToTable("vw_Invoice", "Business");
            builder.HasNoKey();
        }
    }
}
