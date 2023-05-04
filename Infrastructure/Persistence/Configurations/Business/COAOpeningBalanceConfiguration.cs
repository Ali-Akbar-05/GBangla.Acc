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
    public class COAOpeningBalanceConfiguration : IEntityTypeConfiguration<COAOpeningBalance>
    {
        public void Configure(EntityTypeBuilder<COAOpeningBalance> builder)
        {
            builder.ToTable("COAOpeningBalance", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
