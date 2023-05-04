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
    public class CBM_BillToBillPaymentConfiguration : IEntityTypeConfiguration<CBM_BillToBillPayment>
    {
        public void Configure(EntityTypeBuilder<CBM_BillToBillPayment> builder)
        {
            builder.ToTable("CBM_BillToBillPayment", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
