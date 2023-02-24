using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission8_Team0210.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Other" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "TaskId", "CategoryId", "Date", "IsCompleted", "Quadrant", "Task" },
                values: new object[] { 1, 4, "02/27/2023", false, 2, "Call mistering sisters!" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "TaskId", "CategoryId", "Date", "IsCompleted", "Quadrant", "Task" },
                values: new object[] { 2, 2, "02/24/2023", false, 1, "IS 413 Mission 8" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "TaskId", "CategoryId", "Date", "IsCompleted", "Quadrant", "Task" },
                values: new object[] { 3, 2, "02/26/2023", false, 3, "Call home for tuition money!" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "TaskId", "CategoryId", "Date", "IsCompleted", "Quadrant", "Task" },
                values: new object[] { 4, 5, null, false, 4, "Read through email from friends on mission" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lists");
        }
    }
}
