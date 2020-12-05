using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaGo.DAL.Migrations
{
    public partial class CustomerMedReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerMedReserves",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(nullable: true),
                    StockMedicineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMedReserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMedReserves_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMedReserves_StockMedicines_StockMedicineId",
                        column: x => x.StockMedicineId,
                        principalTable: "StockMedicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMedReserves_CustomerId",
                table: "CustomerMedReserves",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMedReserves_StockMedicineId",
                table: "CustomerMedReserves",
                column: "StockMedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMedReserves");
        }
    }
}
