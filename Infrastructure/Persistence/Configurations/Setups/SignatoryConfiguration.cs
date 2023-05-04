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
    public class SignatoryConfiguration : IEntityTypeConfiguration<Signatory>
    {
        public void Configure(EntityTypeBuilder<Signatory> builder)
        {
            builder.ToTable("Signatory", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}
