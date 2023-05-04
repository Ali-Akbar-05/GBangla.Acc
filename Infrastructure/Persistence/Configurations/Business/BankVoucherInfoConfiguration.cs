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
    public class BankVoucherInfoConfiguration : IEntityTypeConfiguration<BankVoucherInfo>
    {
        public void Configure(EntityTypeBuilder<BankVoucherInfo> builder)
        {
            builder.ToTable("BankVoucherInfo", "Business");
            builder.HasKey(b => new {b.VoucherID,b.AccountID });
        }
    }
}
