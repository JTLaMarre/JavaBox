using Microsoft.EntityFrameworkCore.Migrations;

namespace HostAPI.Migrations
{
    public partial class poop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    RoomCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gameEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.RoomCode);
                    table.ForeignKey(
                        name: "FK_Hosts_Games_gameEntityId",
                        column: x => x.gameEntityId,
                        principalTable: "Games",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    HostRoomcode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.name);
                    table.ForeignKey(
                        name: "FK_Players_Hosts_HostRoomcode",
                        column: x => x.HostRoomcode,
                        principalTable: "Hosts",
                        principalColumn: "RoomCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_gameEntityId",
                table: "Hosts",
                column: "gameEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_HostRoomcode",
                table: "Players",
                column: "HostRoomcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
