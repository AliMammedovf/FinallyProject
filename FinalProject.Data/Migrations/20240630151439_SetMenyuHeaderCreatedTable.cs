using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetMenyuHeaderCreatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(6076),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(4605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.CreateTable(
                name: "SetMenyuHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetMenyuHeaders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetMenyuHeaders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(3265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(2215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(5028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AboutSliders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 30, 16, 12, 9, 676, DateTimeKind.Utc).AddTicks(1701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 30, 19, 14, 39, 1, DateTimeKind.Utc).AddTicks(4605));
        }
    }
}
