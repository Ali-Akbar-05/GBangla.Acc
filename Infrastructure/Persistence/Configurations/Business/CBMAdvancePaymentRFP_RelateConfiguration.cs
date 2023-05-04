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
    public class CBMAdvancePaymentRFP_RelateConfiguration : IEntityTypeConfiguration<CBMAdvancePaymentRFP_Relate>
    {
        public void Configure(EntityTypeBuilder<CBMAdvancePaymentRFP_Relate> builder)
        {
            builder.ToTable("CBMAdvancePaymentRFP_Relate", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
