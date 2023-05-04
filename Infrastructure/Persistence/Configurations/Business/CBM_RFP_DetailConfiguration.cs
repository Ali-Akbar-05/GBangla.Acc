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
    public class CBM_RFP_DetailConfiguration : IEntityTypeConfiguration<CBM_RFP_Detail>
    {
        public void Configure(EntityTypeBuilder<CBM_RFP_Detail> builder)
        {
            builder.ToTable("CBM_RFP_Detail", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
