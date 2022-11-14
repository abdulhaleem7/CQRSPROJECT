using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeDDD.Persistence.Migrations
{
    public partial class SeedingStudenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "Address", "CreatedBy", "CreatedOn", "EndDate", "LastModifiedBy", "LastModifiedOn", "Name", "PhoneNumber", "SchoolName", "StartDate" },
                values: new object[] { 1, null, "salaudeenhaleem7@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 12, 10, 54, 15, 352, DateTimeKind.Local).AddTicks(8701), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haleem", "09151073034", "GCI", new DateTime(2022, 10, 12, 10, 43, 32, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "Address", "CreatedBy", "CreatedOn", "EndDate", "LastModifiedBy", "LastModifiedOn", "Name", "PhoneNumber", "SchoolName", "StartDate" },
                values: new object[] { 2, null, "salaudeenhaleem77@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 12, 10, 54, 15, 352, DateTimeKind.Local).AddTicks(9023), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haleem1", "09151073033", "GCI Ibadan", new DateTime(2022, 10, 12, 10, 43, 32, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
