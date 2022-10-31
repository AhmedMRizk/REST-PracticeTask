using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestPracticeTask.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(24,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ac12210a-1419-49d6-8f4b-da20b0ddd10f"), "TVs" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("dfef3a8c-a6e2-4c54-89aa-cdcdeed7ec09"), "Cars" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImgUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("049abed8-0458-45a9-ba41-2d95fc45152d"), new Guid("ac12210a-1419-49d6-8f4b-da20b0ddd10f"), "https://en.wikipedia.org/wiki/Sharp_Corporation#/media/File:Sharp_C1_NES_TV_14C-C1F.png", "Old Sharp TV", 335m, 1 },
                    { new Guid("324f1a6a-b551-4a5a-a852-09fae0dbbc2a"), new Guid("dfef3a8c-a6e2-4c54-89aa-cdcdeed7ec09"), "https://en.wikipedia.org/wiki/Honda#/media/File:Honda_T360_1963_in_Honda_Collection_Hall.jpg", "Honda T360", 500000m, 2 },
                    { new Guid("6a275163-8d3e-491c-9bb0-c49026519070"), new Guid("dfef3a8c-a6e2-4c54-89aa-cdcdeed7ec09"), "https://en.wikipedia.org/wiki/BMW#/media/File:2018_BMW_X2_xDrive20D_M_Sport_X_Automatic_2.0.jpg", "BMW X2", 800000m, 3 },
                    { new Guid("dd623036-e8fc-44d7-b8ed-4c7d4aba84eb"), new Guid("dfef3a8c-a6e2-4c54-89aa-cdcdeed7ec09"), "https://en.wikipedia.org/wiki/Mercedes-Benz#/media/File:Mercedes-Benz_W223_IMG_3951.jpg", "Mercedes S-Class", 1500000m, 6 },
                    { new Guid("f96e8bf1-606b-47b0-9805-55442d4cbcdb"), new Guid("ac12210a-1419-49d6-8f4b-da20b0ddd10f"), "https://en.wikipedia.org/wiki/Samsung_Electronics#/media/File:Samsung_UN105S9_20140127.jpg", "Samsung TV", 5211m, 55 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
