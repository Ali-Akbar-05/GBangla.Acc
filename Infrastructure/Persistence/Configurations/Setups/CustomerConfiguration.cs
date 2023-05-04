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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Setups")
                 .HasKey(l => l.CustomerID);
            builder.Property(p => p.CustomerName).IsRequired();
            builder.HasMany(v => v.CustomerDetail).WithOne(l => l.Customer).HasForeignKey(b => b.CustomerID).HasPrincipalKey(s=>s.CustomerID);
            builder.HasMany(v => v.CustomerBankInfo).WithOne(l => l.Customer).HasForeignKey(b => b.CustomerID).HasPrincipalKey(s=>s.CustomerID);


        }
    }
}
