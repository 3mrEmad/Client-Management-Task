using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client__Management_Task.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateofBirth", "Email", "FirstName", "LastName", "MaritalStatus", "MobileNumber" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3mr3mad74@gmail.com", "Amr", "Emad", 1, "01205890601" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateofBirth", "Email", "FirstName", "LastName", "MaritalStatus", "MobileNumber" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SayedFahmy33@gmail.com", "Sayed", "Fahmy", 0, "01105890804" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
