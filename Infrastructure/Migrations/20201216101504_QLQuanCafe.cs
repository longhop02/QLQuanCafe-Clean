using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class QLQuanCafe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CTHDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdHD = table.Column<int>(type: "INTEGER", nullable: false),
                    IdNU = table.Column<int>(type: "INTEGER", nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    TongTien = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaiKhoan = table.Column<string>(type: "TEXT", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TongTien = table.Column<int>(type: "INTEGER", nullable: false),
                    GiamGia = table.Column<int>(type: "INTEGER", nullable: false),
                    ThanhTien = table.Column<int>(type: "INTEGER", nullable: false),
                    TrangThai = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTHDs");

            migrationBuilder.DropTable(
                name: "HDs");
        }
    }
}
