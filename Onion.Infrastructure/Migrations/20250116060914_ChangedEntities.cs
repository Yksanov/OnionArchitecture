using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Classrooms_ClassroomId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TrialLessons");

            migrationBuilder.RenameColumn(
                name: "Passed",
                table: "TrialLessons",
                newName: "PassedCount");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "TrialLessons",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Invited",
                table: "TrialLessons",
                newName: "InvitedCount");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Schedules",
                newName: "Day");

            migrationBuilder.AddColumn<int>(
                name: "CameCount",
                table: "TrialLessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupTypeId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonNameId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTypeId",
                table: "Groups",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LessonNameId",
                table: "Groups",
                column: "LessonNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ScheduleId",
                table: "Groups",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Classrooms_ClassroomId",
                table: "Groups",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GroupTypes_GroupTypeId",
                table: "Groups",
                column: "GroupTypeId",
                principalTable: "GroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_LessonNames_LessonNameId",
                table: "Groups",
                column: "LessonNameId",
                principalTable: "LessonNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Classrooms_ClassroomId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GroupTypes_GroupTypeId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_LessonNames_LessonNameId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupTypeId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_LessonNameId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ScheduleId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CameCount",
                table: "TrialLessons");

            migrationBuilder.DropColumn(
                name: "GroupTypeId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "LessonNameId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "PassedCount",
                table: "TrialLessons",
                newName: "Passed");

            migrationBuilder.RenameColumn(
                name: "InvitedCount",
                table: "TrialLessons",
                newName: "Invited");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "TrialLessons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Schedules",
                newName: "DayOfWeek");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TrialLessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Groups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Groups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Classrooms_ClassroomId",
                table: "Groups",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
