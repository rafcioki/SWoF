using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EngineersAndRotaEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RotaEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngineerId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HoursInShift = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotaEntries_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Engineers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Bradley", "Buckley" },
                    { 2, "Melissa", "Hancock" },
                    { 3, "Chelsea", "Davidson" },
                    { 4, "Hayden", "Akhtar" },
                    { 5, "Lucy", "Wade" },
                    { 6, "James", "Harding" },
                    { 7, "Elizabeth", "Pratt" },
                    { 8, "Samuel", "Jenkins" },
                    { 9, "Brian", "Shugart" },
                    { 10, "Owen", "Stephenson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotaEntries_EngineerId",
                table: "RotaEntries",
                column: "EngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotaEntries");

            migrationBuilder.DropTable(
                name: "Engineers");
        }
    }
}
