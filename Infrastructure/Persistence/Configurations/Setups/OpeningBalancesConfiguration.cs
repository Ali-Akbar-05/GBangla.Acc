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
    public class OpeningBalancesConfiguration : IEntityTypeConfiguration<OpeningBalances>
    {
        public void Configure(EntityTypeBuilder<OpeningBalances> builder)
        {
            builder.ToTable("OpeningBalances", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}
