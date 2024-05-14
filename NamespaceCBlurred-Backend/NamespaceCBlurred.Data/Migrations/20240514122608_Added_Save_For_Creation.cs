using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamespaceCBlurred.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Save_For_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreationSoundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoundId = table.Column<int>(type: "int", nullable: false),
                    CreationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreationSoundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreationSoundItems_Creations_CreationId",
                        column: x => x.CreationId,
                        principalTable: "Creations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreationSoundItems_Sounds_SoundId",
                        column: x => x.SoundId,
                        principalTable: "Sounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreationSoundItems_CreationId",
                table: "CreationSoundItems",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreationSoundItems_SoundId",
                table: "CreationSoundItems",
                column: "SoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreationSoundItems");

            migrationBuilder.DropTable(
                name: "Creations");
        }
    }
}
