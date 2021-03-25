using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Microservice.Migrations
{
    public partial class V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalesMasterId",
                table: "SalesDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                table: "SalesDetails",
                column: "SalesMasterId",
                principalTable: "SalesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesMaster_SalesMasterId",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_SalesMasterId",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "SalesMasterId",
                table: "SalesDetails");
        }
    }
}
