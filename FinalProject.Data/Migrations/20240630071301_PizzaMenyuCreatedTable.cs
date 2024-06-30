using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class PizzaMenyuCreatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(2383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(28),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(5242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(2383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(4144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 9, 53, 45, 376, DateTimeKind.Utc).AddTicks(3348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(28));
        }
    }
}
