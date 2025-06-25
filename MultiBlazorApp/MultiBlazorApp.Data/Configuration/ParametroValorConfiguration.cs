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
    public class ParametroValorConfiguration : IEntityTypeConfiguration<ParametroValor>
    {
        public void Configure(EntityTypeBuilder<ParametroValor> builder)
        {
            builder.ToTable("ParametroValores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasMaxLength(8)
                .IsFixedLength();

            builder.Property(x => x.Descripcion)
               .HasMaxLength(500);

            builder.Property(x => x.Valor)
                .HasMaxLength(500);

            builder.Property(x => x.ValorExterno)
                .HasMaxLength(500);

            builder.Property(x => x.Orden)
                .HasDefaultValue(99)
                .IsRequired();

            builder.Property(x => x.EstadoId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasDefaultValue("ESTA0001")
                .IsRequired();

            builder.HasOne(x => x.Estado)
                .WithMany() // Sin navegación inversa
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Eliminado)
               .HasDefaultValue(false)
               .IsRequired();

            builder.HasOne(x => x.UsuarioModifica);
            builder.HasOne(x => x.UsuarioRegistro);

            var fechaRegistro = new DateTime(2023,4, 1, 0, 0, 0, DateTimeKind.Utc);
            //var data = new ParametroValorSeedData();

            //builder.HasData(data.GetData());

            builder.HasData
            (
                 //Estados Generales
                 new ParametroValor { Id = "ESTA0001", ParametroId = "ESTA", Valor = "ACTIVO", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "ESTA0002", ParametroId = "ESTA", Valor = "INACTIVO", FechaRegistro = fechaRegistro },
                 //Meses
                 new ParametroValor { Id = "MESE0001", ParametroId = "MESE", Descripcion = "ENERO", Valor = "1", Orden = 1, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0002", ParametroId = "MESE", Descripcion = "FEBRERO", Valor = "2", Orden = 2, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0003", ParametroId = "MESE", Descripcion = "MARZO", Valor = "3", Orden = 3, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0004", ParametroId = "MESE", Descripcion = "ABRIL", Valor = "4", Orden = 4, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0005", ParametroId = "MESE", Descripcion = "MAYO", Valor = "5", Orden = 5, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0006", ParametroId = "MESE", Descripcion = "JUNIO", Valor = "6", Orden = 6, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0007", ParametroId = "MESE", Descripcion = "JULIO", Valor = "7", Orden = 7, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0008", ParametroId = "MESE", Descripcion = "AGOSTO", Valor = "8", Orden = 8, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0009", ParametroId = "MESE", Descripcion = "SETIEMBRE", Valor = "9", Orden = 9, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0010", ParametroId = "MESE", Descripcion = "OCTUBRE", Valor = "10", Orden = 10, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0011", ParametroId = "MESE", Descripcion = "NOVIEMBRE", Valor = "11", Orden = 11, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "MESE0012", ParametroId = "MESE", Descripcion = "DICIEMBRE", Valor = "12", Orden = 12, FechaRegistro = fechaRegistro },

                 //Cantidad de páginas para paginación
                 new ParametroValor { Id = "PAGI0001", ParametroId = "PAGI", Valor = "10", Orden = 1, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "PAGI0002", ParametroId = "PAGI", Valor = "25", Orden = 2, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "PAGI0003", ParametroId = "PAGI", Valor = "50", Orden = 3, FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "PAGI0004", ParametroId = "PAGI", Valor = "100", Orden = 4, FechaRegistro = fechaRegistro },

                 //Géneros
                 new ParametroValor { Id = "GENE0001", ParametroId = "GENE", Valor = "MASCULINO", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "GENE0002", ParametroId = "GENE", Valor = "FEMENINO", FechaRegistro = fechaRegistro },

                 //Estados Civiles
                 new ParametroValor { Id = "ECIV0001", ParametroId = "ECIV", Valor = "SOLTERO", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "ECIV0002", ParametroId = "ECIV", Valor = "CASADO", FechaRegistro = fechaRegistro },


                 //Roles de Personas
                 new ParametroValor { Id = "ROLP0001", ParametroId = "ROLP", Valor = "ADMIN", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "ROLP0002", ParametroId = "ROLP", Valor = "USUARIO", FechaRegistro = fechaRegistro },

                 //Tipos de documento
                 new ParametroValor { Id = "TIDO0001", ParametroId = "TIDO", Valor = "DNI", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "TIDO0002", ParametroId = "TIDO", Valor = "RUC", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "TIDO0003", ParametroId = "TIDO", Valor = "CARNET DE EXTRANJERÍA", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "TIDO0004", ParametroId = "TIDO", Valor = "PASAPORTE", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "TIDO0005", ParametroId = "TIDO", Valor = "PARTIDA DE NACIMIENTO", FechaRegistro = fechaRegistro },

                 //Tipos de Item
                 new ParametroValor { Id = "ITEM0001", ParametroId = "ITEM", Valor = "Productos", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "ITEM0002", ParametroId = "ITEM", Valor = "Extras", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "ITEM0003", ParametroId = "ITEM", Valor = "Cremas", FechaRegistro = fechaRegistro },

                 //Categorías de Item
                 new ParametroValor { Id = "CATE0001", ParametroId = "CATE", Valor = "Salchipapas", FechaRegistro = fechaRegistro },
                 new ParametroValor { Id = "CATE0002", ParametroId = "CATE", Valor = "Alitas", FechaRegistro = fechaRegistro },


                 //Estados de Pedidos 
                 new ParametroValor { Id = "ESPE0001", ParametroId = "ESPE", Valor = "Por Aprobar", FechaRegistro = fechaRegistro },
				 new ParametroValor { Id = "ESPE0002", ParametroId = "ESPE", Valor = "En Preparación", FechaRegistro = fechaRegistro },
				 new ParametroValor { Id = "ESPE0003", ParametroId = "ESPE", Valor = "En Camino", FechaRegistro = fechaRegistro },
				 new ParametroValor { Id = "ESPE0004", ParametroId = "ESPE", Valor = "Entregado", FechaRegistro = fechaRegistro }

				 );

        }
    }
}

