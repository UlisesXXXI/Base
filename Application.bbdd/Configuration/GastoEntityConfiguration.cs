using Application.bbdd.Entities;
using Application.bbdd.Entities.Maestros;
using System.Data.Entity.ModelConfiguration;

namespace Application.bbdd.Configuration
{
    //https://www.entityframeworktutorial.net/code-first/move-configurations-to-seperate-class-in-code-first.aspx

    class GastoEntityConfiguration: EntityTypeConfiguration<Gasto>
    {
        public GastoEntityConfiguration()
        {
            this.ToTable("Gasto");

            this.Property(p => p.Descripcion)
                    .HasMaxLength(250);

            this.HasRequired(t => t.TipoGasto).WithMany().HasForeignKey(t => t.TipoGastoID).WillCascadeOnDelete(false);
                    
        }
    }
}
