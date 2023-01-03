using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amaris.Consolidacao.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserEstructureSecount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Consolidacao");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity",
                newName: "AspNetUsers",
                newSchema: "Consolidacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Consolidacao",
                newName: "AspNetUsers",
                newSchema: "Identity");
        }
    }
}
