using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BroadwayNextWeb.Models.Mapping
{
    public class StateTaxableMap : EntityTypeConfiguration<StateTaxable>
    {
        public StateTaxableMap()
        {
            // Primary Key
            this.HasKey(t => new { t.StateTaxableID, t.StateID });

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Inputby)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StateTaxable");
            this.Property(t => t.StateTaxableID).HasColumnName("StateTaxableID");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Inputdate).HasColumnName("Inputdate");
            this.Property(t => t.Inputby).HasColumnName("Inputby");
        }
    }
}
