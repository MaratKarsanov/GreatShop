using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreatShop.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 100.50m, "Описание товара 1", "Товар 1" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 200.75m, "Описание товара 2", "Товар 2" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 150.00m, "Описание товара 3", "Товар 3" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 300.99m, "Описание товара 4", "Товар 4" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 75.25m, "Описание товара 5", "Товар 5" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 120.00m, "Описание товара 6", "Товар 6" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 90.45m, "Описание товара 7", "Товар 7" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 500.00m, "Описание товара 8", "Товар 8" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 85.30m, "Описание товара 9", "Товар 9" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 250.60m, "Описание товара 10", "Товар 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
