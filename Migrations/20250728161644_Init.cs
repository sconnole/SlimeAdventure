using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlimeAdventure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentRoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NorthRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    SouthRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    EastRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    WestRoomId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_EastRoomId",
                        column: x => x.EastRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_NorthRoomId",
                        column: x => x.NorthRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_SouthRoomId",
                        column: x => x.SouthRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_WestRoomId",
                        column: x => x.WestRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EastRoomId",
                table: "Rooms",
                column: "EastRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_NorthRoomId",
                table: "Rooms",
                column: "NorthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SouthRoomId",
                table: "Rooms",
                column: "SouthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WestRoomId",
                table: "Rooms",
                column: "WestRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
