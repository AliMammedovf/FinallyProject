using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(1026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.AddColumn<bool>(
                name: "IsPoster",
                table: "ProductImages",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 346, DateTimeKind.Utc).AddTicks(9998));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPoster",
                table: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 347, DateTimeKind.Utc).AddTicks(184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 5, 18, 25, 346, DateTimeKind.Utc).AddTicks(9998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 3, 29, 55, 807, DateTimeKind.Utc).AddTicks(420));
        }
    }
}
