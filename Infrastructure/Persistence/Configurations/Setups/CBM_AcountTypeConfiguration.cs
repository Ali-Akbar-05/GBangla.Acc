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
    public class CBM_AcountTypeConfiguration : IEntityTypeConfiguration<CBM_AcountType>
    {
        public void Configure(EntityTypeBuilder<CBM_AcountType> builder)
        {
            builder.ToTable("CBM_AcountType", "Setups");
            builder.HasKey(b => b.AccountTypeID);
        }
    }
}
