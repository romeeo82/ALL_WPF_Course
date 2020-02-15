using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRdatabase.Migrations
{
    public partial class frst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JOB_ID = table.Column<string>(maxLength: 10, nullable: false),
                    JOB_TITLE = table.Column<string>(maxLength: 35, nullable: true),
                    MIN_SALARY = table.Column<decimal>(nullable: false),
                    MAX_SALARY = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JOB_ID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    REGION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REGION_NAME = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.REGION_ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<string>(maxLength: 2, nullable: false),
                    REGION_NAME = table.Column<string>(maxLength: 25, nullable: true),
                    REGION_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.COUNTRY_ID);
                    table.ForeignKey(
                        name: "FK_Countries_Regions_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "Regions",
                        principalColumn: "REGION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LOCATION_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STREET_ADDRESS = table.Column<string>(maxLength: 25, nullable: true),
                    POSTAL_CODE = table.Column<string>(maxLength: 12, nullable: true),
                    CITY = table.Column<string>(maxLength: 30, nullable: true),
                    STATE_PROVINCE = table.Column<string>(maxLength: 12, nullable: true),
                    COUNTRY_ID = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LOCATION_ID);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalTable: "Countries",
                        principalColumn: "COUNTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_NAME = table.Column<string>(maxLength: 30, nullable: true),
                    MANAGER_ID = table.Column<int>(nullable: false),
                    LOCATION_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DEPARTMENT_ID);
                    table.ForeignKey(
                        name: "FK_Departments_Locations_LOCATION_ID",
                        column: x => x.LOCATION_ID,
                        principalTable: "Locations",
                        principalColumn: "LOCATION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobHistories",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    START_DATE = table.Column<DateTime>(nullable: false),
                    END_DATE = table.Column<DateTime>(nullable: false),
                    JOB_ID = table.Column<string>(maxLength: 10, nullable: true),
                    DEPARTMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistories", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_JobHistories_Departments_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "Departments",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobHistories_Jobs_JOB_ID",
                        column: x => x.JOB_ID,
                        principalTable: "Jobs",
                        principalColumn: "JOB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(maxLength: 20, nullable: true),
                    LAST_NAME = table.Column<string>(maxLength: 25, nullable: true),
                    EMAIL = table.Column<string>(maxLength: 25, nullable: true),
                    PHONE_NUMBER = table.Column<string>(maxLength: 20, nullable: true),
                    HIRE_DATE = table.Column<DateTime>(nullable: false),
                    JOB_ID = table.Column<string>(maxLength: 10, nullable: true),
                    JobHistoryEmployeeId = table.Column<int>(nullable: true),
                    SALARY = table.Column<decimal>(nullable: false),
                    COMMISSION_PCT = table.Column<decimal>(nullable: false),
                    MANAGER_ID = table.Column<int>(nullable: false),
                    DEPARTMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "Departments",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobHistories_JobHistoryEmployeeId",
                        column: x => x.JobHistoryEmployeeId,
                        principalTable: "JobHistories",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JOB_ID",
                        column: x => x.JOB_ID,
                        principalTable: "Jobs",
                        principalColumn: "JOB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_REGION_ID",
                table: "Countries",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LOCATION_ID",
                table: "Departments",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DEPARTMENT_ID",
                table: "Employees",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobHistoryEmployeeId",
                table: "Employees",
                column: "JobHistoryEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JOB_ID",
                table: "Employees",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DEPARTMENT_ID",
                table: "JobHistories",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_JOB_ID",
                table: "JobHistories",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_COUNTRY_ID",
                table: "Locations",
                column: "COUNTRY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobHistories");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
