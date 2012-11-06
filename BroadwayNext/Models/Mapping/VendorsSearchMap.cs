using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class VendorsSearchMap : EntityTypeConfiguration<VendorsSearch>
    {
        public VendorsSearchMap()
        {
            // Primary Key
            this.HasKey(t => t.RecNo);

            // Properties
            this.Property(t => t.MAC)
                .HasMaxLength(50);

            this.Property(t => t.Company)
                .HasMaxLength(100);

            this.Property(t => t.Address1)
                .HasMaxLength(100);

            this.Property(t => t.Address2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.DBA)
                .HasMaxLength(100);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Emergency)
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.GLnum)
                .HasMaxLength(20);

            this.Property(t => t.ADPnum)
                .HasMaxLength(50);

            this.Property(t => t.TaxID)
                .HasMaxLength(50);

            this.Property(t => t.Terms)
                .HasMaxLength(50);

            this.Property(t => t.VendorType)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.WebUsername)
                .HasMaxLength(50);

            this.Property(t => t.WebPassword)
                .HasMaxLength(50);

            this.Property(t => t.Insurance1)
                .HasMaxLength(50);

            this.Property(t => t.Policy1)
                .HasMaxLength(50);

            this.Property(t => t.Insurance2)
                .HasMaxLength(50);

            this.Property(t => t.Policy2)
                .HasMaxLength(50);

            this.Property(t => t.Insurance3)
                .HasMaxLength(50);

            this.Property(t => t.Policy3)
                .HasMaxLength(50);

            this.Property(t => t.TerminatedReason)
                .HasMaxLength(100);

            this.Property(t => t.TerminatedBy)
                .HasMaxLength(30);

            this.Property(t => t.Rehire)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Grade)
                .HasMaxLength(50);

            this.Property(t => t.CheckCompany)
                .HasMaxLength(100);

            this.Property(t => t.CheckAddress1)
                .HasMaxLength(100);

            this.Property(t => t.CheckAddress2)
                .HasMaxLength(100);

            this.Property(t => t.CheckCity)
                .HasMaxLength(100);

            this.Property(t => t.CheckState)
                .HasMaxLength(2);

            this.Property(t => t.CheckZip)
                .HasMaxLength(10);

            this.Property(t => t.CheckContact)
                .HasMaxLength(50);

            this.Property(t => t.CheckPhone)
                .HasMaxLength(20);

            this.Property(t => t.ShipCompany)
                .HasMaxLength(100);

            this.Property(t => t.ShipAddress1)
                .HasMaxLength(100);

            this.Property(t => t.ShipAddress2)
                .HasMaxLength(100);

            this.Property(t => t.ShipCity)
                .HasMaxLength(100);

            this.Property(t => t.ShipState)
                .HasMaxLength(2);

            this.Property(t => t.ShipZip)
                .HasMaxLength(10);

            this.Property(t => t.ShipContact)
                .HasMaxLength(50);

            this.Property(t => t.ShipPhone)
                .HasMaxLength(20);

            this.Property(t => t.Recruiter)
                .HasMaxLength(30);

            this.Property(t => t.ReferBy)
                .HasMaxLength(50);

            this.Property(t => t.FactorCompany)
                .HasMaxLength(50);

            this.Property(t => t.FactorAddress1)
                .HasMaxLength(50);

            this.Property(t => t.FactorAddress2)
                .HasMaxLength(50);

            this.Property(t => t.FactorCity)
                .HasMaxLength(50);

            this.Property(t => t.FactorState)
                .HasMaxLength(2);

            this.Property(t => t.FactorZip)
                .HasMaxLength(10);

            this.Property(t => t.FactorPhone)
                .HasMaxLength(20);

            this.Property(t => t.FactorFax)
                .HasMaxLength(20);

            this.Property(t => t.FactorContact)
                .HasMaxLength(50);

            this.Property(t => t.Inputby)
                .HasMaxLength(30);

            this.Property(t => t.Comment1)
                .HasMaxLength(50);

            this.Property(t => t.drivingtime)
                .HasMaxLength(50);

            this.Property(t => t.Province)
                .HasMaxLength(50);

            this.Property(t => t.EmailAutoFax)
                .HasMaxLength(100);

            this.Property(t => t.InsuranceWaiverReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VendorsSearch");
            this.Property(t => t.RecNo).HasColumnName("RecNo");
            this.Property(t => t.MAC).HasColumnName("MAC");
            this.Property(t => t.Vendnum).HasColumnName("Vendnum");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.DBA).HasColumnName("DBA");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Emergency).HasColumnName("Emergency");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.ActiveType).HasColumnName("ActiveType");
            this.Property(t => t.W9).HasColumnName("W9");
            this.Property(t => t.GLnum).HasColumnName("GLnum");
            this.Property(t => t.ADPnum).HasColumnName("ADPnum");
            this.Property(t => t.NetDays).HasColumnName("NetDays");
            this.Property(t => t.TaxID).HasColumnName("TaxID");
            this.Property(t => t.Tax1099).HasColumnName("Tax1099");
            this.Property(t => t.Tax1099YN).HasColumnName("Tax1099YN");
            this.Property(t => t.TermDay).HasColumnName("TermDay");
            this.Property(t => t.Terms).HasColumnName("Terms");
            this.Property(t => t.TermDiscount).HasColumnName("TermDiscount");
            this.Property(t => t.VendorType).HasColumnName("VendorType");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.WebUsername).HasColumnName("WebUsername");
            this.Property(t => t.WebPassword).HasColumnName("WebPassword");
            this.Property(t => t.Insurance1).HasColumnName("Insurance1");
            this.Property(t => t.Policy1).HasColumnName("Policy1");
            this.Property(t => t.ExpDate1).HasColumnName("ExpDate1");
            this.Property(t => t.Limit1).HasColumnName("Limit1");
            this.Property(t => t.Exempt1).HasColumnName("Exempt1");
            this.Property(t => t.Insured1).HasColumnName("Insured1");
            this.Property(t => t.Insurance2).HasColumnName("Insurance2");
            this.Property(t => t.Policy2).HasColumnName("Policy2");
            this.Property(t => t.ExpDate2).HasColumnName("ExpDate2");
            this.Property(t => t.Limit2).HasColumnName("Limit2");
            this.Property(t => t.Exempt2).HasColumnName("Exempt2");
            this.Property(t => t.Insured2).HasColumnName("Insured2");
            this.Property(t => t.Insurance3).HasColumnName("Insurance3");
            this.Property(t => t.Policy3).HasColumnName("Policy3");
            this.Property(t => t.ExpDate3).HasColumnName("ExpDate3");
            this.Property(t => t.Limit3).HasColumnName("Limit3");
            this.Property(t => t.Exempt3).HasColumnName("Exempt3");
            this.Property(t => t.Insured3).HasColumnName("Insured3");
            this.Property(t => t.TerminatedDate).HasColumnName("TerminatedDate");
            this.Property(t => t.TerminatedEffDate).HasColumnName("TerminatedEffDate");
            this.Property(t => t.TerminatedReason).HasColumnName("TerminatedReason");
            this.Property(t => t.TerminatedBy).HasColumnName("TerminatedBy");
            this.Property(t => t.Rehire).HasColumnName("Rehire");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.CheckCompany).HasColumnName("CheckCompany");
            this.Property(t => t.CheckAddress1).HasColumnName("CheckAddress1");
            this.Property(t => t.CheckAddress2).HasColumnName("CheckAddress2");
            this.Property(t => t.CheckCity).HasColumnName("CheckCity");
            this.Property(t => t.CheckState).HasColumnName("CheckState");
            this.Property(t => t.CheckZip).HasColumnName("CheckZip");
            this.Property(t => t.CheckContact).HasColumnName("CheckContact");
            this.Property(t => t.CheckPhone).HasColumnName("CheckPhone");
            this.Property(t => t.ShipCompany).HasColumnName("ShipCompany");
            this.Property(t => t.ShipAddress1).HasColumnName("ShipAddress1");
            this.Property(t => t.ShipAddress2).HasColumnName("ShipAddress2");
            this.Property(t => t.ShipCity).HasColumnName("ShipCity");
            this.Property(t => t.ShipState).HasColumnName("ShipState");
            this.Property(t => t.ShipZip).HasColumnName("ShipZip");
            this.Property(t => t.ShipContact).HasColumnName("ShipContact");
            this.Property(t => t.ShipPhone).HasColumnName("ShipPhone");
            this.Property(t => t.Recruiter).HasColumnName("Recruiter");
            this.Property(t => t.ReferBy).HasColumnName("ReferBy");
            this.Property(t => t.FactorCompany).HasColumnName("FactorCompany");
            this.Property(t => t.FactorAddress1).HasColumnName("FactorAddress1");
            this.Property(t => t.FactorAddress2).HasColumnName("FactorAddress2");
            this.Property(t => t.FactorCity).HasColumnName("FactorCity");
            this.Property(t => t.FactorState).HasColumnName("FactorState");
            this.Property(t => t.FactorZip).HasColumnName("FactorZip");
            this.Property(t => t.FactorPhone).HasColumnName("FactorPhone");
            this.Property(t => t.FactorFax).HasColumnName("FactorFax");
            this.Property(t => t.FactorContact).HasColumnName("FactorContact");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.Inputby).HasColumnName("Inputby");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Comment1).HasColumnName("Comment1");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.ServiceCnt).HasColumnName("ServiceCnt");
            this.Property(t => t.drivingtime).HasColumnName("drivingtime");
            this.Property(t => t.Dormant).HasColumnName("Dormant");
            this.Property(t => t.RateInt).HasColumnName("RateInt");
            this.Property(t => t.RateExt).HasColumnName("RateExt");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.EmailAutoFax).HasColumnName("EmailAutoFax");
            this.Property(t => t.PriceCnt).HasColumnName("PriceCnt");
            this.Property(t => t.NP).HasColumnName("NP");
            this.Property(t => t.SC).HasColumnName("SC");
            this.Property(t => t.LP).HasColumnName("LP");
            this.Property(t => t.SV).HasColumnName("SV");
            this.Property(t => t.TermSV).HasColumnName("TermSV");
            this.Property(t => t.TermLP).HasColumnName("TermLP");
            this.Property(t => t.TermNP).HasColumnName("TermNP");
            this.Property(t => t.TermSC).HasColumnName("TermSC");
            this.Property(t => t.SignedContract).HasColumnName("SignedContract");
            this.Property(t => t.VPA).HasColumnName("VPA");
            this.Property(t => t.InsuranceWaiver).HasColumnName("InsuranceWaiver");
            this.Property(t => t.InsuranceWaiverReason).HasColumnName("InsuranceWaiverReason");
        }
    }
}
