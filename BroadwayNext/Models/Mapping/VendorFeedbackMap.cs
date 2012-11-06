using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorFeedbackMap : EntityTypeConfiguration<VendorFeedback>
    {
        public VendorFeedbackMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorFeedbackID);

            // Properties
            this.Property(t => t.FeedbackSubject)
                .HasMaxLength(50);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorFeedbacks");
            this.Property(t => t.VendorFeedbackID).HasColumnName("VendorFeedbackID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.FeedbackSubject).HasColumnName("FeedbackSubject");
            this.Property(t => t.Feedback).HasColumnName("Feedback");
            this.Property(t => t.Ratings).HasColumnName("Ratings");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorFeedbacks)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
