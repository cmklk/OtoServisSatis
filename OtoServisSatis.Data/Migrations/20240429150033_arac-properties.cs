using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class aracproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Resim",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kilometre",
                table: "Araclar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vites",
                table: "Araclar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Yakit",
                table: "Araclar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 4, 29, 18, 0, 33, 362, DateTimeKind.Local).AddTicks(4951));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometre",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Vites",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Yakit",
                table: "Araclar");

            migrationBuilder.AlterColumn<string>(
                name: "Resim",
                table: "Sliders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 4, 22, 12, 51, 1, 244, DateTimeKind.Local).AddTicks(4177));
        }
    }
}
