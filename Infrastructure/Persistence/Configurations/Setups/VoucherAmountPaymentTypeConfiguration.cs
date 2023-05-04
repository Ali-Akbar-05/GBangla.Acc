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
    public class VoucherAmountPaymentTypeConfiguration : IEntityTypeConfiguration<VoucherAmountPaymentType>
    {
        public void Configure(EntityTypeBuilder<VoucherAmountPaymentType> builder)
        {
            builder.ToTable("VoucherAmountPaymentType", "Setups");
            builder.HasKey(b => b.PaymentTypeID);
        }
    }
}
