using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_thinhvdph26886.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sản Phẩm",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sản Phẩm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vai Trò",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vai Trò", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Role = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_NguoiDung_Vai Trò_Role",
                        column: x => x.Role,
                        principalTable: "Vai Trò",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giỏ Hàng",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giỏ Hàng", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Giỏ Hàng_NguoiDung_UserID",
                        column: x => x.UserID,
                        principalTable: "NguoiDung",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hóa Đơn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hóa Đơn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hóa Đơn_NguoiDung_UserID",
                        column: x => x.UserID,
                        principalTable: "NguoiDung",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giỏ Hàng Chi Tiết",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IDSP = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giỏ Hàng Chi Tiết", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Giỏ Hàng Chi Tiết_Giỏ Hàng_UserID",
                        column: x => x.UserID,
                        principalTable: "Giỏ Hàng",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giỏ Hàng Chi Tiết_Sản Phẩm_IDSP",
                        column: x => x.IDSP,
                        principalTable: "Sản Phẩm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hóa Đơn Chi Tiết",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHD = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdSP = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hóa Đơn Chi Tiết", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hóa Đơn Chi Tiết_Hóa Đơn_IdHD",
                        column: x => x.IdHD,
                        principalTable: "Hóa Đơn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hóa Đơn Chi Tiết_Sản Phẩm_IdSP",
                        column: x => x.IdSP,
                        principalTable: "Sản Phẩm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giỏ Hàng Chi Tiết_IDSP",
                table: "Giỏ Hàng Chi Tiết",
                column: "IDSP");

            migrationBuilder.CreateIndex(
                name: "IX_Giỏ Hàng Chi Tiết_UserID",
                table: "Giỏ Hàng Chi Tiết",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn_UserID",
                table: "Hóa Đơn",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn Chi Tiết_IdHD",
                table: "Hóa Đơn Chi Tiết",
                column: "IdHD");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn Chi Tiết_IdSP",
                table: "Hóa Đơn Chi Tiết",
                column: "IdSP");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_Role",
                table: "NguoiDung",
                column: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giỏ Hàng Chi Tiết");

            migrationBuilder.DropTable(
                name: "Hóa Đơn Chi Tiết");

            migrationBuilder.DropTable(
                name: "Giỏ Hàng");

            migrationBuilder.DropTable(
                name: "Hóa Đơn");

            migrationBuilder.DropTable(
                name: "Sản Phẩm");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Vai Trò");
        }
    }
}
