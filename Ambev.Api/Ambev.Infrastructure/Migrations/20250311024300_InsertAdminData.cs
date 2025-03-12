using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir valores padrão na tabela admins
            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[,]
                {
            { "admin1@teste.com.br", "46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5" },
            { "admin2@teste.com.br", "46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover os dados inseridos
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Email",
                keyValues: new object[]
                {
            "admin1@teste.com.br",
            "admin2@teste.com.br"
                });
        }
    }
}
