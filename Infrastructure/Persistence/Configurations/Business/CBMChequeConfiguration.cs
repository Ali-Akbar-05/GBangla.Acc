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
    public class CBMChequeConfiguration : IEntityTypeConfiguration<CBMCheque>
    {
        public void Configure(EntityTypeBuilder<CBMCheque> builder)
        {
            builder.ToTable("CBMCheque", "Business");
            builder.HasKey(b => b.ChequeID);
        }
    }
}
