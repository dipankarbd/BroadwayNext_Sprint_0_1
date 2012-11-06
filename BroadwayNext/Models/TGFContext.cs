using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using BroadwayNextWeb.Models.Mapping;

namespace BroadwayNextWeb.Models
{
    public class TGFContext : DbContext
    {
        static TGFContext()
        {
            Database.SetInitializer<TGFContext>(null);
        }

        public TGFContext()
            : base("Name=TGFContext")
        {
        }
        public ObjectContext ObjectContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTaxable> StateTaxables { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TerminationReason> TerminationReasons { get; set; }
        public DbSet<VendorCategory> VendorCategories { get; set; }
        public DbSet<VendorContact> VendorContacts { get; set; }
        public DbSet<VendorFeedback> VendorFeedbacks { get; set; }
        public DbSet<VendorGrade> VendorGrades { get; set; }
        public DbSet<VendorInsurance> VendorInsurances { get; set; }
        public DbSet<VendorInsuranceType> VendorInsuranceTypes { get; set; }
        public DbSet<VendorNote> VendorNotes { get; set; }
        public DbSet<VendorRemitTo> VendorRemitToes { get; set; }
        public DbSet<VendorRemitToType> VendorRemitToTypes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Vendors_Audit> Vendors_Audit { get; set; }
        public DbSet<VendorShipTo> VendorShipToes { get; set; }
        public DbSet<VendorsSearch> VendorsSearches { get; set; }
        public DbSet<VendorTermination> VendorTerminations { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DivisionMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new StateTaxableMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TerminationReasonMap());
            modelBuilder.Configurations.Add(new VendorCategoryMap());
            modelBuilder.Configurations.Add(new VendorContactMap());
            modelBuilder.Configurations.Add(new VendorFeedbackMap());
            modelBuilder.Configurations.Add(new VendorGradeMap());
            modelBuilder.Configurations.Add(new VendorInsuranceMap());
            modelBuilder.Configurations.Add(new VendorInsuranceTypeMap());
            modelBuilder.Configurations.Add(new VendorNoteMap());
            modelBuilder.Configurations.Add(new VendorRemitToMap());
            modelBuilder.Configurations.Add(new VendorRemitToTypeMap());
            modelBuilder.Configurations.Add(new VendorMap());
            modelBuilder.Configurations.Add(new Vendors_AuditMap());
            modelBuilder.Configurations.Add(new VendorShipToMap());
            modelBuilder.Configurations.Add(new VendorsSearchMap());
            modelBuilder.Configurations.Add(new VendorTerminationMap());
            modelBuilder.Configurations.Add(new VendorTypeMap());
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        
    }
}
