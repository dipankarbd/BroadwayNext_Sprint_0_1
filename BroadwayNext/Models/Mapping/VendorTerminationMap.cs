using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorTerminationMap : EntityTypeConfiguration<VendorTermination>
    {
        public VendorTerminationMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorTerminationID);

            // Properties
            this.Property(t => t.TerminatedBy)
                .HasMaxLength(50);

            this.Property(t => t.Rehire)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorTermination");
            this.Property(t => t.VendorTerminationID).HasColumnName("VendorTerminationID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.TerminationDate).HasColumnName("TerminationDate");
            this.Property(t => t.TerminationEffDate).HasColumnName("TerminationEffDate");
            this.Property(t => t.TerminatedBy).HasColumnName("TerminatedBy");
            this.Property(t => t.TerminationReason).HasColumnName("TerminationReason");
            this.Property(t => t.Rehire).HasColumnName("Rehire");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasOptional(t => t.Division1)
                .WithMany(t => t.VendorTerminations)
                .HasForeignKey(d => d.Division);
            this.HasOptional(t => t.TerminationReason1)
                .WithMany(t => t.VendorTerminations)
                .HasForeignKey(d => d.TerminationReason);
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorTerminations)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
