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
    public class CBMInstrumentTypeConfiguration : IEntityTypeConfiguration<CBMInstrumentType>
    {
        public void Configure(EntityTypeBuilder<CBMInstrumentType> builder)
        {
            builder.ToTable("CBMInstrumentType", "Setups");
            builder.HasKey(b => b.InstrumentTypeID);
        }
    }
}
