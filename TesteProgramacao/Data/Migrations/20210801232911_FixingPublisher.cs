using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteProgramacao.Data.Migrations
{
    public partial class FixingPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Publishers",
                newName: "Estate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estate",
                table: "Publishers",
                newName: "State");
        }
    }
}
