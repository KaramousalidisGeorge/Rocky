using Microsoft.EntityFrameworkCore.Migrations;

namespace Rocky.Migrations
{
    public partial class AddQuestionToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    surveyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Schema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surveyVersion = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publishType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.surveyId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    questionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootsurveyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.questionId);
                    table.ForeignKey(
                        name: "FK_Question_Root_RootsurveyId",
                        column: x => x.RootsurveyId,
                        principalTable: "Root",
                        principalColumn: "surveyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_RootsurveyId",
                table: "Question",
                column: "RootsurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Root");
        }
    }
}
