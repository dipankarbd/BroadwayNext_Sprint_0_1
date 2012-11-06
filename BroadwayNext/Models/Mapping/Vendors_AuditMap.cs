using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class Vendors_AuditMap : EntityTypeConfiguration<Vendors_Audit>
    {
        public Vendors_AuditMap()
        {
            // Primary Key
            this.HasKey(t => new { t.VendorAuditID, t.Vendnum });

            // Properties
            this.Property(t => t.Vendnum)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Fieldname)
                .HasMaxLength(100);

            this.Property(t => t.OldValue)
                .HasMaxLength(255);

            this.Property(t => t.NewValue)
                .HasMaxLength(255);

            this.Property(t => t.Username)
                .HasMaxLength(30);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.InputDate)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vendors_Audit");
            this.Property(t => t.VendorAuditID).HasColumnName("VendorAuditID");
            this.Property(t => t.Vendnum).HasColumnName("Vendnum");
            this.Property(t => t.Fieldname).HasColumnName("Fieldname");
            this.Property(t => t.OldValue).HasColumnName("OldValue");
            this.Property(t => t.NewValue).HasColumnName("NewValue");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifieddate).HasColumnName("LastModifieddate");
        }
    }
}
