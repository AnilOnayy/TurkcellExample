using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellExample.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeColumnAddedForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Products");
        }
    }
}
