using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Dal.Migrations
{
    /// <inheritdoc />
    public partial class djkdj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 11, 12, 38, 59, 108, DateTimeKind.Local).AddTicks(1202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 11, 12, 21, 21, 701, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 11, 8, 38, 59, 107, DateTimeKind.Utc).AddTicks(2705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 11, 8, 21, 21, 700, DateTimeKind.Utc).AddTicks(7477));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 11, 12, 21, 21, 701, DateTimeKind.Local).AddTicks(6654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 11, 12, 38, 59, 108, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 11, 8, 21, 21, 700, DateTimeKind.Utc).AddTicks(7477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 11, 8, 38, 59, 107, DateTimeKind.Utc).AddTicks(2705));
        }
    }
}
