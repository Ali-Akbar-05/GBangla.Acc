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
   public class LedgerBalanceIncomeTaxPercentConfiguration : IEntityTypeConfiguration<LedgerBalanceIncomeTaxPercent>
    {
        public void Configure(EntityTypeBuilder<LedgerBalanceIncomeTaxPercent> builder)
        {
            builder.ToTable("LedgerBalanceIncomeTaxPercent", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}
