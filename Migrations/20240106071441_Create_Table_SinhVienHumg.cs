using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuuTienDat_174.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_SinhVienHumg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhVienHumgs",
                columns: table => new
                {
                    SoThuTu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaSinhVien = table.Column<string>(type: "TEXT", nullable: false),
                    TenSinhVien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienHumgs", x => x.SoThuTu);
                    table.ForeignKey(
                        name: "FK_SinhVienHumgs_SinhViens_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "MaSinhVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienHumgs_MaSinhVien",
                table: "SinhVienHumgs",
                column: "MaSinhVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVienHumgs");
        }
    }
}
