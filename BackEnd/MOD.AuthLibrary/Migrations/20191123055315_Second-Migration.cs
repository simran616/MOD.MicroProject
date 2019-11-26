using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.AuthLibrary.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AvailableCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDetailsId = table.Column<int>(nullable: true),
                    MentorFname = table.Column<string>(nullable: true),
                    MentorLname = table.Column<string>(nullable: true),
                    MentorEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableCourses_Courses_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableCoursesId = table.Column<int>(nullable: true),
                    StudentFname = table.Column<string>(nullable: true),
                    StudentLname = table.Column<string>(nullable: true),
                    StudentEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_AvailableCourses_AvailableCoursesId",
                        column: x => x.AvailableCoursesId,
                        principalTable: "AvailableCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9c56dd0e-a04a-4189-a008-b8c8605c4bf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "632810a9-26cc-460b-8c77-40c2e4458605");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a9a94e5b-6767-4dad-8339-b6b06f5924a5");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableCourses_CourseDetailsId",
                table: "AvailableCourses",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_AvailableCoursesId",
                table: "EnrolledCourses",
                column: "AvailableCoursesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolledCourses");

            migrationBuilder.DropTable(
                name: "AvailableCourses");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cac9106e-68bf-4e4a-926e-cfd04cbb9cf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5bcee798-f3ff-4244-aef4-2844dab4c987");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "b5907e4d-dea8-4330-a830-7771d4195f8d");
        }
    }
}
