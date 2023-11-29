using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEStateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BUA = table.Column<double>(type: "float", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathtrooms = table.Column<int>(type: "int", nullable: false),
                    DeliveryIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompoundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithGardien = table.Column<bool>(type: "bit", nullable: false),
                    GardienArea = table.Column<double>(type: "float", nullable: false),
                    WithRoof = table.Column<bool>(type: "bit", nullable: false),
                    RoofArea = table.Column<double>(type: "float", nullable: false),
                    RoofPentHouse = table.Column<double>(type: "float", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false),
                    RealStatesTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEStates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEStates");
        }
    }
}
