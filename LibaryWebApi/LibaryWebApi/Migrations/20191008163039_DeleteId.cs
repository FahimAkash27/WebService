using Microsoft.EntityFrameworkCore.Migrations;

namespace LibaryWebApi.Migrations
{
    public partial class DeleteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedBookInfos",
                table: "IssuedBookInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IssuedBookInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedBookInfos",
                table: "IssuedBookInfos",
                columns: new[] { "StudentId", "BookInfoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedBookInfos",
                table: "IssuedBookInfos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IssuedBookInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedBookInfos",
                table: "IssuedBookInfos",
                columns: new[] { "StudentId", "BookInfoId", "Id" });
        }
    }
}
