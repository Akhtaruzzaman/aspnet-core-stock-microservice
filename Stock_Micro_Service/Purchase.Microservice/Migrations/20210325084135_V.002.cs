using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Purchase.Microservice.Migrations
{
    public partial class V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseMasterId",
                table: "PurchaseDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseMasterId",
                table: "PurchaseDetails",
                column: "PurchaseMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_PurchaseMaster_PurchaseMasterId",
                table: "PurchaseDetails",
                column: "PurchaseMasterId",
                principalTable: "PurchaseMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_PurchaseMaster_PurchaseMasterId",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_PurchaseMasterId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseMasterId",
                table: "PurchaseDetails");
        }
    }
}
