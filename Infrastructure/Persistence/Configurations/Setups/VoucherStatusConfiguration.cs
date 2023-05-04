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
    public class VoucherStatusConfiguration : IEntityTypeConfiguration<VoucherStatus>
    {
        public void Configure(EntityTypeBuilder<VoucherStatus> builder)
        {
            builder.ToTable("VoucherStatus", "Setups");
            builder.HasKey(b => b.StatusID);
        }
    }
}
