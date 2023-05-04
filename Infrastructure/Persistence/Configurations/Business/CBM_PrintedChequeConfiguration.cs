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
    public class CBM_PrintedChequeConfiguration : IEntityTypeConfiguration<CBM_PrintedCheque>
    {
        public void Configure(EntityTypeBuilder<CBM_PrintedCheque> builder)
        {
            builder.ToTable("CBM_PrintedCheque", "Business");
            builder.HasKey(b => b.ChqID);
        }
    }
}
