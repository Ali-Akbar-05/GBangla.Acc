using Domain.Entities.GBAcc.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Business
{
    public class PaymentCostSheetConfiguration : IEntityTypeConfiguration<PaymentCostSheet>
    {
        public void Configure(EntityTypeBuilder<PaymentCostSheet> builder)
        {
            builder.ToTable("PaymentCostSheet", "Business");
            builder.HasKey(b => b.ID);
        }
    }
    
}
