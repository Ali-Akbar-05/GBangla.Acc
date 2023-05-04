using Domain.Entities.GBAcc.Views.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.DBViews
{
    public class vw_VoucherMDConfiguration : IEntityTypeConfiguration<vw_VoucherMD>
    {
        public void Configure(EntityTypeBuilder<vw_VoucherMD> builder)
        {
            builder.ToTable("vw_VoucherMD", "Business");
            builder.HasNoKey();
        }
    }
}
