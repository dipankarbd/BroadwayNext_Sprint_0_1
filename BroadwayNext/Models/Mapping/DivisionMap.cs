using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class DivisionMap : EntityTypeConfiguration<Division>
    {
        public DivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.DivisionID);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Prefix)
                .HasMaxLength(10);

            this.Property(t => t.GLNum)
                .HasMaxLength(20);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.ComplaintEmail)
                .HasMaxLength(50);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Division");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Prefix).HasColumnName("Prefix");
            this.Property(t => t.GLNum).HasColumnName("GLNum");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.ComplaintEmail).HasColumnName("ComplaintEmail");
            this.Property(t => t.VendorInstructions).HasColumnName("VendorInstructions");
            this.Property(t => t.AutofaxNotice).HasColumnName("AutofaxNotice");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
        }
    }
}
