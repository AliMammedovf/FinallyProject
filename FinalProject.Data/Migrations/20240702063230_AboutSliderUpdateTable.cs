using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AboutSliderUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AboutSliders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "AboutSliders",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AboutSliders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2121));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(4311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(3333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(7130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AboutSliders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "AboutSliders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AboutSliders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 23, 7, 25, 671, DateTimeKind.Utc).AddTicks(2121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 2, 10, 32, 30, 196, DateTimeKind.Utc).AddTicks(6586));
        }
    }
}
