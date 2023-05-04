using Domain.Entities.GBAcc.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Business
{
    public class CBM_Relate_ECF_RFP_CHQ_VoucherConfiguration : IEntityTypeConfiguration<CBM_Relate_ECF_RFP_CHQ_Voucher>
    {
        public void Configure(EntityTypeBuilder<CBM_Relate_ECF_RFP_CHQ_Voucher> builder)
        {
            builder.ToTable("CBM_Relate_ECF_RFP_CHQ_Voucher", "Business");
            builder.HasKey(b => b.ID);
        }
    }
}
