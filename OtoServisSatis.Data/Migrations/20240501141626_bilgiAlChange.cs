using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class bilgiAlChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BilgiAls_Araclar_AracId",
                table: "BilgiAls");

            migrationBuilder.DropIndex(
                name: "IX_BilgiAls_AracId",
                table: "BilgiAls");

            migrationBuilder.DropColumn(
                name: "AracId",
                table: "BilgiAls");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 5, 1, 17, 16, 26, 441, DateTimeKind.Local).AddTicks(5257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AracId",
                table: "BilgiAls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 5, 1, 16, 4, 45, 960, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.CreateIndex(
                name: "IX_BilgiAls_AracId",
                table: "BilgiAls",
                column: "AracId");

            migrationBuilder.AddForeignKey(
                name: "FK_BilgiAls_Araclar_AracId",
                table: "BilgiAls",
                column: "AracId",
                principalTable: "Araclar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
