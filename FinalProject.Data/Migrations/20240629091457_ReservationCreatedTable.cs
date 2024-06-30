using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReservationCreatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8462),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(3056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayCount",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2002));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DayCount",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(3056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 3, 58, 26, 465, DateTimeKind.Utc).AddTicks(2002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7398));
        }
    }
}
