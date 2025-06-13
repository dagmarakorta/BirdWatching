using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdWatching.Migrations
{
    /// <inheritdoc />
    public partial class AddControlCenterToSighting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlCenterId",
                table: "Sightings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ControlCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCenters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_ControlCenterId",
                table: "Sightings",
                column: "ControlCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sightings_ControlCenters_ControlCenterId",
                table: "Sightings",
                column: "ControlCenterId",
                principalTable: "ControlCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sightings_ControlCenters_ControlCenterId",
                table: "Sightings");

            migrationBuilder.DropTable(
                name: "ControlCenters");

            migrationBuilder.DropIndex(
                name: "IX_Sightings_ControlCenterId",
                table: "Sightings");

            migrationBuilder.DropColumn(
                name: "ControlCenterId",
                table: "Sightings");
        }
    }
}
