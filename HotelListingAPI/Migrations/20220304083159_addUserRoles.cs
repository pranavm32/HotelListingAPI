using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListingAPI.Migrations
{
    public partial class addUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8afc5a1-0213-477e-a941-0881a00fffa8", "4def354f-8e36-4c5f-becf-e6fa95ca5fff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be6b4405-b311-4a7e-8920-c0a1b3ef84e0", "e7dd0f39-f0f2-46c1-863d-055beb5c7432", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8afc5a1-0213-477e-a941-0881a00fffa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be6b4405-b311-4a7e-8920-c0a1b3ef84e0");
        }
    }
}
