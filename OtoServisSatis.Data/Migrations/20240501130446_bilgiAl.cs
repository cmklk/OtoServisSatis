using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class bilgiAl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilgiAls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AracId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgiAls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BilgiAls_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BilgiAls");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 4, 29, 18, 0, 33, 362, DateTimeKind.Local).AddTicks(4951));
        }
    }
}
