using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelFirst.Migrations
{
    /// <inheritdoc />
    public partial class NicknameAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "People",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "People");
        }
    }
}
