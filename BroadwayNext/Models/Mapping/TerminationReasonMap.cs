using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class TerminationReasonMap : EntityTypeConfiguration<TerminationReason>
    {
        public TerminationReasonMap()
        {
            // Primary Key
            this.HasKey(t => t.TerminationReasonID);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TerminationReason");
            this.Property(t => t.TerminationReasonID).HasColumnName("TerminationReasonID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
        }
    }
}
