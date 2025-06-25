using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiBlazorApp.Data.Models;

namespace MultiBlazorApp.Data.Configuration
{
    public class ParametroConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("Parametros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasMaxLength(4)
                .IsFixedLength();
            builder.Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData
            (
                new Parametro { Id = "ESTA", Nombre = "Estados generales de elementos", PuedeVisualizar = true },
				new Parametro { Id = "MESE", Nombre = "Lista de meses", PuedeVisualizar = true },
				 new Parametro { Id = "PAGI", Nombre = "Paginación", PuedeAgregar = true, PuedeEliminar = true, PuedeModificar = false, PuedeVisualizar = true },
				new Parametro { Id = "GENE", Nombre = "Géneros", PuedeAgregar = true, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
				new Parametro { Id = "ECIV", Nombre = "Estados Civiles", PuedeAgregar = true, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
				new Parametro { Id = "ROLP", Nombre = "Roles de Personas", PuedeAgregar = true, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
               new Parametro { Id = "TIDO", Nombre = "Tipos de Documento", PuedeAgregar = true, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
new Parametro { Id = "ITEM", Nombre = "Tipos de Item", PuedeAgregar = false, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
new Parametro { Id = "CATE", Nombre = "Categorías de Item", PuedeAgregar = false, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
new Parametro { Id = "ESPE", Nombre = "Estados Pedido", PuedeAgregar = false, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true },
new Parametro { Id = "SCAT", Nombre = "Sub-Categorías de Item", PuedeAgregar = false, PuedeEliminar = false, PuedeModificar = false, PuedeVisualizar = true }



            );
        }
    }
}
