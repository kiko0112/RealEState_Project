using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTRefreshTokenInDotNet6.Migrations
{
    /// <inheritdoc />
    public partial class AddWishListItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                table: "RealEStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompoundAmenities",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompoundAmenities", x => new { x.AmenitiesId, x.CompoundId });
                    table.ForeignKey(
                        name: "FK_CompoundAmenities_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompoundAmenities_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlansForCompound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlansForCompound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPlansForCompound_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlansForRealEState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Persenter = table.Column<int>(type: "int", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    RestPrice = table.Column<int>(type: "int", nullable: false),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    RealEStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlansForRealEState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPlansForRealEState_RealEStates_RealEStateId",
                        column: x => x.RealEStateId,
                        principalTable: "RealEStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates",
                column: "CompoundId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_PropertyTypeId",
                table: "RealEStates",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RealEStateId",
                table: "Photos",
                column: "RealEStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Compounds_DeveloperId",
                table: "Compounds",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_CompoundAmenities_CompoundId",
                table: "CompoundAmenities",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlansForCompound_CompoundId",
                table: "PaymentPlansForCompound",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlansForRealEState_RealEStateId",
                table: "PaymentPlansForRealEState",
                column: "RealEStateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compounds_Developers_DeveloperId",
                table: "Compounds",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_RealEStates_RealEStateId",
                table: "Photos",
                column: "RealEStateId",
                principalTable: "RealEStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_Compounds_CompoundId",
                table: "RealEStates",
                column: "CompoundId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_RealEStateTypes_PropertyTypeId",
                table: "RealEStates",
                column: "PropertyTypeId",
                principalTable: "RealEStateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compounds_Developers_DeveloperId",
                table: "Compounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_RealEStates_RealEStateId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_Compounds_CompoundId",
                table: "RealEStates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_RealEStateTypes_PropertyTypeId",
                table: "RealEStates");

            migrationBuilder.DropTable(
                name: "CompoundAmenities");

            migrationBuilder.DropTable(
                name: "PaymentPlansForCompound");

            migrationBuilder.DropTable(
                name: "PaymentPlansForRealEState");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_PropertyTypeId",
                table: "RealEStates");

            migrationBuilder.DropIndex(
                name: "IX_Photos_RealEStateId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Compounds_DeveloperId",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                table: "RealEStates");
        }
    }
}
