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
    public class CustomerBankInfoConfiguration : IEntityTypeConfiguration<CustomerBankInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerBankInfo> builder)
        {
            builder.ToTable("CustomerBankInfo", "Setups")
                 .HasKey(b => b.ID);
        }
    }
}
