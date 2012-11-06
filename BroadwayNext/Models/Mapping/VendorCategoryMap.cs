using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorCategoryMap : EntityTypeConfiguration<VendorCategory>
    {
        public VendorCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorCategoryID);

            // Properties
            this.Property(t => t.VendorType)
                .HasMaxLength(50);

            this.Property(t => t.inputby)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorCategory");
            this.Property(t => t.VendorCategoryID).HasColumnName("VendorCategoryID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorType).HasColumnName("VendorType");
            this.Property(t => t.MasterType).HasColumnName("MasterType");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.inputby).HasColumnName("inputby");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorCategories)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
