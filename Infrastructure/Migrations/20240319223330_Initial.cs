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
                name: "tb_Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Cliente", x => x.Id);
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
                    { new Guid("027d63c4-10b2-43bb-a8f1-ea99ca4e7ac7"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Grande", 9.00m },
                    { new Guid("0caaeb90-5a0c-4f0d-93a7-a927e2b2b481"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Pequena", 6.00m },
                    { new Guid("0f54e1b8-4a15-48bd-ad72-61f4b88cc067"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Misto", 3.00m },
                    { new Guid("121ab1c0-93d3-476b-aad3-614ec7ce9cb9"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamburguer", 8.00m },
                    { new Guid("13f1c9f5-ca6f-4481-a3c2-af4361be7d9e"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Media", 8.00m },
                    { new Guid("1ae10070-cce5-4b4a-9515-69035c4d57ee"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Media", 7.00m },
                    { new Guid("1bf9cf01-3de5-4aad-a621-7adf61d4f551"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 12 unidades", 16.00m },
                    { new Guid("229db5cc-5d2a-4ab4-8ce6-e9e6d7327288"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 4 unidades", 6.00m },
                    { new Guid("622f887b-2aa3-4b4f-aeb2-8c960a0cf960"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Nuggets 8 unidades", 12.00m },
                    { new Guid("82bcd324-7f8e-4233-8c68-71a996e08036"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Chocolate", 3.00m },
                    { new Guid("87e0031b-ec44-4b2d-9186-0716663ef0cc"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae de Chocolate", 6.00m },
                    { new Guid("8c481f8f-cbad-4dc7-9b62-b314277dc671"), new Guid("5117243c-b007-49e8-9a30-842ec79248ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola Grande", 10.00m },
                    { new Guid("8ee67648-5a9a-4e43-b882-0765021d7b5a"), new Guid("cf412102-35da-43d8-9c3c-b72546104c72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batata Frita Pequena", 5.00m },
                    { new Guid("909cd0ff-d8b8-42f0-abb1-5c2b334604d4"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheeseburger", 9.00m },
                    { new Guid("9afcfb67-8a5d-4dd9-afca-c9e4891b93f3"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorverte de Baunilha", 3.00m },
                    { new Guid("a321fbdb-3285-4d30-a255-4bba7faf5c2c"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae Misto", 6.00m },
                    { new Guid("c7790a29-5511-48a5-9420-3623b0e72965"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Tudo", 12.00m },
                    { new Guid("c7bf006c-eee1-4f74-a946-3c3c0ba6de7d"), new Guid("32f0c5f0-d9ba-40e2-8d7a-57eed4727e2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundae de Baunilha", 6.00m },
                    { new Guid("ca125de6-4860-419c-b54e-4bfa44df45f8"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Salada", 10.00m },
                    { new Guid("ef00ff16-6cfe-4d66-a7c3-cfb4a4260707"), new Guid("ada751db-8553-493f-b308-70bd29aed106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Bacon", 11.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Produto_CategoriaId",
                table: "tb_Produto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Cliente");

            migrationBuilder.DropTable(
                name: "tb_Produto");

            migrationBuilder.DropTable(
                name: "tb_Categoria");
        }
    }
}
