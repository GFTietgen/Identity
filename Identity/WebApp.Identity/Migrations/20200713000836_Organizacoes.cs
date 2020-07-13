using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Identity.Migrations
{
    public partial class Organizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "AspNetUsers");
        }
    }
}
