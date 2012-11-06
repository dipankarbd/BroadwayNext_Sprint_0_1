using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorGradeMap : EntityTypeConfiguration<VendorGrade>
    {
        public VendorGradeMap()
        {
            // Primary Key
            this.HasKey(t => t.GradeID);

            // Properties
            this.Property(t => t.Grade)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorGrades");
            this.Property(t => t.GradeID).HasColumnName("GradeID");
            this.Property(t => t.Grade).HasColumnName("Grade");
        }
    }
}
