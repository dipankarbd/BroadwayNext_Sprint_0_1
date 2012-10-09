using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNext_Sprint_0_1.Models.Mapping
{
    public class VendorContactMap : EntityTypeConfiguration<VendorContact>
    {
        public VendorContactMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorContactID);

            // Properties
            this.Property(t => t.Lastname)
                .HasMaxLength(50);

            this.Property(t => t.Firstname)
                .HasMaxLength(50);

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

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.PhoneExt)
                .HasMaxLength(10);

            this.Property(t => t.Fax)
                .HasMaxLength(25);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.ContactType)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.InputBy)
                .HasMaxLength(30);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("VendorContacts");
            this.Property(t => t.VendorContactID).HasColumnName("VendorContactID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.Lastname).HasColumnName("Lastname");
            this.Property(t => t.Firstname).HasColumnName("Firstname");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ContactType).HasColumnName("ContactType");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.ActiveType).HasColumnName("ActiveType");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");

            // Relationships
            this.HasRequired(t => t.Vendor)
                .WithMany(t => t.VendorContacts)
                .HasForeignKey(d => d.VendorID);

        }
    }
}