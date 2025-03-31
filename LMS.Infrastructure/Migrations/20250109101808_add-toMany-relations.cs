using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtoManyrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ModuleDocuments_ModuleId",
                table: "ModuleDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CourseDocuments_CourseId",
                table: "CourseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDocuments_ActivityId",
                table: "ActivityDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleDocuments_ModuleId",
                table: "ModuleDocuments",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_CourseId",
                table: "CourseDocuments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDocuments_ActivityId",
                table: "ActivityDocuments",
                column: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ModuleDocuments_ModuleId",
                table: "ModuleDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CourseDocuments_CourseId",
                table: "CourseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDocuments_ActivityId",
                table: "ActivityDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleDocuments_ModuleId",
                table: "ModuleDocuments",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_CourseId",
                table: "CourseDocuments",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDocuments_ActivityId",
                table: "ActivityDocuments",
                column: "ActivityId",
                unique: true);
        }
    }
}
