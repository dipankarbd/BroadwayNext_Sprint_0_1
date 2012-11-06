using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorRemitToMap : EntityTypeConfiguration<VendorRemitTo>
    {
        public VendorRemitToMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorRemitToID);

            // Properties
            this.Property(t => t.Company)
                .HasMaxLength(100);

            this.Property(t => t.RemitType)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(100);

            this.Property(t => t.Address2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.State)
                .HasMaxLength(10);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.Province)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Contact)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorRemitTo");
            this.Property(t => t.VendorRemitToID).HasColumnName("VendorRemitToID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.RemitType).HasColumnName("RemitType");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorRemitToes)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
