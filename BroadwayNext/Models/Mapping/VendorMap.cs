using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorMap : EntityTypeConfiguration<Vendor>
    {
        public VendorMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorID);

            // Properties
            this.Property(t => t.Company)
                .HasMaxLength(100);

            this.Property(t => t.DBA)
                .HasMaxLength(100);

            this.Property(t => t.Address1)
                .HasMaxLength(100);

            this.Property(t => t.Address2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.State)
                .HasMaxLength(100);

            this.Property(t => t.Zip)
                .HasMaxLength(100);

            this.Property(t => t.Country)
                .HasMaxLength(100);

            this.Property(t => t.Province)
                .HasMaxLength(100);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Emergency)
                .HasMaxLength(20);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.GLnum)
                .HasMaxLength(50);

            this.Property(t => t.TaxID)
                .HasMaxLength(50);

            this.Property(t => t.PricingYear)
                .HasMaxLength(50);

            this.Property(t => t.WebAccessUser)
                .HasMaxLength(50);

            this.Property(t => t.WebAccessPwd)
                .HasMaxLength(50);

            this.Property(t => t.InputBy)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vendors");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.Vendnum).HasColumnName("Vendnum");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.DBA).HasColumnName("DBA");
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
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Emergency).HasColumnName("Emergency");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.AutoEmail).HasColumnName("AutoEmail");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.VendorType).HasColumnName("VendorType");
            this.Property(t => t.GLnum).HasColumnName("GLnum");
            this.Property(t => t.TaxID).HasColumnName("TaxID");
            this.Property(t => t.NetDays).HasColumnName("NetDays");
            this.Property(t => t.CheckTax1099).HasColumnName("CheckTax1099");
            this.Property(t => t.PVA).HasColumnName("PVA");
            this.Property(t => t.SignedContract).HasColumnName("SignedContract");
            this.Property(t => t.CreditCardHolder).HasColumnName("CreditCardHolder");
            this.Property(t => t.W9).HasColumnName("W9");
            this.Property(t => t.PaymentTerms).HasColumnName("PaymentTerms");
            this.Property(t => t.CashDiscount).HasColumnName("CashDiscount");
            this.Property(t => t.PricingYear).HasColumnName("PricingYear");
            this.Property(t => t.Overallrating).HasColumnName("Overallrating");
            this.Property(t => t.WebAccessUser).HasColumnName("WebAccessUser");
            this.Property(t => t.WebAccessPwd).HasColumnName("WebAccessPwd");
            this.Property(t => t.InputBy).HasColumnName("InputBy");
            this.Property(t => t.InputDate).HasColumnName("InputDate");
            this.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            this.Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            this.Property(t => t.GradeID).HasColumnName("GradeID");
        }
    }
}
