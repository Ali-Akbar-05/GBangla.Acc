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
    public class CBM_BankAccountConfiguration : IEntityTypeConfiguration<CBM_BankAccount>
    {
     
        public void Configure(EntityTypeBuilder<CBM_BankAccount> builder)
        {
            builder.ToTable("CBM_BankAccount", "Setups");
            builder.HasKey(b => b.BAccountID);
        }
    }
}
