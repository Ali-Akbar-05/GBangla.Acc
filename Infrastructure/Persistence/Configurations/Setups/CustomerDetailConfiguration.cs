using Domain.Entities.GBAcc.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setups
{
    public class CustomerDetailConfiguration : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            builder.ToTable("CustomerDetail", "Setups")
                .HasKey(b => b.ID);
            //  builder.HasOne(l => l.Customer).WithMany(p => p.CustomerDetail).HasForeignKey(d => d.CustomerID);
        }
    }
}
