using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "MasterPlan",
                table: "Compounds");

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoURL",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MasterPlanURL",
                table: "Compounds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "LogoURL",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "MasterPlanURL",
                table: "Compounds");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Photos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Developers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "MasterPlan",
                table: "Compounds",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
