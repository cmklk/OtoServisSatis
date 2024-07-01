using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class bilgiAlModelMarka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Marka",
                table: "BilgiAls",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "BilgiAls",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 5, 25, 18, 54, 33, 219, DateTimeKind.Local).AddTicks(6424));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marka",
                table: "BilgiAls");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "BilgiAls");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 5, 25, 13, 56, 23, 843, DateTimeKind.Local).AddTicks(6651));
        }
    }
}
