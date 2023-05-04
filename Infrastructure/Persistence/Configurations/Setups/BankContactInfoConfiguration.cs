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
    public class BankContactInfoConfiguration : IEntityTypeConfiguration<BankContactInfo>
    {
        public void Configure(EntityTypeBuilder<BankContactInfo> builder)
        {
            builder.ToTable("BankContactInfo", "Setups");
            builder.HasKey(b => b.AccountID);
        }
    }
}
