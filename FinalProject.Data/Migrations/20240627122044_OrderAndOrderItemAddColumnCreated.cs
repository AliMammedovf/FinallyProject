using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderItemAddColumnCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(319));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 27, 16, 10, 47, 635, DateTimeKind.Utc).AddTicks(319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 27, 16, 20, 43, 323, DateTimeKind.Utc).AddTicks(5303));
        }
    }
}
