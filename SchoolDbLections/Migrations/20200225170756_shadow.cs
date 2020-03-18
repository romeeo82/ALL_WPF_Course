using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDbLections.Migrations
{
    public partial class shadow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "StudentCourses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "StudentCourses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "StudentAddresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "StudentAddresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Courses");
        }
    }
}
