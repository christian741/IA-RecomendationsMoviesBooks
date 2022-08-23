using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovBooks.Infrastructure.Migrations
{
    public partial class AddGenderBooksMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gender_books",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_gender_books_book_id",
                        column: x => x.book_id,
                        principalSchema: "books",
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_gender_books_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "config",
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gender_movies",
                schema: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender_movies", x => x.id);
                    table.ForeignKey(
                        name: "fk_gender_movies_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "config",
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_gender_movies_movie_id",
                        column: x => x.movie_id,
                        principalSchema: "movies",
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_gender_books_book_id",
                schema: "books",
                table: "gender_books",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_gender_books_gender_id",
                schema: "books",
                table: "gender_books",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_gender_movies_gender_id",
                schema: "movies",
                table: "gender_movies",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_gender_movies_movie_id",
                schema: "movies",
                table: "gender_movies",
                column: "movie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gender_books",
                schema: "books");

            migrationBuilder.DropTable(
                name: "gender_movies",
                schema: "movies");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 10, 22, 31, 30, 963, DateTimeKind.Local).AddTicks(5597), new DateTime(2022, 8, 10, 22, 31, 30, 963, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 10, 22, 31, 30, 964, DateTimeKind.Local).AddTicks(4584), new DateTime(2022, 8, 10, 22, 31, 30, 964, DateTimeKind.Local).AddTicks(4602) });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "registration_date", "updated_at" },
                values: new object[] { new DateTime(2022, 8, 10, 22, 31, 30, 964, DateTimeKind.Local).AddTicks(7802), new DateTime(2022, 8, 10, 22, 31, 30, 964, DateTimeKind.Local).AddTicks(6039), new DateTime(2022, 8, 10, 22, 31, 30, 964, DateTimeKind.Local).AddTicks(7806) });
        }
    }
}
