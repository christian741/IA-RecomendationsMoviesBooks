using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovBooks.Infrastructure.Migrations
{
    public partial class AddIndexToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                schema: "users",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_users_nickname",
                schema: "users",
                table: "users",
                column: "nickname");

            migrationBuilder.CreateIndex(
                name: "IX_movies_title",
                schema: "movies",
                table: "movies",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_gender_name",
                schema: "config",
                table: "gender",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_title",
                schema: "books",
                table: "books",
                column: "title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_email",
                schema: "users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_nickname",
                schema: "users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_movies_title",
                schema: "movies",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_gender_name",
                schema: "config",
                table: "gender");

            migrationBuilder.DropIndex(
                name: "IX_books_title",
                schema: "books",
                table: "books");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 21, 19, 18, 361, DateTimeKind.Local).AddTicks(7499), new DateTime(2022, 8, 14, 21, 19, 18, 361, DateTimeKind.Local).AddTicks(8782) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 21, 19, 18, 362, DateTimeKind.Local).AddTicks(8986), new DateTime(2022, 8, 14, 21, 19, 18, 362, DateTimeKind.Local).AddTicks(9008) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "registration_date", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 14, 21, 19, 18, 363, DateTimeKind.Local).AddTicks(3055), new DateTime(2022, 8, 14, 21, 19, 18, 363, DateTimeKind.Local).AddTicks(811), new DateTime(2022, 8, 14, 21, 19, 18, 363, DateTimeKind.Local).AddTicks(3060) });
        }
    }
}
