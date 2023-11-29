using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealEState3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_RealEStateTypes_PropertyTypeId",
                table: "RealEStates");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_PropertyTypeId",
                table: "RealEStates");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                table: "RealEStates");

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_RealStatesTypeId",
                table: "RealEStates",
                column: "RealStatesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_RealEStateTypes_RealStatesTypeId",
                table: "RealEStates",
                column: "RealStatesTypeId",
                principalTable: "RealEStateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_RealEStateTypes_RealStatesTypeId",
                table: "RealEStates");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_RealStatesTypeId",
                table: "RealEStates");

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                table: "RealEStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_PropertyTypeId",
                table: "RealEStates",
                column: "PropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_RealEStateTypes_PropertyTypeId",
                table: "RealEStates",
                column: "PropertyTypeId",
                principalTable: "RealEStateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
