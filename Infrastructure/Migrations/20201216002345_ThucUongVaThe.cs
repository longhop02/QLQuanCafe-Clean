using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ThucUongVaThe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DSNU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdThe = table.Column<int>(type: "INTEGER", nullable: false),
                    IdNU = table.Column<int>(type: "INTEGER", nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    TongTien = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSNU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenNU = table.Column<string>(type: "TEXT", nullable: false),
                    DonGia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenThe = table.Column<string>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thes", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "HDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                    TaiKhoan = table.Column<string>(type: "TEXT", nullable: false),
                    TongTien = table.Column<int>(type: "INTEGER", nullable: false),
                    GiamGia = table.Column<int>(type: "INTEGER", nullable: false),
                    ThanhTien = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DSNU");

            migrationBuilder.DropTable(
                name: "NUs");

            migrationBuilder.DropTable(
                name: "Thes");
            migrationBuilder.DropTable(
                name: "HDs");
        }
    }
}
