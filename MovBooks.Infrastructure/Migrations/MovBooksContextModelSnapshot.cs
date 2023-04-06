﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovBooks.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovBooks.Infrastructure.Migrations
{
    [DbContext(typeof(MovBooksContext))]
    partial class MovBooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MovBooks.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("books", "books");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("IdApi")
                        .HasColumnType("integer")
                        .HasColumnName("id_api");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("gender", "config");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.GenderBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("IdBook")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int>("IdGender")
                        .HasColumnType("integer")
                        .HasColumnName("gender_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdGender");

                    b.ToTable("gender_books", "books");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.GenderMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("IdGender")
                        .HasColumnType("integer")
                        .HasColumnName("gender_id");

                    b.Property<int>("IdMovie")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdMovie");

                    b.ToTable("gender_movies", "movies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Aggregated")
                        .HasColumnType("boolean")
                        .HasColumnName("aggregated");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("movies", "movies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("key");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("parameters", "config");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.PasswordRecovery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("token");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("password_recoveries", "users");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Pqr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Answer")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("answer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("pqrs", "users");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.RatingBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<DateTime>("RatingDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("rating_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("ratings", "books");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.RatingMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<DateTime>("RatingDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("rating_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_ratings_user_id1");

                    b.ToTable("ratings", "movies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("roles", "users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 850, DateTimeKind.Local).AddTicks(4565),
                            Name = "Admin",
                            UpdatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 850, DateTimeKind.Local).AddTicks(4838)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 850, DateTimeKind.Local).AddTicks(9617),
                            Name = "User",
                            UpdatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 850, DateTimeKind.Local).AddTicks(9620)
                        });
                });

            modelBuilder.Entity("MovBooks.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean")
                        .HasColumnName("enabled");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nickname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_date");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Nickname");

                    b.HasIndex("RoleId");

                    b.ToTable("users", "users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 851, DateTimeKind.Local).AddTicks(3325),
                            Email = "admin@movbooks.com",
                            Enabled = true,
                            Nickname = "AdminMovbooks",
                            Password = "12345678",
                            RegistrationDate = new DateTime(2023, 4, 5, 23, 39, 31, 851, DateTimeKind.Local).AddTicks(1613),
                            RoleId = 1,
                            UpdatedAt = new DateTime(2023, 4, 5, 23, 39, 31, 851, DateTimeKind.Local).AddTicks(3327)
                        });
                });

            modelBuilder.Entity("MovBooks.Core.Entities.ViewsBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<long>("Views")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity_views");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("views", "books");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.ViewsMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<long>("Views")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity_views");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_views_user_id1");

                    b.ToTable("views", "movies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.GenderBooks", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Book", "Book")
                        .WithMany("GenderBooks")
                        .HasForeignKey("IdBook")
                        .HasConstraintName("fk_gender_books_book_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.Gender", "Gender")
                        .WithMany("GenderBooks")
                        .HasForeignKey("IdGender")
                        .HasConstraintName("fk_gender_books_gender_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.GenderMovies", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Gender", "Gender")
                        .WithMany("GenderMovies")
                        .HasForeignKey("IdGender")
                        .HasConstraintName("fk_gender_movies_gender_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.Movie", "Movie")
                        .WithMany("GenderMovies")
                        .HasForeignKey("IdMovie")
                        .HasConstraintName("fk_gender_movies_movie_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Pqr", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.User", "User")
                        .WithMany("Pqrs")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_pqrs_users")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.RatingBook", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Book", "Book")
                        .WithMany("RatingsBooks")
                        .HasForeignKey("BookId")
                        .HasConstraintName("fk_rating_book_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.User", "User")
                        .WithMany("RatingsBooks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_rating_user_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.RatingMovie", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Movie", "Movie")
                        .WithMany("RatingsMovies")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("fk_movies")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.User", "User")
                        .WithMany("RatingsMovies")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_users")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.User", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_users_roles")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.ViewsBooks", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Book", "Book")
                        .WithMany("ViewsBooks")
                        .HasForeignKey("BookId")
                        .HasConstraintName("fk_book_view_books")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.User", "User")
                        .WithMany("ViewsBooks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_users_view_books")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.ViewsMovies", b =>
                {
                    b.HasOne("MovBooks.Core.Entities.Movie", "Movie")
                        .WithMany("ViewMovies")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("fk_movie_view_movies")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MovBooks.Core.Entities.User", "User")
                        .WithMany("ViewsMovies")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_users_view_movies")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Book", b =>
                {
                    b.Navigation("GenderBooks");

                    b.Navigation("RatingsBooks");

                    b.Navigation("ViewsBooks");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Gender", b =>
                {
                    b.Navigation("GenderBooks");

                    b.Navigation("GenderMovies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Movie", b =>
                {
                    b.Navigation("GenderMovies");

                    b.Navigation("RatingsMovies");

                    b.Navigation("ViewMovies");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MovBooks.Core.Entities.User", b =>
                {
                    b.Navigation("Pqrs");

                    b.Navigation("RatingsBooks");

                    b.Navigation("RatingsMovies");

                    b.Navigation("ViewsBooks");

                    b.Navigation("ViewsMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
