using Domain.Entities.GBAcc.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Setups
{
    public class CurrencyDetailConfiguration : IEntityTypeConfiguration<CurrencyDetail>
    {
        public void Configure(EntityTypeBuilder<CurrencyDetail> builder)
        {
            builder.ToTable("CurrencyDetail", "Setups")
                .HasKey(b => b.ID);
            builder.Property(l => l.RateInBDT).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.CurrencyID).IsRequired();
        }
    }
}
