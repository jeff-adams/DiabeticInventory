using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDIS.WebApp.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    StockNumber = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    UnitsOnHand = table.Column<int>(nullable: false),
                    ReorderPoint = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Stock Number", x => x.StockNumber);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    RxNumber = table.Column<string>(nullable: false),
                    RefillsRemaining = table.Column<int>(nullable: false),
                    LastRefillDate = table.Column<DateTime>(nullable: false),
                    StockNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription Number", x => x.RxNumber);
                    table.ForeignKey(
                        name: "FK_Prescription_Inventory_StockNumber",
                        column: x => x.StockNumber,
                        principalTable: "Inventory",
                        principalColumn: "StockNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_StockNumber",
                table: "Prescription",
                column: "StockNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
