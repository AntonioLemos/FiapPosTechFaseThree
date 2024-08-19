using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDD",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Regiao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DDDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONTATO_DDD_DDDId",
                        column: x => x.DDDId,
                        principalTable: "DDD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DDD",
                columns: new[] { "Id", "Codigo", "Estado", "Regiao" },
                values: new object[,]
                {
                    { new Guid("03f1a2f2-a352-4202-9595-b103bad12057"), 22, "Rio de Janeiro", "Sudeste" },
                    { new Guid("0418ebf8-99b0-47cd-82aa-f57f227a22be"), 85, "Ceará", "Nordeste" },
                    { new Guid("04d9cde8-e367-4854-8c8c-fe61df7462c8"), 54, "Rio Grande do Sul", "Sul" },
                    { new Guid("075af964-e61d-469d-92d4-a54c0958442c"), 45, "Paraná", "Sul" },
                    { new Guid("11111111-1111-1111-1111-111111111111"), 11, "São Paulo", "Sudeste" },
                    { new Guid("12a9b2f5-b7c0-4bd1-8e83-3d09d50a0329"), 75, "Bahia", "Nordeste" },
                    { new Guid("1d8e6efa-f843-4fba-8fba-863aab670d59"), 15, "São Paulo", "Sudeste" },
                    { new Guid("1ebba230-7440-422b-860d-c8ade9f2d935"), 99, "Maranhão", "Nordeste" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 12, "São Paulo", "Sudeste" },
                    { new Guid("2315103b-3bd8-42af-9ee3-11b82ceab16d"), 28, "Espírito Santo", "Sudeste" },
                    { new Guid("24f6d0d7-600b-4ae8-9343-1309fcbfa5aa"), 64, "Goiás", "Centro-Oeste" },
                    { new Guid("25c44ca7-daa7-4bbd-920b-c4a2def2adcc"), 88, "Ceará", "Nordeste" },
                    { new Guid("26302019-4b3c-458c-a9a8-c3bcc99f58a9"), 42, "Paraná", "Sul" },
                    { new Guid("2862c5ff-ff85-4e94-93da-5d3269a96b9c"), 16, "São Paulo", "Sudeste" },
                    { new Guid("3a44a31b-9e47-4ee1-b911-10fe7bf34d2b"), 71, "Bahia", "Nordeste" },
                    { new Guid("453572b4-9a00-45bc-9a08-8b4fd9e0e70f"), 68, "Acre", "Norte" },
                    { new Guid("49ad353b-ea45-430d-a06b-1505dae9d57e"), 97, "Amazonas", "Norte" },
                    { new Guid("5432ac85-f7b9-4d07-bf65-dae8dc262177"), 83, "Paraíba", "Nordeste" },
                    { new Guid("54c60e50-fc48-44c7-9f95-c446eaa01916"), 21, "Rio de Janeiro", "Sudeste" },
                    { new Guid("5b579462-e132-4d78-9491-6dd17663458a"), 48, "Santa Catarina", "Sul" },
                    { new Guid("64a2206f-9dca-4b1e-825c-16ea80b2ce08"), 44, "Paraná", "Sul" },
                    { new Guid("650702c5-9eb0-47ab-91c8-f3b4ace89ce0"), 63, "Tocantins", "Norte" },
                    { new Guid("6530270f-c2dd-4200-b6e1-3e6984150873"), 34, "Minas Gerais", "Sudeste" },
                    { new Guid("6d0ad134-73ac-4934-9071-a76b66cdc9e2"), 24, "Rio de Janeiro", "Sudeste" },
                    { new Guid("7c84538b-f945-43bb-8b51-600c8831e8d7"), 27, "Espírito Santo", "Sudeste" },
                    { new Guid("7ce1c6a9-d187-4cb8-8dd6-49788d558ea3"), 89, "Piauí", "Nordeste" },
                    { new Guid("8124dbe8-78a9-4d40-92ac-9c0b0fe8cb1e"), 41, "Paraná", "Sul" },
                    { new Guid("875d3b61-dde6-4299-85ec-7b9efff292f9"), 91, "Pará", "Norte" },
                    { new Guid("8b2143c0-7db0-4319-9d63-893aecbbdc78"), 37, "Minas Gerais", "Sudeste" },
                    { new Guid("9642aed1-d9db-4ef4-8f54-0454e3205328"), 51, "Rio Grande do Sul", "Sul" },
                    { new Guid("96ee8338-0c3d-423c-8303-9ee16a08a665"), 62, "Goiás", "Centro-Oeste" },
                    { new Guid("9ae73451-b8ef-428b-9102-c26bae7183ce"), 84, "Rio Grande do Norte", "Nordeste" },
                    { new Guid("9b12d653-b4f4-4350-bb38-4cfe764ddeb9"), 87, "Pernambuco", "Nordeste" },
                    { new Guid("9c09b143-59be-442f-b3a1-463fd61fdc31"), 43, "Paraná", "Sul" },
                    { new Guid("9fde129c-622a-4a37-9fe3-b52c64cb2a6f"), 81, "Pernambuco", "Nordeste" },
                    { new Guid("a0769d54-65f3-4acd-826f-83e0384fa400"), 96, "Amapá", "Norte" },
                    { new Guid("a11b2629-e02e-4822-94be-6eb94e4e3548"), 86, "Piauí", "Nordeste" },
                    { new Guid("a589cd12-8bcc-4631-b29c-d7f2d7b488b8"), 77, "Bahia", "Nordeste" },
                    { new Guid("a9eea613-ed71-4be9-99d6-b7a3220bdfe5"), 14, "São Paulo", "Sudeste" },
                    { new Guid("ab4e7d35-0be4-46ba-8711-9b1023ff21d2"), 66, "Mato Grosso", "Centro-Oeste" },
                    { new Guid("b4527afd-3571-495a-98f7-29ba1efb85c6"), 94, "Pará", "Norte" },
                    { new Guid("b5389950-de9a-47de-8685-b28673d2ba30"), 19, "São Paulo", "Sudeste" },
                    { new Guid("b63e0c50-77f3-4532-ad77-6ef9fa296e78"), 49, "Santa Catarina", "Sul" },
                    { new Guid("b7850030-b848-45c0-a89a-7f7273b7452d"), 53, "Rio Grande do Sul", "Sul" },
                    { new Guid("bacef241-268f-46b3-a531-b5eb47121b2f"), 73, "Bahia", "Nordeste" },
                    { new Guid("bda41bfe-e9b5-4bba-93c7-60c47a938322"), 67, "Mato Grosso do Sul", "Centro-Oeste" },
                    { new Guid("c12a95a2-70ad-4482-9552-39ae828e8c0b"), 69, "Rondônia", "Norte" },
                    { new Guid("c1b58b0b-4699-472e-a7b6-d681fd9f5624"), 32, "Minas Gerais", "Sudeste" },
                    { new Guid("c2038bb9-e32c-48ba-8265-79807167625e"), 93, "Pará", "Norte" },
                    { new Guid("c42e91b8-d801-4243-a915-dda61ce7dbe6"), 95, "Roraima", "Norte" },
                    { new Guid("c7890733-04f6-4e79-8a6f-0186784d7136"), 92, "Amazonas", "Norte" },
                    { new Guid("c93eddc8-4753-45be-8822-c86924d88cd9"), 17, "São Paulo", "Sudeste" },
                    { new Guid("cfb828bb-eaee-4243-8aed-13e6ef0458f7"), 65, "Mato Grosso", "Centro-Oeste" },
                    { new Guid("d1559da8-beea-4f90-b805-b2834237c532"), 33, "Minas Gerais", "Sudeste" },
                    { new Guid("d54c8bc0-41e0-4365-bb7f-1bb699bad816"), 46, "Paraná", "Sul" },
                    { new Guid("d6932647-cfe3-4d5d-9da1-fa306a20dbb4"), 82, "Alagoas", "Nordeste" },
                    { new Guid("d6ce0476-3621-4cf4-b46a-47ae94ffc3f7"), 47, "Santa Catarina", "Sul" },
                    { new Guid("d7d845ae-9254-4c2c-bbc0-6b612b6dc781"), 55, "Rio Grande do Sul", "Sul" },
                    { new Guid("d9871204-eb33-4621-9782-9e39e030af52"), 38, "Minas Gerais", "Sudeste" },
                    { new Guid("dd4dfa12-9d96-4957-8a3e-7df07102ab47"), 98, "Maranhão", "Nordeste" },
                    { new Guid("dd4ee5ec-0b15-47a6-9324-c5e1cf4acb94"), 79, "Sergipe", "Nordeste" },
                    { new Guid("edb50bf2-50be-4425-b170-921e0901fa53"), 18, "São Paulo", "Sudeste" },
                    { new Guid("f012ec0c-68ab-4fac-b633-14bc9418ecf1"), 35, "Minas Gerais", "Sudeste" },
                    { new Guid("f4324233-1ba7-4efc-96f4-6f8e43b55404"), 74, "Bahia", "Nordeste" },
                    { new Guid("f813b723-166c-47c6-bd4a-1b6333273974"), 61, "Distrito Federal", "Centro-Oeste" },
                    { new Guid("fb6710a1-b4f1-4428-9640-062f0a4edab8"), 13, "São Paulo", "Sudeste" },
                    { new Guid("fceaf9ab-cae2-4429-84eb-00516b7155f4"), 31, "Minas Gerais", "Sudeste" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_DDDId",
                table: "CONTATO",
                column: "DDDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "DDD");
        }
    }
}
