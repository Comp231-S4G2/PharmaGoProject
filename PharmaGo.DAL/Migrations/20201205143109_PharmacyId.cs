using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaGo.DAL.Migrations
{
    public partial class PharmacyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMedicines_Pharmacies_PharmacyId",
                table: "StockMedicines");

            migrationBuilder.DropColumn(
                name: "PharmaId",
                table: "StockMedicines");

            migrationBuilder.AlterColumn<long>(
                name: "PharmacyId",
                table: "StockMedicines",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedicines_Pharmacies_PharmacyId",
                table: "StockMedicines",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMedicines_Pharmacies_PharmacyId",
                table: "StockMedicines");

            migrationBuilder.AlterColumn<long>(
                name: "PharmacyId",
                table: "StockMedicines",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PharmaId",
                table: "StockMedicines",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedicines_Pharmacies_PharmacyId",
                table: "StockMedicines",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
