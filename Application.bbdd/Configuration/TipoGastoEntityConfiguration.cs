using Application.bbdd.Entities.Maestros;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Configuration
{
    //https://www.entityframeworktutorial.net/code-first/move-configurations-to-seperate-class-in-code-first.aspx
    public class TipoGastoEntityConfiguration:EntityTypeConfiguration<TipoGasto>
    {
        public TipoGastoEntityConfiguration()
        {
            this.ToTable("TipoGasto");
            this.HasKey<int>(k => k.TipoGastoID);
            

            this.Property(p => p.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
