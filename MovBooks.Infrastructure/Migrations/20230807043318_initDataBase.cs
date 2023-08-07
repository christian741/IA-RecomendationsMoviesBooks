using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovBooks.Infrastructure.Migrations
{
    public partial class initDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "books");

            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.EnsureSchema(
                name: "movies");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "books",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                schema: "config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    id_api = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                schema: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    aggregated = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                schema: "config",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "password_recoveries",
                schema: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    token = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_recoveries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genre_books",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_genre_books_book_id",
                        column: x => x.book_id,
                        principalSchema: "books",
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_genre_books_Genre_id",
                        column: x => x.genre_id,
                        principalSchema: "config",
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "genre_movies",
                schema: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_movies", x => x.id);
                    table.ForeignKey(
                        name: "fk_genre_movies_Genre_id",
                        column: x => x.genre_id,
                        principalSchema: "config",
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_genre_movies_movie_id",
                        column: x => x.movie_id,
                        principalSchema: "movies",
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nickname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_roles",
                        column: x => x.role_id,
                        principalSchema: "users",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pqrs",
                schema: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    answer = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pqrs", x => x.id);
                    table.ForeignKey(
                        name: "fk_pqrs_users",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    rating_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                    table.ForeignKey(
                        name: "fk_rating_book_id",
                        column: x => x.book_id,
                        principalSchema: "books",
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_rating_user_id",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                schema: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: false),
                    rating_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                    table.ForeignKey(
                        name: "fk_movies",
                        column: x => x.movie_id,
                        principalSchema: "movies",
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "views",
                schema: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    quantity_views = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_views", x => x.id);
                    table.ForeignKey(
                        name: "fk_book_view_books",
                        column: x => x.book_id,
                        principalSchema: "books",
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_view_books",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "views",
                schema: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    quantity_views = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_views", x => x.id);
                    table.ForeignKey(
                        name: "fk_movie_view_movies",
                        column: x => x.movie_id,
                        principalSchema: "movies",
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_view_movies",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "roles",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 6, 23, 33, 18, 160, DateTimeKind.Local).AddTicks(3895), "Admin", new DateTime(2023, 8, 6, 23, 33, 18, 160, DateTimeKind.Local).AddTicks(4092) },
                    { 2, new DateTime(2023, 8, 6, 23, 33, 18, 160, DateTimeKind.Local).AddTicks(8654), "User", new DateTime(2023, 8, 6, 23, 33, 18, 160, DateTimeKind.Local).AddTicks(8657) }
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "users",
                columns: new[] { "id", "avatar", "created_at", "email", "enabled", "image", "nickname", "password", "registration_date", "role_id", "updated_at" },
                values: new object[] { 1, null, new DateTime(2023, 8, 6, 23, 33, 18, 161, DateTimeKind.Local).AddTicks(1815), "admin@movbooks.com", true, null, "AdminMovbooks", "12345678", new DateTime(2023, 8, 6, 23, 33, 18, 161, DateTimeKind.Local).AddTicks(282), 1, new DateTime(2023, 8, 6, 23, 33, 18, 161, DateTimeKind.Local).AddTicks(1817) });

            migrationBuilder.CreateIndex(
                name: "IX_books_title",
                schema: "books",
                table: "books",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_gender_name",
                schema: "config",
                table: "gender",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_genre_books_book_id",
                schema: "books",
                table: "genre_books",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_genre_books_genre_id",
                schema: "books",
                table: "genre_books",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_genre_movies_genre_id",
                schema: "movies",
                table: "genre_movies",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_genre_movies_movie_id",
                schema: "movies",
                table: "genre_movies",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movies_title",
                schema: "movies",
                table: "movies",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_pqrs_user_id",
                schema: "users",
                table: "pqrs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_book_id",
                schema: "books",
                table: "ratings",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_user_id",
                schema: "books",
                table: "ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_movie_id",
                schema: "movies",
                table: "ratings",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_user_id1",
                schema: "movies",
                table: "ratings",
                column: "user_id");

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
                name: "IX_users_role_id",
                schema: "users",
                table: "users",
                column: "role_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "genre_books",
                schema: "books");

            migrationBuilder.DropTable(
                name: "genre_movies",
                schema: "movies");

            migrationBuilder.DropTable(
                name: "parameters",
                schema: "config");

            migrationBuilder.DropTable(
                name: "password_recoveries",
                schema: "users");

            migrationBuilder.DropTable(
                name: "pqrs",
                schema: "users");

            migrationBuilder.DropTable(
                name: "ratings",
                schema: "books");

            migrationBuilder.DropTable(
                name: "ratings",
                schema: "movies");

            migrationBuilder.DropTable(
                name: "views",
                schema: "books");

            migrationBuilder.DropTable(
                name: "views",
                schema: "movies");

            migrationBuilder.DropTable(
                name: "gender",
                schema: "config");

            migrationBuilder.DropTable(
                name: "books",
                schema: "books");

            migrationBuilder.DropTable(
                name: "movies",
                schema: "movies");

            migrationBuilder.DropTable(
                name: "users",
                schema: "users");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "users");
        }
    }
}
