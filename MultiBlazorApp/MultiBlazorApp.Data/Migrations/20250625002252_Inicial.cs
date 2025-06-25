using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiBlazorApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PuedeAgregar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeModificar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEliminar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeVisualizar = table.Column<bool>(type: "bit", nullable: false),
                    ParametroPadreId = table.Column<string>(type: "nchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametros_Parametros_ParametroPadreId",
                        column: x => x.ParametroPadreId,
                        principalTable: "Parametros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExtrasItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemPedidoId = table.Column<int>(type: "int", nullable: false),
                    ExtraId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrasItemPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoId = table.Column<string>(type: "nchar(8)", nullable: false),
                    CategoriaId = table.Column<string>(type: "nchar(8)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioPromo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RutaImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<string>(type: "nchar(8)", nullable: false, defaultValue: "ESTA0001"),
                    OrdenPorDefecto = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioRegistroId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificaId = table.Column<int>(type: "int", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PrecioProducto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SubCategoriaId = table.Column<string>(type: "nchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsPedido_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroValores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    ParametroId = table.Column<string>(type: "nchar(4)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValorExterno = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false, defaultValue: 99),
                    EstadoId = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false, defaultValue: "ESTA0001"),
                    ValorPadreId = table.Column<string>(type: "nchar(8)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsuarioRegistroId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificaId = table.Column<int>(type: "int", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroValores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroValores_ParametroValores_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "ParametroValores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParametroValores_ParametroValores_ValorPadreId",
                        column: x => x.ValorPadreId,
                        principalTable: "ParametroValores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParametroValores_Parametros_ParametroId",
                        column: x => x.ParametroId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroWhatsapp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<string>(type: "nchar(8)", nullable: false),
                    RolId = table.Column<string>(type: "nchar(8)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsuarioRegistroId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificaId = table.Column<int>(type: "int", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_ParametroValores_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "ParametroValores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_ParametroValores_RolId",
                        column: x => x.RolId,
                        principalTable: "ParametroValores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioModificaId",
                        column: x => x.UsuarioModificaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioRegistroId",
                        column: x => x.UsuarioRegistroId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroWhatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreReceptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    EstadoPedidoId = table.Column<string>(type: "nchar(8)", nullable: false, defaultValue: "ESPE0001"),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioRegistroId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificaId = table.Column<int>(type: "int", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_ParametroValores_EstadoPedidoId",
                        column: x => x.EstadoPedidoId,
                        principalTable: "ParametroValores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioModificaId",
                        column: x => x.UsuarioModificaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioRegistroId",
                        column: x => x.UsuarioRegistroId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Nombre", "ParametroPadreId", "PuedeAgregar", "PuedeEliminar", "PuedeModificar", "PuedeVisualizar" },
                values: new object[,]
                {
                    { "CATE", "Categorías de Item", null, false, false, false, true },
                    { "ECIV", "Estados Civiles", null, true, false, false, true },
                    { "ESPE", "Estados Pedido", null, false, false, false, true },
                    { "ESTA", "Estados generales de elementos", null, false, false, false, true },
                    { "GENE", "Géneros", null, true, false, false, true },
                    { "ITEM", "Tipos de Item", null, false, false, false, true },
                    { "MESE", "Lista de meses", null, false, false, false, true },
                    { "PAGI", "Paginación", null, true, true, false, true },
                    { "ROLP", "Roles de Personas", null, true, false, false, true },
                    { "SCAT", "Sub-Categorías de Item", null, false, false, false, true },
                    { "TIDO", "Tipos de Documento", null, true, false, false, true }
                });

            migrationBuilder.InsertData(
                table: "ParametroValores",
                columns: new[] { "Id", "Descripcion", "FechaModifica", "FechaRegistro", "ParametroId", "UsuarioModificaId", "UsuarioRegistroId", "Valor", "ValorExterno", "ValorPadreId" },
                values: new object[,]
                {
                    { "ESTA0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESTA", null, null, "ACTIVO", null, null },
                    { "CATE0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CATE", null, null, "Salchipapas", null, null },
                    { "CATE0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CATE", null, null, "Alitas", null, null },
                    { "ECIV0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ECIV", null, null, "SOLTERO", null, null },
                    { "ECIV0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ECIV", null, null, "CASADO", null, null },
                    { "ESPE0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESPE", null, null, "Por Aprobar", null, null },
                    { "ESPE0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESPE", null, null, "En Preparación", null, null },
                    { "ESPE0003", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESPE", null, null, "En Camino", null, null },
                    { "ESPE0004", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESPE", null, null, "Entregado", null, null },
                    { "ESTA0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ESTA", null, null, "INACTIVO", null, null },
                    { "GENE0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "GENE", null, null, "MASCULINO", null, null },
                    { "GENE0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "GENE", null, null, "FEMENINO", null, null },
                    { "ITEM0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ITEM", null, null, "Productos", null, null },
                    { "ITEM0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ITEM", null, null, "Extras", null, null },
                    { "ITEM0003", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ITEM", null, null, "Cremas", null, null }
                });

            migrationBuilder.InsertData(
                table: "ParametroValores",
                columns: new[] { "Id", "Descripcion", "FechaModifica", "FechaRegistro", "Orden", "ParametroId", "UsuarioModificaId", "UsuarioRegistroId", "Valor", "ValorExterno", "ValorPadreId" },
                values: new object[,]
                {
                    { "MESE0001", "ENERO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "MESE", null, null, "1", null, null },
                    { "MESE0002", "FEBRERO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "MESE", null, null, "2", null, null },
                    { "MESE0003", "MARZO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "MESE", null, null, "3", null, null },
                    { "MESE0004", "ABRIL", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "MESE", null, null, "4", null, null },
                    { "MESE0005", "MAYO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "MESE", null, null, "5", null, null },
                    { "MESE0006", "JUNIO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, "MESE", null, null, "6", null, null },
                    { "MESE0007", "JULIO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "MESE", null, null, "7", null, null },
                    { "MESE0008", "AGOSTO", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, "MESE", null, null, "8", null, null },
                    { "MESE0009", "SETIEMBRE", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, "MESE", null, null, "9", null, null },
                    { "MESE0010", "OCTUBRE", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, "MESE", null, null, "10", null, null },
                    { "MESE0011", "NOVIEMBRE", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, "MESE", null, null, "11", null, null },
                    { "MESE0012", "DICIEMBRE", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, "MESE", null, null, "12", null, null },
                    { "PAGI0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "PAGI", null, null, "10", null, null },
                    { "PAGI0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "PAGI", null, null, "25", null, null },
                    { "PAGI0003", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "PAGI", null, null, "50", null, null },
                    { "PAGI0004", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "PAGI", null, null, "100", null, null }
                });

            migrationBuilder.InsertData(
                table: "ParametroValores",
                columns: new[] { "Id", "Descripcion", "FechaModifica", "FechaRegistro", "ParametroId", "UsuarioModificaId", "UsuarioRegistroId", "Valor", "ValorExterno", "ValorPadreId" },
                values: new object[,]
                {
                    { "ROLP0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ROLP", null, null, "ADMIN", null, null },
                    { "ROLP0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ROLP", null, null, "USUARIO", null, null },
                    { "TIDO0001", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "TIDO", null, null, "DNI", null, null },
                    { "TIDO0002", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "TIDO", null, null, "RUC", null, null },
                    { "TIDO0003", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "TIDO", null, null, "CARNET DE EXTRANJERÍA", null, null },
                    { "TIDO0004", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "TIDO", null, null, "PASAPORTE", null, null },
                    { "TIDO0005", null, null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "TIDO", null, null, "PARTIDA DE NACIMIENTO", null, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "Eliminado", "EstadoId", "FechaModifica", "FechaRegistro", "Nombre", "OrdenPorDefecto", "Precio", "PrecioPromo", "RutaImg", "TipoId", "UsuarioModificaId", "UsuarioRegistroId" },
                values: new object[,]
                {
                    { 1, "CATE0001", "Delicioso Hot Dot + Porción de Papa Amarilla + Cremas", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salchipapa Andina", 0, 12m, null, "../img/Salchipapa Personal.jpg", "ITEM0001", null, null },
                    { 2, "CATE0001", "Porción Personal de Salchipapa Andina + Tocino + Queso + Cremas", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salchimonstruo Andino", 0, 15m, null, "../img/Foto.png", "ITEM0001", null, null },
                    { 3, "CATE0001", "Porción de Salchipapa Andina para 2 + Cremas", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salchipapa Andina XL", 0, 22m, null, "../img/Foto.png", "ITEM0001", null, null },
                    { 4, "CATE0001", "Porción de Salchipapa Andina para 2 + Tocino (2) + Queso (2) + Cremas", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salchimonstruo Andino XL", 0, 28m, null, "../img/Foto.png", "ITEM0001", null, null },
                    { 5, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tocino", 0, 2m, null, "", "ITEM0002", null, null },
                    { 6, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Queso", 0, 2m, null, "", "ITEM0002", null, null },
                    { 7, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huevo", 0, 2m, null, "", "ITEM0002", null, null },
                    { 8, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ají de Pollería", 0, 0m, null, "", "ITEM0003", null, null },
                    { 9, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tártara", 0, 0m, null, "", "ITEM0003", null, null },
                    { 10, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayonesa", 0, 0m, null, "", "ITEM0003", null, null },
                    { 11, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crema de Rocoto", 0, 0m, null, "", "ITEM0003", null, null },
                    { 12, "CATE0001", "", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Golf", 0, 0m, null, "", "ITEM0003", null, null },
                    { 13, "CATE0002", "6 Sabrosas Alitas Acevichadas + Porción de Papa Amarilla", false, "ESTA0001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alitas Acevichadas", 0, 20m, null, "../img/Alitas Acevichadas.jpg", "ITEM0001", null, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ApellidoMaterno", "ApellidoPaterno", "Correo", "Direccion", "EstadoId", "FechaModifica", "FechaRegistro", "Nombre", "NumeroWhatsapp", "Password", "RolId", "UserName", "UsuarioModificaId", "UsuarioRegistroId" },
                values: new object[,]
                {
                    { 1, "ADMIN", "ADMIN", "ADMIN@GMAIL.COM", "CALLE ABC", "ESTA0001", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ADMIN", "123465798", "b053f7175cf143e5022787fd56ab221dbdf051832f7e26348d07c593fe237e15", "ROLP0001", "admin", null, null },
                    { 2, "USUARIO", "USUARIO", "USUARIO@GMAIL.COM", "CALLE ABC", "ESTA0001", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "USUARIO", "123465798", "b053f7175cf143e5022787fd56ab221dbdf051832f7e26348d07c593fe237e15", "ROLP0002", "usuario", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtrasItemPedido_ExtraId",
                table: "ExtrasItemPedido",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtrasItemPedido_ItemPedidoId",
                table: "ExtrasItemPedido",
                column: "ItemPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoriaId",
                table: "Items",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_EstadoId",
                table: "Items",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TipoId",
                table: "Items",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UsuarioModificaId",
                table: "Items",
                column: "UsuarioModificaId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UsuarioRegistroId",
                table: "Items",
                column: "UsuarioRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_ItemId",
                table: "ItemsPedido",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_PedidoId",
                table: "ItemsPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_SubCategoriaId",
                table: "ItemsPedido",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_ParametroPadreId",
                table: "Parametros",
                column: "ParametroPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroValores_EstadoId",
                table: "ParametroValores",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroValores_ParametroId",
                table: "ParametroValores",
                column: "ParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroValores_UsuarioModificaId",
                table: "ParametroValores",
                column: "UsuarioModificaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroValores_UsuarioRegistroId",
                table: "ParametroValores",
                column: "UsuarioRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroValores_ValorPadreId",
                table: "ParametroValores",
                column: "ValorPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadoPedidoId",
                table: "Pedidos",
                column: "EstadoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioModificaId",
                table: "Pedidos",
                column: "UsuarioModificaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioRegistroId",
                table: "Pedidos",
                column: "UsuarioRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoId",
                table: "Usuarios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioModificaId",
                table: "Usuarios",
                column: "UsuarioModificaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioRegistroId",
                table: "Usuarios",
                column: "UsuarioRegistroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtrasItemPedido_ItemsPedido_ItemPedidoId",
                table: "ExtrasItemPedido",
                column: "ItemPedidoId",
                principalTable: "ItemsPedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtrasItemPedido_Items_ExtraId",
                table: "ExtrasItemPedido",
                column: "ExtraId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ParametroValores_CategoriaId",
                table: "Items",
                column: "CategoriaId",
                principalTable: "ParametroValores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ParametroValores_EstadoId",
                table: "Items",
                column: "EstadoId",
                principalTable: "ParametroValores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ParametroValores_TipoId",
                table: "Items",
                column: "TipoId",
                principalTable: "ParametroValores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Usuarios_UsuarioModificaId",
                table: "Items",
                column: "UsuarioModificaId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Usuarios_UsuarioRegistroId",
                table: "Items",
                column: "UsuarioRegistroId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedido_ParametroValores_SubCategoriaId",
                table: "ItemsPedido",
                column: "SubCategoriaId",
                principalTable: "ParametroValores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedido_Pedidos_PedidoId",
                table: "ItemsPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametroValores_Usuarios_UsuarioModificaId",
                table: "ParametroValores",
                column: "UsuarioModificaId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametroValores_Usuarios_UsuarioRegistroId",
                table: "ParametroValores",
                column: "UsuarioRegistroId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ParametroValores_EstadoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ParametroValores_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "ExtrasItemPedido");

            migrationBuilder.DropTable(
                name: "ItemsPedido");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ParametroValores");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
