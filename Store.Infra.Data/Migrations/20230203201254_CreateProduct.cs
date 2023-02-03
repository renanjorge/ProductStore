using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategoriaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategoriaProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Perecivel = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProduto_tblCategoriaProduto_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tblCategoriaProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblCategoriaProduto",
                columns: new[] { "Id", "Descricao", "Ativo", "Nome" },
                values: new object[,]
                {
                    { 1, "Eletrodomésticos", true, "Eletrônico" },
                    { 2, "Produtos para Informática", true, "Informática" },
                    { 3, "Aparelhos e acessórios", true, "Celulares" },
                    { 4, "Artigos para vestuário em geral", true, "Moda" },
                    { 5, "Livros", true, "Livros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProduto_CategoriaId",
                table: "tblProduto",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProduto");

            migrationBuilder.DropTable(
                name: "tblCategoriaProduto");
        }
    }
}
