using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class odai1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hourlySale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandCookieId = table.Column<int>(type: "int", nullable: false),
                    salesvalue = table.Column<int>(type: "int", nullable: false),
                    cookieStandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hourlySale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hourlySale_CookieStands_cookieStandId",
                        column: x => x.cookieStandId,
                        principalTable: "CookieStands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CookieStands",
                columns: new[] { "Id", "AverageCookiesPerSale", "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[,]
                {
                    { 1, 5.5, "d1", "a", 22, 11, "1" },
                    { 2, 5.5, "d2", "b", 44, 22, "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_hourlySale_cookieStandId",
                table: "hourlySale",
                column: "cookieStandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hourlySale");

            migrationBuilder.DropTable(
                name: "CookieStands");
        }
    }
}
