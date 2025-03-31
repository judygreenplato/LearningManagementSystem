using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "ActivityTypeId", "Type" },
                values: new object[] { 1, "Föreläsning" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, "Lorem ipsum odor amet.", new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullstack.NET 2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, 1, "C# module", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#-basics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityTypeId", "Description", "EndDate", "ModuleId", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Asp.Net", new DateTime(2025, 1, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, "Föreläsning - C#", new DateTime(2025, 1, 9, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Spring Boot", new DateTime(2025, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, "Föreläsning - Java", new DateTime(2025, 1, 10, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "ActivityTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);
        }
    }
}
