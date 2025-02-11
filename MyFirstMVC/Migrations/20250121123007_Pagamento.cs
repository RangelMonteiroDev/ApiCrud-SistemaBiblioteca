using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstMVC.Migrations
{
    /// <inheritdoc />
    public partial class Pagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    Aumento = table.Column<bool>(type: "bit", nullable: false),
                    ValorAumento = table.Column<float>(type: "real", nullable: false),
                    Desconto = table.Column<bool>(type: "bit", nullable: false),
                    ValorDesconto = table.Column<float>(type: "real", nullable: false),
                    ValorTotalPagamento = table.Column<float>(type: "real", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.IdPagamento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");
        }
    }
}
