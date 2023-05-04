using Domain.Entities.GBAcc;
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
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Voucher", "Business");
            builder.HasKey(b => b.VoucherID);
            builder.Property(b => b.VoucherNumber).IsRequired();

            builder.HasMany(vd => vd.VoucherDetail).WithOne(v => v.Voucher)
                .HasForeignKey(f => f.VoucherID).HasPrincipalKey(s => s.VoucherID);

            builder.HasMany(vg => vg.VoucherGeneralInfo).WithOne(v => v.Voucher)
                .HasForeignKey(f => f.VoucherID).HasPrincipalKey(s => s.VoucherID);

            builder.HasMany(jv => jv.JournalVoucherInfo).WithOne(v => v.Voucher)
                .HasForeignKey(f => f.VoucherID).HasPrincipalKey(v => v.VoucherID);

            builder.HasMany(po => po.POAdvancePayment).WithOne(v => v.Voucher)
                .HasForeignKey(pov => pov.VoucherID);

            builder.HasOne(bv => bv.BankVoucherInfo).WithOne(v => v.Voucher)
                 .HasForeignKey<BankVoucherInfo>(b=>b.VoucherID);

            builder.HasMany(vc => vc.CBM_Relate_ECF_RFP_CHQ_Voucher).WithOne(v => v.Voucher)
                  .HasForeignKey(f => f.VoucherID).HasPrincipalKey(v => v.VoucherID);


            builder.HasMany(vc => vc.CBM_BillToBillPayment).WithOne(v => v.Voucher)
      .HasForeignKey(f => f.VoucherID).HasPrincipalKey(v => v.VoucherID);
        }
    }
}
