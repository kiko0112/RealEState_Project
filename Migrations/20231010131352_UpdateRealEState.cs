using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealEState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoofArea",
                table: "RealEStates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RoofArea",
                table: "RealEStates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
