using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlColumnDropped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9669),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(1583));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(2229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(2015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9669));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(1782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 26, 22, 23, 17, 218, DateTimeKind.Utc).AddTicks(1583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9350));
        }
    }
}
