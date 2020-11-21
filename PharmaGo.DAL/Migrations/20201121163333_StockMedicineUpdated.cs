using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaGo.DAL.Migrations
{
    public partial class StockMedicineUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMedicines_Medicines_MedicineId",
                table: "StockMedicines");

            migrationBuilder.AlterColumn<long>(
                name: "MedicineId",
                table: "StockMedicines",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedicines_Medicines_MedicineId",
                table: "StockMedicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMedicines_Medicines_MedicineId",
                table: "StockMedicines");

            migrationBuilder.AlterColumn<long>(
                name: "MedicineId",
                table: "StockMedicines",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedicines_Medicines_MedicineId",
                table: "StockMedicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
