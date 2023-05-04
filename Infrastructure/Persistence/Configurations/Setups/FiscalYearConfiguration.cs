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
    public class FiscalYearConfiguration : IEntityTypeConfiguration<FiscalYear>
    {
        public void Configure(EntityTypeBuilder<FiscalYear> builder)
        {
            builder.ToTable("FiscalYear", "Setups");
            builder.HasKey(b => b.StartDay);
        }
    }
}
