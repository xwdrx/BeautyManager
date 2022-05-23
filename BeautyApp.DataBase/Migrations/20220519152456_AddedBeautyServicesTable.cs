using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyManagerApp.DataBase.Migrations
{
    public partial class AddedBeautyServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "beautyServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeautySpecialistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beautyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beautyServices_beautySpecialists_BeautySpecialistId",
                        column: x => x.BeautySpecialistId,
                        principalTable: "beautySpecialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beautyServices_BeautySpecialistId",
                table: "beautyServices",
                column: "BeautySpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beautyServices");
        }
    }
}
