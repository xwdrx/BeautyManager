using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyManagerApp.DataBase.Migrations
{
    public partial class AddedCosmetologyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cosmetologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BeautyServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cosmetologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cosmetologies_beautyServices_BeautyServiceId",
                        column: x => x.BeautyServiceId,
                        principalTable: "beautyServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cosmetologies_BeautyServiceId",
                table: "cosmetologies",
                column: "BeautyServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cosmetologies");
        }
    }
}
