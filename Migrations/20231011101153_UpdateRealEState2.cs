using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealEState2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompoundName",
                table: "RealEStates");

            migrationBuilder.DropColumn(
                name: "DeveloperName",
                table: "RealEStates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompoundName",
                table: "RealEStates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperName",
                table: "RealEStates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
