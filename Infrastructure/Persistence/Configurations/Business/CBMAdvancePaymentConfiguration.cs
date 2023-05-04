using Domain.Entities.GBAcc.Business;
using Domain.Entities.GBAcc.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Business
{
    public class CBMAdvancePaymentConfiguration : IEntityTypeConfiguration<CBMAdvancePayment>
    {
        public void Configure(EntityTypeBuilder<CBMAdvancePayment> builder)
        {
            builder.ToTable("CBMAdvancePayment", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
