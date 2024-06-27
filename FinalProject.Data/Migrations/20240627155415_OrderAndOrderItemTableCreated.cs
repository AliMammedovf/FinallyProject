using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderItemTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(7764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5303));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 19, 54, 14, 721, DateTimeKind.Utc).AddTicks(7764));
        }
    }
}
