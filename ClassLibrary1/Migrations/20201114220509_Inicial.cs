using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gerente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaoCidadao = table.Column<int>(type: "int", nullable: false),
                    Contribuinte = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentos_Contas_NumeroConta",
                        column: x => x.NumeroConta,
                        principalTable: "Contas",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    NumeroCartao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emissor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anuidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plafond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTitular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.NumeroCartao);
                    table.ForeignKey(
                        name: "FK_Cartoes_Titulares_IdTitular",
                        column: x => x.IdTitular,
                        principalTable: "Titulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroConta = table.Column<int>(type: "int", nullable: false),
                    IdTitular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposConta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposConta_Contas_NumeroConta",
                        column: x => x.NumeroConta,
                        principalTable: "Contas",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposConta_Titulares_IdTitular",
                        column: x => x.IdTitular,
                        principalTable: "Titulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdTitular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposProduto_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposProduto_Titulares_IdTitular",
                        column: x => x.IdTitular,
                        principalTable: "Titulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Numero", "Agencia", "DataRegisto", "Gerente" },
                values: new object[] { 1, "Lisboa", new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), "José Luiz" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataFinalizacao", "DataRegisto", "Nome", "Preco" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 17, 18, 35, 0, 0, DateTimeKind.Unspecified), "Cartão de débito", 5m });

            migrationBuilder.InsertData(
                table: "Titulares",
                columns: new[] { "Id", "CartaoCidadao", "Contribuinte", "DataNascimento", "Morada", "Nome" },
                values: new object[] { 1, 123456, 222222777, new DateTime(1980, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ABC, 17 - Lisboa", "Fernando Soares" });

            migrationBuilder.InsertData(
                table: "Cartoes",
                columns: new[] { "NumeroCartao", "Anuidade", "DataEmissao", "Emissor", "IdTitular", "Plafond", "Validade" },
                values: new object[] { 1234, 20m, new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), "Visa", 1, 1000m, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movimentos",
                columns: new[] { "Id", "Data", "NumeroConta", "TipoMovimento", "Valor" },
                values: new object[] { 1, new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, "Levantamento MB", 20m });

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_IdTitular",
                table: "Cartoes",
                column: "IdTitular");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_NumeroConta",
                table: "Movimentos",
                column: "NumeroConta");

            migrationBuilder.CreateIndex(
                name: "IX_TiposConta_IdTitular",
                table: "TiposConta",
                column: "IdTitular");

            migrationBuilder.CreateIndex(
                name: "IX_TiposConta_NumeroConta",
                table: "TiposConta",
                column: "NumeroConta");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProduto_IdProduto",
                table: "TiposProduto",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProduto_IdTitular",
                table: "TiposProduto",
                column: "IdTitular");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "TiposConta");

            migrationBuilder.DropTable(
                name: "TiposProduto");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Titulares");
        }
    }
}
