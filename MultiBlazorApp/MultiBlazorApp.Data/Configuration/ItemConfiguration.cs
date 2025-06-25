using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiBlazorApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Configuration
{
	public class ItemConfiguration : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.ToTable("Items");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.UseIdentityColumn();

            builder.Property(x => x.EstadoId)
                .HasDefaultValue("ESTA0001");

            builder.HasOne(x => x.Estado)
                .WithMany() // Sin navegación inversa
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Tipo)
			.WithMany() // Sin navegación inversa
			.HasForeignKey(x => x.TipoId)
			.OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.PrecioPromo)
				.HasDefaultValue(null);

			builder.HasOne(x => x.Estado);

            builder.HasData(
				new Item
				{	Id = 1,
					Nombre = "Salchipapa Andina",
					Descripcion = "Delicioso Hot Dot + Porción de Papa Amarilla + Cremas",
					TipoId= "ITEM0001",
					CategoriaId= "CATE0001",
					Precio = 12,
					RutaImg= "../img/Salchipapa Personal.jpg",
					EstadoId = "ESTA0001"
                }, 
				new Item
				{
					Id = 2,
					Nombre = "Salchimonstruo Andino",
					Descripcion = "Porción Personal de Salchipapa Andina + Tocino + Queso + Cremas",
					TipoId = "ITEM0001",
					CategoriaId = "CATE0001",
					Precio = 15,
					RutaImg = "../img/Foto.png",
                    EstadoId = "ESTA0001"
                }, 
				new Item
				{
					Id = 3,
					Nombre = "Salchipapa Andina XL",
					Descripcion = "Porción de Salchipapa Andina para 2 + Cremas",
					TipoId = "ITEM0001",
					CategoriaId = "CATE0001",
					Precio = 22,
					RutaImg = "../img/Foto.png",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 4,
					Nombre = "Salchimonstruo Andino XL",
					Descripcion = "Porción de Salchipapa Andina para 2 + Tocino (2) + Queso (2) + Cremas",
					TipoId = "ITEM0001",
					CategoriaId = "CATE0001",
					Precio = 28,
					RutaImg = "../img/Foto.png",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 5,
					Nombre = "Tocino",
					Descripcion = "",
					TipoId = "ITEM0002",
					CategoriaId = "CATE0001",
					Precio = 2,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 6,
					Nombre = "Queso",
					Descripcion = "",
					TipoId = "ITEM0002",
					CategoriaId = "CATE0001",
					Precio = 2,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 7,
					Nombre = "Huevo",
					Descripcion = "",
					TipoId = "ITEM0002",
					CategoriaId = "CATE0001",
					Precio = 2,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 8,
					Nombre = "Ají de Pollería",
					Descripcion = "",
					TipoId = "ITEM0003",
					CategoriaId = "CATE0001",
					Precio = 0,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 9,
					Nombre = "Tártara",
					Descripcion = "",
					TipoId = "ITEM0003",
					CategoriaId = "CATE0001",
					Precio = 0,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 10,
					Nombre = "Mayonesa",
					Descripcion = "",
					TipoId = "ITEM0003",
					CategoriaId = "CATE0001",
					Precio = 0,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 11,
					Nombre = "Crema de Rocoto",
					Descripcion = "",
					TipoId = "ITEM0003",
					CategoriaId = "CATE0001",
					Precio = 0,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 12,
					Nombre = "Golf",
					Descripcion = "",
					TipoId = "ITEM0003",
					CategoriaId = "CATE0001",
					Precio = 0,
					RutaImg = "",
                    EstadoId = "ESTA0001"
                },
				new Item
				{
					Id = 13,
					Nombre = "Alitas Acevichadas",
					Descripcion = "6 Sabrosas Alitas Acevichadas + Porción de Papa Amarilla",
					TipoId = "ITEM0001",
					CategoriaId = "CATE0002",
					Precio = 20,
					RutaImg = "../img/Alitas Acevichadas.jpg",
                    EstadoId = "ESTA0001"
                });
		}
	}
}
