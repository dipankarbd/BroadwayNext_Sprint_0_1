using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorInsuranceMap : EntityTypeConfiguration<VendorInsurance>
    {
        public VendorInsuranceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.VendorInsuranceID, t.VendorID, t.InsuranceType });

            // Properties
            this.Property(t => t.InsuranceName)
                .HasMaxLength(50);

            this.Property(t => t.NotRequiredReason)
                .HasMaxLength(100);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorInsurance");
            this.Property(t => t.VendorInsuranceID).HasColumnName("VendorInsuranceID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.InsuranceType).HasColumnName("InsuranceType");
            this.Property(t => t.InsuranceName).HasColumnName("InsuranceName");
            this.Property(t => t.Policynum).HasColumnName("Policynum");
            this.Property(t => t.ExpiryDate).HasColumnName("ExpiryDate");
            this.Property(t => t.AdditionalInsured).HasColumnName("AdditionalInsured");
            this.Property(t => t.Not_onFile).HasColumnName("Not_onFile");
            this.Property(t => t.InsuranceNotRequired).HasColumnName("InsuranceNotRequired");
            this.Property(t => t.NotRequiredReason).HasColumnName("NotRequiredReason");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasRequired(t => t.VendorInsuranceType)
                .WithMany(t => t.VendorInsurances)
                .HasForeignKey(d => d.InsuranceType);
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorInsurances)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
