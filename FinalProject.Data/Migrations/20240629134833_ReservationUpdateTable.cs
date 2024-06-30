using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCount",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(4481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(4216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3994),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7398));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(8193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.AddColumn<DateTime>(
                name: "DayCount",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 13, 14, 56, 736, DateTimeKind.Utc).AddTicks(7398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 48, 32, 505, DateTimeKind.Utc).AddTicks(3516));
        }
    }
}
