using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day19Project.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Pic", "Price" },
                values: new object[] { 101, "Drop down any product description here.", "Super Fresh Banana", "/images/Banana.jpg", 88.879999999999995 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Pic", "Price" },
                values: new object[] { 102, "Drop down any product description here.", "Super Crunchy Biscuit", "/images/Biscuit.jpg", 12.880000000000001 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Pic", "Price" },
                values: new object[] { 103, "Drop down any product description here.", "No Brand Polo-T", "/images/PoloT.jpg", 23.879999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
