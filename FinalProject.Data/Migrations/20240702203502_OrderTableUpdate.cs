using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9484),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8774),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6586));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(9262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 3, 0, 35, 1, 579, DateTimeKind.Utc).AddTicks(8604));
        }
    }
}
