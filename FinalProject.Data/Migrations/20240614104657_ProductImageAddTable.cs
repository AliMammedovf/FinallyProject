using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageAddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(9133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8866),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Flavours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 14, 17, 18, 32, DateTimeKind.Utc).AddTicks(8365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 14, 46, 56, 992, DateTimeKind.Utc).AddTicks(319));
        }
    }
}
