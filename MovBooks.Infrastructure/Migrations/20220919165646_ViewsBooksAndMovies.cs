using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovBooks.Infrastructure.Migrations
{
    public partial class ViewsBooksAndMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "movie_id",
                schema: "movies",
                table: "views",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "quantity_views",
                schema: "movies",
                table: "views",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                schema: "movies",
                table: "views",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "book_id",
                schema: "books",
                table: "views",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "quantity_views",
                schema: "books",
                table: "views",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                schema: "books",
                table: "views",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 9, 19, 11, 56, 45, 928, DateTimeKind.Local).AddTicks(6955), new DateTime(2022, 9, 19, 11, 56, 45, 928, DateTimeKind.Local).AddTicks(8307) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 9, 19, 11, 56, 45, 929, DateTimeKind.Local).AddTicks(5979), new DateTime(2022, 9, 19, 11, 56, 45, 929, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "registration_date", "updated_at" },
                values: new object[] { new DateTime(2022, 9, 19, 11, 56, 45, 929, DateTimeKind.Local).AddTicks(9917), new DateTime(2022, 9, 19, 11, 56, 45, 929, DateTimeKind.Local).AddTicks(7915), new DateTime(2022, 9, 19, 11, 56, 45, 929, DateTimeKind.Local).AddTicks(9920) });

            migrationBuilder.CreateIndex(
                name: "IX_views_movie_id",
                schema: "movies",
                table: "views",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_views_user_id1",
                schema: "movies",
                table: "views",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_views_book_id",
                schema: "books",
                table: "views",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_views_user_id",
                schema: "books",
                table: "views",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_view_books",
                schema: "books",
                table: "views",
                column: "book_id",
                principalSchema: "books",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_view_books",
                schema: "books",
                table: "views",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_movie_view_movies",
                schema: "movies",
                table: "views",
                column: "movie_id",
                principalSchema: "movies",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_view_movies",
                schema: "movies",
                table: "views",
                column: "user_id",
                principalSchema: "users",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_view_books",
                schema: "books",
                table: "views");

            migrationBuilder.DropForeignKey(
                name: "fk_users_view_books",
                schema: "books",
                table: "views");

            migrationBuilder.DropForeignKey(
                name: "fk_movie_view_movies",
                schema: "movies",
                table: "views");

            migrationBuilder.DropForeignKey(
                name: "fk_users_view_movies",
                schema: "movies",
                table: "views");

            migrationBuilder.DropIndex(
                name: "IX_views_movie_id",
                schema: "movies",
                table: "views");

            migrationBuilder.DropIndex(
                name: "IX_views_user_id1",
                schema: "movies",
                table: "views");

            migrationBuilder.DropIndex(
                name: "IX_views_book_id",
                schema: "books",
                table: "views");

            migrationBuilder.DropIndex(
                name: "IX_views_user_id",
                schema: "books",
                table: "views");

            migrationBuilder.DropColumn(
                name: "movie_id",
                schema: "movies",
                table: "views");

            migrationBuilder.DropColumn(
                name: "quantity_views",
                schema: "movies",
                table: "views");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "movies",
                table: "views");

            migrationBuilder.DropColumn(
                name: "book_id",
                schema: "books",
                table: "views");

            migrationBuilder.DropColumn(
                name: "quantity_views",
                schema: "books",
                table: "views");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "books",
                table: "views");

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
    }
}
