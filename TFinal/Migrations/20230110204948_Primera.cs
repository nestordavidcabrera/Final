using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFinal.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idcliente = table.Column<int>(name: "id_cliente", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrecliente = table.Column<string>(name: "nombre_cliente", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dircliente = table.Column<string>(name: "dir_cliente", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    correocliente = table.Column<string>(name: "correo_cliente", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefonocliente = table.Column<int>(name: "telefono_cliente", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idcliente);
                });

            migrationBuilder.CreateTable(
                name: "Condiciones",
                columns: table => new
                {
                    idcondicion = table.Column<int>(name: "id_condicion", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descondicion = table.Column<string>(name: "des_condicion", type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condiciones", x => x.idcondicion);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagos",
                columns: table => new
                {
                    idformapago = table.Column<int>(name: "id_forma_pago", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descformapago = table.Column<string>(name: "desc_forma_pago", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagos", x => x.idformapago);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    idinmueble = table.Column<int>(name: "id_inmueble", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idtipoinmueble = table.Column<int>(name: "id_tipo_inmueble", type: "int", nullable: false),
                    descinmueble = table.Column<string>(name: "desc_inmueble", type: "nvarchar(max)", nullable: false),
                    ubicinmueble = table.Column<string>(name: "ubic_inmueble", type: "nvarchar(max)", nullable: false),
                    costoinmueble = table.Column<double>(name: "costo_inmueble", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.idinmueble);
                });

            migrationBuilder.CreateTable(
                name: "TiposInmuebles",
                columns: table => new
                {
                    idtipoinmueble = table.Column<int>(name: "id_tipo_inmueble", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descinmueble = table.Column<string>(name: "desc_inmueble", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInmuebles", x => x.idtipoinmueble);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    idventa = table.Column<int>(name: "id_venta", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idinmueble = table.Column<int>(name: "id_inmueble", type: "int", nullable: false),
                    idcliente = table.Column<int>(name: "id_cliente", type: "int", nullable: false),
                    idcondicion = table.Column<int>(name: "id_condicion", type: "int", nullable: false),
                    idformapago = table.Column<int>(name: "id_forma_pago", type: "int", nullable: false),
                    descventa = table.Column<string>(name: "desc_venta", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    totalventa = table.Column<int>(name: "total_venta", type: "int", nullable: false),
                    totaliva = table.Column<int>(name: "total_iva", type: "int", nullable: false),
                    totalgeneral = table.Column<int>(name: "total_general", type: "int", nullable: false),
                    fechaventa = table.Column<DateTime>(name: "fecha_venta", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.idventa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Condiciones");

            migrationBuilder.DropTable(
                name: "FormaPagos");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "TiposInmuebles");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
