using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovBooks.Infrastructure.Migrations
{
    public partial class AddApiIdGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_api",
                schema: "config",
                table: "gender",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 22, 22, 8, 25, 87, DateTimeKind.Local).AddTicks(5908), new DateTime(2022, 8, 22, 22, 8, 25, 87, DateTimeKind.Local).AddTicks(8446) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 22, 22, 8, 25, 90, DateTimeKind.Local).AddTicks(6324), new DateTime(2022, 8, 22, 22, 8, 25, 90, DateTimeKind.Local).AddTicks(6381) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "registration_date", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 22, 22, 8, 25, 91, DateTimeKind.Local).AddTicks(6316), new DateTime(2022, 8, 22, 22, 8, 25, 91, DateTimeKind.Local).AddTicks(1260), new DateTime(2022, 8, 22, 22, 8, 25, 91, DateTimeKind.Local).AddTicks(6328) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_api",
                schema: "config",
                table: "gender");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 22, 34, 56, 466, DateTimeKind.Local).AddTicks(247), new DateTime(2022, 8, 14, 22, 34, 56, 466, DateTimeKind.Local).AddTicks(1521) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 22, 34, 56, 467, DateTimeKind.Local).AddTicks(1349), new DateTime(2022, 8, 14, 22, 34, 56, 467, DateTimeKind.Local).AddTicks(1369) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "registration_date", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 22, 34, 56, 467, DateTimeKind.Local).AddTicks(5300), new DateTime(2022, 8, 14, 22, 34, 56, 467, DateTimeKind.Local).AddTicks(3194), new DateTime(2022, 8, 14, 22, 34, 56, 467, DateTimeKind.Local).AddTicks(5305) });
        }
    }
}
