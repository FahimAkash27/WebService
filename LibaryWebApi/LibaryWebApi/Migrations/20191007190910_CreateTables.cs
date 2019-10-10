using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibaryWebApi.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInfos",
                columns: table => new
                {
                    BookInfoId = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfos", x => x.BookInfoId);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FineAmount = table.Column<double>(nullable: false,defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssuedBookInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    BookInfoId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    Returned = table.Column<bool>(nullable: false,defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedBookInfos", x => new { x.StudentId, x.BookInfoId, x.Id });
                    table.ForeignKey(
                        name: "FK_IssuedBookInfos_BookInfos_BookInfoId",
                        column: x => x.BookInfoId,
                        principalTable: "BookInfos",
                        principalColumn: "BookInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuedBookInfos_StudentInfos_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBookInfos_BookInfoId",
                table: "IssuedBookInfos",
                column: "BookInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuedBookInfos");

            migrationBuilder.DropTable(
                name: "BookInfos");

            migrationBuilder.DropTable(
                name: "StudentInfos");
        }
    }
}
