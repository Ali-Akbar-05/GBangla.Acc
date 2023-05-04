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
    public class Payment_TypeConfiguration : IEntityTypeConfiguration<Payment_Type>
    {
        public void Configure(EntityTypeBuilder<Payment_Type> builder)
        {
            builder.ToTable("Payment_Type", "Setups");
            builder.HasKey(b => b.ID);
        }
    }
}
