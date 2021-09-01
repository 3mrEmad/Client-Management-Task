using Microsoft.EntityFrameworkCore.Migrations;

namespace Client__Management_Task.Migrations
{
    public partial class AddStoredProcdure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"CREATE PROCEDURE MyClients
                               AS
                               SELECT * FROM Clients");

        }

        
    
            


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE  MyClients");
        }
    }
}
