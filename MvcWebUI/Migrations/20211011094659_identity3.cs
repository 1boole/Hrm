using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcWebUI.Migrations
{
    public partial class identity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "CustomUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomUserId",
                table: "AspNetUsers",
                newName: "UserId");
        }
    }
}
