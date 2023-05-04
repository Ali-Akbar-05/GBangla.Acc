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
    public class CBMChequeStatusConfiguration : IEntityTypeConfiguration<CBMChequeStatus>
    {
        public void Configure(EntityTypeBuilder<CBMChequeStatus> builder)
        {
            builder.ToTable("CBMChequeStatus", "Setups");
            builder.HasKey(b => b.ChequeStatusID);
        }
    }
}
