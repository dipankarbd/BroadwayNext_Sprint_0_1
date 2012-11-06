using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorInsuranceTypeMap : EntityTypeConfiguration<VendorInsuranceType>
    {
        public VendorInsuranceTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.InsuranceTypeID);

            // Properties
            this.Property(t => t.InsuranceType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorInsuranceTypes");
            this.Property(t => t.InsuranceTypeID).HasColumnName("InsuranceTypeID");
            this.Property(t => t.InsuranceType).HasColumnName("InsuranceType");
        }
    }
}
