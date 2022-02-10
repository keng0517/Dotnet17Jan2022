using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_email", "user_name", "user_password" },
                values: new object[] { 101, "raindy@email.com", "Raindy Keng", "123123Aa@" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_email", "user_name", "user_password" },
                values: new object[] { 102, "jane123123@email.com", "Jane Wong", "123123Aa@" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_email", "user_name", "user_password" },
                values: new object[] { 103, "jupiterleong@email.com", "Jupiter Leong", "123123Aa@" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
