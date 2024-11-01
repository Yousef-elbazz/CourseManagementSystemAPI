using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class EditingBehaviorToRestrictByElbaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "course_topicid_foreign",
                table: "course");

            migrationBuilder.AddForeignKey(
                name: "course_topicid_foreign",
                table: "course",
                column: "TopicID",
                principalTable: "topic",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "course_topicid_foreign",
                table: "course");

            migrationBuilder.AddForeignKey(
                name: "course_topicid_foreign",
                table: "course",
                column: "TopicID",
                principalTable: "topic",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
