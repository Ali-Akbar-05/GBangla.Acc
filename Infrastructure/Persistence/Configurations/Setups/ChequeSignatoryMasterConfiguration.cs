using Domain.Entities.GBAcc.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setups
{
    public class ChequeSignatoryMasterConfiguration : IEntityTypeConfiguration<ChequeSignatoryMaster>
    {
        public void Configure(EntityTypeBuilder<ChequeSignatoryMaster> builder)
        {
            builder.ToTable("ChequeSignatoryMaster", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}

