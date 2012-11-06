using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorRemitToTypeMap : EntityTypeConfiguration<VendorRemitToType>
    {
        public VendorRemitToTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorRemiToTypeID);

            // Properties
            this.Property(t => t.RemitToTypes)
                .HasMaxLength(50);

            this.Property(t => t.Inputby)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedby)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorRemitToTypes");
            this.Property(t => t.VendorRemiToTypeID).HasColumnName("VendorRemiToTypeID");
            this.Property(t => t.RemitToTypes).HasColumnName("RemitToTypes");
            this.Property(t => t.Inputby).HasColumnName("Inputby");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.LastModifiedby).HasColumnName("LastModifiedby");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
        }
    }
}
