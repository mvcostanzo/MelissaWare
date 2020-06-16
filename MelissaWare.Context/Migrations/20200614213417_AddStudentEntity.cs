using Microsoft.EntityFrameworkCore.Migrations;

namespace MelissaWare.Context.Migrations
{
    public partial class AddStudentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    ClassroomKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentKey);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomKey",
                        column: x => x.ClassroomKey,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomKey",
                table: "Students",
                column: "ClassroomKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
