using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorNoteMap : EntityTypeConfiguration<VendorNote>
    {
        public VendorNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorNotesID);

            // Properties
            this.Property(t => t.NoteType)
                .HasMaxLength(50);

            this.Property(t => t.InputStatus)
                .HasMaxLength(10);

            this.Property(t => t.InputBy)
                .HasMaxLength(30);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("VendorNotes");
            this.Property(t => t.VendorNotesID).HasColumnName("VendorNotesID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.NoteType).HasColumnName("NoteType");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.InputStatus).HasColumnName("InputStatus");
            this.Property(t => t.MakePublic).HasColumnName("MakePublic");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorNotes)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
