using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Produto_tb_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tb_Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tb_Categoria",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Nome" },
                values: new object[,]
                {
                    { new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sobremesa" },
                    { new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bebida" },
                    { new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lanche" },
                    { new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acompanhamento" }
                });

            migrationBuilder.InsertData(
                table: "tb_Produto",
                columns: new[] { "Id", "CategoriaId", "DataAtualizacao", "DataCriacao", "Nome", "Valor" },
                values: new object[,]
                {
                    { new Guid("10555ee4-9481-463b-bc2b-dd00e010976c"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamburguer", 8.00m },
                    { new Guid("33383107-d781-4e9b-b281-4ec1352b51d7"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Tudo", 12.00m },
                    { new Guid("3861430a-eb94-421e-bf5c-7f014b7ebeb1"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae de Baunilha", 6.00m },
                    { new Guid("3d94904b-e331-4a6d-a78e-6229b898cc82"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Misto", 3.00m },
                    { new Guid("40d45609-f162-499e-bb3c-ba4fa7e35230"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae de Chocolate", 6.00m },
                    { new Guid("44d1a250-9f2c-4ebb-8b04-22ab9ad7aea5"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Grande", 10.00m },
                    { new Guid("4e2375bd-d9bd-42c2-9ab5-efcc7cb35462"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae Misto", 6.00m },
                    { new Guid("6dafec47-4fa2-4ba5-b445-10c8561a8079"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Salada", 10.00m },
                    { new Guid("80444055-c144-4bd2-af05-5ce8cc5f2659"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Pequena", 5.00m },
                    { new Guid("934375ac-5462-4f39-9f45-639c7eeb7484"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Media", 7.00m },
                    { new Guid("9bc769c0-f99c-45bc-8e14-1357f3a5773a"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheeseburger", 9.00m },
                    { new Guid("a232906d-2928-4024-89fc-81768ef1827f"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Chocolate", 3.00m },
                    { new Guid("b62ef0f5-18ff-4347-b60d-adb0e2e5f3bd"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 12 unidades", 16.00m },
                    { new Guid("b658d91f-22bf-483f-b069-a45f7cc85d63"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Media", 8.00m },
                    { new Guid("d05e8e24-f057-453b-9315-bce164c2bd53"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Baunilha", 3.00m },
                    { new Guid("d1b73e3d-ed7d-4b52-9562-62252c3aebd3"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Bacon", 11.00m },
                    { new Guid("d30b795b-a9f9-4d19-8580-95da502f09cf"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 4 unidades", 6.00m },
                    { new Guid("df63f480-629f-4c48-97e2-001b1129d1ad"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Grande", 9.00m },
                    { new Guid("f043487a-59dd-44da-a5fa-c1cb4b8300aa"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 8 unidades", 12.00m },
                    { new Guid("fb4aab78-6762-4f88-92ec-5e510c5506bb"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Pequena", 6.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Produto_CategoriaId",
                table: "tb_Produto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Produto");

            migrationBuilder.DropTable(
                name: "tb_Categoria");
        }
    }
}
