using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.AuthLibrary.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCourses_Courses_CourseDetailsId",
                table: "AvailableCourses");

            migrationBuilder.AddColumn<int>(
                name: "CourseStatus",
                table: "EnrolledCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MentorLname",
                table: "AvailableCourses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MentorFname",
                table: "AvailableCourses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MentorEmail",
                table: "AvailableCourses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseDetailsId",
                table: "AvailableCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "68a24208-716b-4f38-9044-cad4475c8636");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fecabd15-ac48-4a15-900b-403d2ff46c36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d3b5c09c-d8d8-4188-b586-eef4a5088dea");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCourses_Courses_CourseDetailsId",
                table: "AvailableCourses",
                column: "CourseDetailsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCourses_Courses_CourseDetailsId",
                table: "AvailableCourses");

            migrationBuilder.DropColumn(
                name: "CourseStatus",
                table: "EnrolledCourses");

            migrationBuilder.AlterColumn<string>(
                name: "MentorLname",
                table: "AvailableCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MentorFname",
                table: "AvailableCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MentorEmail",
                table: "AvailableCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CourseDetailsId",
                table: "AvailableCourses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCourses_Courses_CourseDetailsId",
                table: "AvailableCourses",
                column: "CourseDetailsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
