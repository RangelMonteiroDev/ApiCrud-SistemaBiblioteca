using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstMVC.Migrations
{
    /// <inheritdoc />
    public partial class Multa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Multa",
                columns: table => new
                {
                    IdMulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmpresyimo = table.Column<DateOnly>(type: "date", nullable: false),
                    AumentoMulta = table.Column<bool>(type: "bit", nullable: false),
                    ValorAumento = table.Column<float>(type: "real", nullable: false),
                    DescontoMulta = table.Column<bool>(type: "bit", nullable: false),
                    ValorDesconto = table.Column<float>(type: "real", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    CodigoMulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorTotalMulta = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.IdMulta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multa");
        }
    }
}
