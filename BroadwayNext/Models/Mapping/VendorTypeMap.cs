using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorTypeMap : EntityTypeConfiguration<VendorType>
    {
        public VendorTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorTypeID);

            // Properties
            this.Property(t => t.VendorType1)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorTypes");
            this.Property(t => t.VendorTypeID).HasColumnName("VendorTypeID");
            this.Property(t => t.VendorType1).HasColumnName("VendorType");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
        }
    }
}
