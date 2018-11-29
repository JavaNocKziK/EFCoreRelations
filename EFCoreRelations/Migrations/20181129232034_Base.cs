using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelations.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaModelId = table.Column<int>(nullable: true),
                    PlaceModelId = table.Column<int>(nullable: true),
                    SpaceModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonModel_AreaModel_AreaModelId",
                        column: x => x.AreaModelId,
                        principalTable: "AreaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonModel_PlaceModel_PlaceModelId",
                        column: x => x.PlaceModelId,
                        principalTable: "PlaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonModel_SpaceModel_SpaceModelId",
                        column: x => x.SpaceModelId,
                        principalTable: "SpaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonModel_AreaModelId",
                table: "PersonModel",
                column: "AreaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModel_PlaceModelId",
                table: "PersonModel",
                column: "PlaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModel_SpaceModelId",
                table: "PersonModel",
                column: "SpaceModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonModel");

            migrationBuilder.DropTable(
                name: "AreaModel");

            migrationBuilder.DropTable(
                name: "PlaceModel");

            migrationBuilder.DropTable(
                name: "SpaceModel");
        }
    }
}
