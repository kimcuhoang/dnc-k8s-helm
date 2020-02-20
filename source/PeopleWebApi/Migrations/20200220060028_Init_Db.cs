using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleWebApi.Migrations
{
    public partial class Init_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fullname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Fullname" },
                values: new object[] { new Guid("0b246ac8-6d72-4389-9ebd-a85e63341d8d"), "Person-1-Fullname" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Fullname" },
                values: new object[] { new Guid("b8cc595b-b7b1-4626-ac89-589cca7a4b1b"), "Person-2-Fullname" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Fullname" },
                values: new object[] { new Guid("162c1866-4902-44ff-ae6f-253a6115aca8"), "Person-3-Fullname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
