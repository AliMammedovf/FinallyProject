using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReservationTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(1414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(7149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(1086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6878));

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(7149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 29, 17, 58, 33, 165, DateTimeKind.Utc).AddTicks(6105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 29, 21, 41, 45, 783, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                table: "Reservations",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
