using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FornecedoresProdutoApp.Infra.DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                columns: table => new
                {
                    ID_FORNECEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME_FORNECEDOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.ID_FORNECEDOR);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME_PRODUTO = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    ID_FORNECEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID_PRODUTO);
                    table.ForeignKey(
                        name: "FK_PRODUTO_FORNECEDOR_ID_FORNECEDOR",
                        column: x => x.ID_FORNECEDOR,
                        principalTable: "FORNECEDOR",
                        principalColumn: "ID_FORNECEDOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ID_FORNECEDOR",
                table: "PRODUTO",
                column: "ID_FORNECEDOR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "FORNECEDOR");
        }
    }
}
