using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(3265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(2383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(2383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(1113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 11, 13, 0, 463, DateTimeKind.Utc).AddTicks(28),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1701));
        }
    }
}
