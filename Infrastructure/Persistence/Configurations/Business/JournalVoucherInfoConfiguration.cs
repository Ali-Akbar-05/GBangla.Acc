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
    public class JournalVoucherInfoConfiguration : IEntityTypeConfiguration<JournalVoucherInfo>
    {
        public void Configure(EntityTypeBuilder<JournalVoucherInfo> builder)
        {
            builder.ToTable("JournalVoucherInfo", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
