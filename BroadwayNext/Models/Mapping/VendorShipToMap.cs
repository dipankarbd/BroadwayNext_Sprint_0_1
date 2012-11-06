using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorShipToMap : EntityTypeConfiguration<VendorShipTo>
    {
        public VendorShipToMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorShipToID);

            // Properties
            this.Property(t => t.Recipient)
                .HasMaxLength(100);

            this.Property(t => t.Address1)
                .HasMaxLength(100);

            this.Property(t => t.Address2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.Province)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.PhoneExt)
                .HasMaxLength(10);

            this.Property(t => t.Fax)
                .HasMaxLength(25);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.InputBy)
                .HasMaxLength(30);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("VendorShipTo");
            this.Property(t => t.VendorShipToID).HasColumnName("VendorShipToID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.Recipient).HasColumnName("Recipient");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorShipToes)
                .HasForeignKey(d => d.VendorID);

        }
    }
}
