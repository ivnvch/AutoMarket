using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMarket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modek",
                table: "Cars",
                newName: "Model");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "DateCreate", "Description", "Mark", "Model", "Price", "Speed", "TypeCar" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Разгон с 0 до 100 менеее чем за 3,5 секунды/)", "Audi", "R8", 150000m, 310.0, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "Modek");
        }
    }
}
