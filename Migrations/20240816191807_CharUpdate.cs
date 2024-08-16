using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empyreum.Migrations
{
    /// <inheritdoc />
    public partial class CharUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharID",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemServerId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Race = table.Column<string>(type: "TEXT", nullable: false),
                    Clan = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthday = table.Column<int>(type: "INTEGER", nullable: false),
                    Deity = table.Column<int>(type: "INTEGER", nullable: false),
                    Job = table.Column<int>(type: "INTEGER", nullable: false),
                    PhysicalDCName = table.Column<string>(type: "TEXT", nullable: false),
                    LogicalDCName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharID",
                table: "Items",
                column: "CharID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Character_CharID",
                table: "Items",
                column: "CharID",
                principalTable: "Character",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Character_CharID",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Items_CharID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CharID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemServerId",
                table: "Items");
        }
    }
}
