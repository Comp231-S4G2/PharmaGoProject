using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaGo.DAL.Migrations
{
    public partial class PrescriptionDrugBOL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedDemands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockMedicineId = table.Column<long>(nullable: false),
                    CustomerPrescriptionId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    InStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedDemands_CustomerPrescriptions_CustomerPrescriptionId",
                        column: x => x.CustomerPrescriptionId,
                        principalTable: "CustomerPrescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedDemands_StockMedicines_StockMedicineId",
                        column: x => x.StockMedicineId,
                        principalTable: "StockMedicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedDemands_CustomerPrescriptionId",
                table: "MedDemands",
                column: "CustomerPrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedDemands_StockMedicineId",
                table: "MedDemands",
                column: "StockMedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedDemands");
        }
    }
}
