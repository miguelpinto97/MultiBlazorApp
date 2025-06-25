using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MultiBlazorApp.Data.Models;
using System.Reflection.Emit;
using MultiBlazorApp.Common.Utils;

namespace MultiBlazorApp.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();
            builder.Property(x => x.UserName)
                .HasMaxLength(20);
            builder.Property(x => x.Eliminado)
              .HasDefaultValue(false)
              .IsRequired();
            //builder.Property(x => x.EstadoId)
            //    .HasMaxLength(8)
            //    .IsFixedLength();




            builder.HasOne(x => x.Estado);
            builder.HasOne(x => x.Rol)
                .WithMany() // Sin navegación inversa
                .HasForeignKey(x => x.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.UsuarioRegistro)
                .WithMany()
                .HasForeignKey(u => u.UsuarioRegistroId);

            builder
                .HasOne(u => u.UsuarioModifica)
                .WithMany()
                .HasForeignKey(u => u.UsuarioModificaId);

            builder.HasData
           (
               new Usuario
               {
                   Id = 1,
                   UserName = "admin",
                   Password = "b053f7175cf143e5022787fd56ab221dbdf051832f7e26348d07c593fe237e15",
                   EstadoId = "ESTA0001",
                   RolId= "ROLP0001",
                   Nombre = "ADMIN",
                   ApellidoPaterno = "ADMIN",
                   ApellidoMaterno = "ADMIN",
                   Correo = "ADMIN@GMAIL.COM",
                   NumeroWhatsapp="123465798",
                   Direccion="CALLE ABC",
                   //EstadoId = "null",
                   FechaRegistro = new DateTime(2023, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                   //UsuarioRegistroId = 1,
                   //UsuarioModificaId = 1
               },
                              new Usuario
                              {
                                  Id = 2,
                                  UserName = "usuario",
                                  Password = "b053f7175cf143e5022787fd56ab221dbdf051832f7e26348d07c593fe237e15",
                                  EstadoId = "ESTA0001",
                                  //EstadoId = "null",
                                  FechaRegistro = new DateTime(2023, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                                  //UsuarioRegistroId = 1,
                                  //UsuarioModificaId = 1
                                    Nombre = "USUARIO",
                                  ApellidoPaterno = "USUARIO",
                                  ApellidoMaterno = "USUARIO",
                                  Correo = "USUARIO@GMAIL.COM",
                                  NumeroWhatsapp = "123465798",
                                  Direccion = "CALLE ABC",
                               RolId = "ROLP0002"
                              }

           );

        }
    }
}
