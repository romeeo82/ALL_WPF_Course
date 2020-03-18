using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDbLections.Migrations
{
    public partial class createProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetStudents]
@FirstName varchar(50)
AS
BEGIN
SET NOCOUNT ON;
select * from Students where Name like @FirstName + '%'
END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
