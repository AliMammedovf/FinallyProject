using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class BasketItemsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(2832),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.AddColumn<int>(
                name: "FlavourId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlavourId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "BasketItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9669),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 14, 19, 50, 114, DateTimeKind.Utc).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 15, 7, 45, 913, DateTimeKind.Utc).AddTicks(2832));
        }
    }
}
