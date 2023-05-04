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
    public class CBM_PrintedChequeStatusConfiguration : IEntityTypeConfiguration<CBM_PrintedChequeStatus>
    {
        public void Configure(EntityTypeBuilder<CBM_PrintedChequeStatus> builder)
        {
            builder.ToTable("CBM_PrintedChequeStatus", "Setups");
            builder.HasKey(b => b.StatusID);
        }
    }
}
