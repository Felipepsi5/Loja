using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDaCategoria = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Figura = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDaEmpresa = table.Column<string>(nullable: true),
                    NomeDoContato = table.Column<string>(nullable: true),
                    CargoDoContato = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ClientesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<int>(nullable: false),
                    ClientesId1 = table.Column<int>(nullable: true),
                    DataDoPedido = table.Column<DateTime>(nullable: true),
                    DataDeEntrega = table.Column<DateTime>(nullable: true),
                    DataDeEnvio = table.Column<DateTime>(nullable: true),
                    Frete = table.Column<decimal>(nullable: false),
                    NomeDestinatario = table.Column<string>(nullable: true),
                    EnderecoDestinatario = table.Column<string>(nullable: true),
                    CidadeDeDestino = table.Column<string>(nullable: true),
                    CEPdeDestino = table.Column<string>(nullable: true),
                    PaisdeDestino = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ClientesId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClientesId1",
                        column: x => x.ClientesId1,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    FornecedoresId = table.Column<int>(nullable: false),
                    CategoriasId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    NomedoProduto = table.Column<string>(nullable: true),
                    QuantidadePorUnidade = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    UnidadesEmEstoque = table.Column<int>(nullable: false),
                    UnidadesPedidas = table.Column<int>(nullable: false),
                    Descontinuado = table.Column<byte>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => new { x.FornecedoresId, x.CategoriasId });
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    ProdutosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<int>(nullable: false),
                    PedidosClientesId = table.Column<int>(nullable: true),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Desconto = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.ProdutosId);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidosClientesId",
                        column: x => x.PedidosClientesId,
                        principalTable: "Pedidos",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidosClientesId",
                table: "ItensPedidos",
                column: "PedidosClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesId1",
                table: "Pedidos",
                column: "ClientesId1");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriasId",
                table: "Produtos",
                column: "CategoriasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
