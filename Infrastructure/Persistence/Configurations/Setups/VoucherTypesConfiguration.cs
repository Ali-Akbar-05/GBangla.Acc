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
    public class VoucherTypesConfiguration : IEntityTypeConfiguration<VoucherTypes>
    {
        public void Configure(EntityTypeBuilder<VoucherTypes> builder)
        {
            builder.ToTable("VoucherTypes", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}
