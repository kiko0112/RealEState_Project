using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompound3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates");

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates",
                column: "CompoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates");

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates",
                column: "CompoundId",
                unique: true);
        }
    }
}
