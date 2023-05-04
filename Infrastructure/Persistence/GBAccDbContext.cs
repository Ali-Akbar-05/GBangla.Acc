using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Business;
using Domain.Entities.GBAcc.Setups;
using Domain.Entities.GBAcc.Views.Business;
using Domain.Entities.GBAcc.Views.Setups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class GBAccDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;
        public GBAccDbContext(DbContextOptions<GBAccDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime, IDomainEventService domainEventService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
            _domainEventService = domainEventService;
        }
        #region Setups
        public DbSet<Payment_Type> Payment_Type { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<BasicCOA> BasicCOA { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<CBM_Bank> CBM_Bank { get; set; }
        public DbSet<CBM_Branch> CBM_Branch { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyDetail> CurrencyDetail { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierDetail> SupplierDetail { get; set; }
        public DbSet<SupplierBankInfo> SupplierBankInfo { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerDetail> CustomerDetail { get; set; }
        public DbSet<CustomerBankInfo> CustomerBankInfo { get; set; }
        public DbSet<FiscalYear> FiscalYear { get; set; }
        public DbSet<VoucherTypes> VoucherTypes { get; set; }
        public DbSet<CBMInstrumentType> CBMInstrumentType { get; set; }
        public DbSet<VoucherAmountPaymentType> VoucherAmountPaymentType { get; set; }
        public DbSet<GeneralConfiguration> GeneralConfiguration { get; set; }
        public DbSet<VoucherStatus> VoucherStatus { get; set; }
        public DbSet<CBM_BankAccount> CBM_BankAccount { get; set; }
        public DbSet<BankContactInfo> BankContactInfo { get; set; }
        public DbSet<OpeningBalances> OpeningBalances { get; set; }
        public DbSet<LedgerBalanceIncomeTaxPercent> LedgerBalanceIncomeTaxPercent { get; set; }
        public DbSet<Signatory> Signatory { get; set; }
        public DbSet<ChequeSignatoryMaster> ChequeSignatoryMaster { get; set; }
        public DbSet<CBMChequeStatus> CBMChequeStatus { get; set; }
        public DbSet<CBM_AcountType> CBM_AcountType { get; set; }
        public DbSet<CBM_PrintedChequeStatus> CBM_PrintedChequeStatus { get; set; }

        #endregion Setups

        #region Business
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<VoucherDetail> VoucherDetail { get; set; }
        public DbSet<CBMAdvancePayment> CBMAdvancePayment { get; set; }
        public DbSet<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        public DbSet<APM_Invoice_Main> APM_Invoice_Main { get; set; }
        public DbSet<APM_Invoice_Detail> APM_Invoice_Detail { get; set; }
        public DbSet<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }
        public DbSet<COAOpeningBalance> COAOpeningBalance { get; set; }
        public DbSet<CBMChequeBook> CBMChequeBook { get; set; }
        public DbSet<CBMCheque> CBMCheque { get; set; }
        public DbSet<POAdvancePayment> POAdvancePayment { get; set; }


        public DbSet<CBM_RFP> CBM_RFP { get; set; }
        public DbSet<CBM_RFP_Detail> CBM_RFP_Detail { get; set; }
        public DbSet<PaymentCostSheet> PaymentCostSheet { get; set; }
        public DbSet<CBMAdvancePaymentRFP_Relate> CBMAdvancePaymentRFP_Relate { get; set; }
        public DbSet<CBM_Relate_ECF_RFP_CHQ_Voucher> CBM_Relate_ECF_RFP_CHQ_Voucher { get; set; }
        public DbSet<CBM_PrintedCheque> CBM_PrintedCheque { get; set; }

        #endregion

        #region Views
        public DbSet<vw_BasicCOA> vw_BasicCOA { get; set; }
        public DbSet<vw_VoucherMD> vw_VoucherMD { get; set; }
        public DbSet<vw_Invoice> vw_Invoice { get; set; }
        public DbSet<vw_CustomerWiseIssue> vw_CustomerWiseIssue { get; set; }

        #endregion
        #region Audit Trace
        public DbSet<AuditTrace> AuditTrace { get; set; }
        #endregion

        #region Functions
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;
                        entry.Entity.IsRemoved = false;
                        entry.Entity.CreatedBy = _currentUserService.UserID;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserID;
                        entry.Entity.LastModifiedDate = _dateTime.Now;
                        break;
                }
            }

            try
            {
                var auditTrace = OnBeforeSaveChanges();
                int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                await OnAfterSaveChanges(auditTrace);

                await DispatchEvents(cancellationToken);

                return result;
            }
            catch (Exception e)
            {
                var message = e.InnerException.Message;
                if (!string.IsNullOrEmpty(message))
                {
                    message = e.Message;
                }

                throw new Exception(message);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            #region Setups
            builder.Entity<Location>()
                    .ToTable("Location", "Setups");
            builder.Entity<Levels>()
                  .ToTable("Levels", "Setups");
            builder.Entity<BasicCOA>()
                  .ToTable("BasicCOA", "Setups")
                  .HasKey(d => d.AccID);

            #region BasicCoa
            builder.Entity<BasicCOA>().HasOne(l => l.Supplier).WithOne(s => s.BasicCOA)
                .HasForeignKey<Supplier>(b => b.SupplierID);
            builder.Entity<BasicCOA>().HasOne(l => l.Customer).WithOne(s => s.BasicCOA)
                .HasForeignKey<Customer>(b => b.CustomerID); ;
            #endregion BasicCoa

            builder.Entity<CompanyInfo>()
                  .ToTable("CompanyInfo", "Setups");
            builder.Entity<CBM_Bank>()
                  .ToTable("CBM_Bank", "Setups");
            builder.Entity<CBM_Branch>()
               .ToTable("CBM_Branch", "Setups");
            builder.Entity<Currency>()
             .ToTable("Currency", "Setups");

            #region Supplier
            builder.Entity<Supplier>()
           .ToTable("Supplier", "Setups")
           .HasKey(b => b.SupplierID);

            //builder.Entity<Supplier>()
            //    .HasOne<BasicCOA>()
            builder.Entity<Supplier>().HasMany(v => v.SupplierDetail).WithOne(l => l.Supplier)
           .HasForeignKey(s => s.SupplierID);
            builder.Entity<Supplier>().HasMany(v => v.SupplierBankInfo).WithOne(d => d.Supplier)
            .HasForeignKey(w => w.SupplierID);

            builder.Entity<SupplierDetail>()
            .ToTable("SupplierDetail", "Setups")
            .HasKey(b => b.ID);


            builder.Entity<SupplierBankInfo>()
           .ToTable("SupplierBankInfo", "Setups")
           .HasKey(b => b.ID);

            #endregion Supplier

            //
            #endregion

            #region View Setups
            
            builder.Entity<vw_BasicCOA>()
            .ToTable("vw_BasicCOA", "Setups")
            .HasNoKey();

            #endregion
     



        }
        private async Task DispatchEvents(CancellationToken cancellationToken)
        {
            var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var domainEvent in domainEventEntities)
            {
                await _domainEventService.Publish(domainEvent);
            }
        }
        #endregion

        #region Audit Trace
        private List<AuditTraceEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditTraceEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditTrace || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditTraceEntry(entry);
                auditEntry.TableName = entry.Metadata.GetTableName(); // EF Core 3.1: entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    // The following condition is ok with EF Core 2.2 onwards.
                    // If you are using EF Core 2.1, you may need to change the following condition to support navigation properties: https://github.com/dotnet/efcore/issues/17700
                    // if (property.IsTemporary || (entry.State == EntityState.Added && property.Metadata.IsForeignKey()))
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditTrace.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }
        private Task OnAfterSaveChanges(List<AuditTraceEntry> auditEntries)
        {
            try
            {
                if (auditEntries == null || auditEntries.Count == 0)
                    return Task.CompletedTask;

                foreach (var auditEntry in auditEntries)
                {
                    // Get the final value of the temporary properties
                    foreach (var prop in auditEntry.TemporaryProperties)
                    {
                        if (prop.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                        else
                        {
                            auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                    }

                    // Save the Audit entry
                    AuditTrace.Add(auditEntry.ToAudit());
                }
            }
            catch (Exception e)
            {
                var aaa = e.Message;
            }
            return SaveChangesAsync();
        }
        #endregion
    }
}
