﻿// <auto-generated />
using System;
using GQLDEMOTUT.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220715161919_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("GQLDEMOTUT.Entities.CommentToPostOrComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CommentBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CommentOnCommentID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CommentOnPostID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CommentedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommentBy");

                    b.HasIndex("CommentOnPostID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"),
                            CommentBy = new Guid("01b55555-955b-45a8-b6fe-efce8162a755"),
                            CommentContent = "Hi , Welcome ",
                            CommentOnPostID = new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"),
                            CommentedOn = new DateTime(11, 11, 11, 12, 30, 30, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.GQLUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"),
                            UserName = "First User Of APP"
                        },
                        new
                        {
                            Id = new Guid("01b55555-955b-45a8-b6fe-efce8162a755"),
                            UserName = "Sec User "
                        });
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PostedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostedBy");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"),
                            PostContent = "Hi , This Is My First Post Here ",
                            PostedBy = new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"),
                            PostedOn = new DateTime(11, 11, 11, 12, 30, 30, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.ReactToPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReactToPostOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReactedTOPost")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReactionBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReactionTaken")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReactedTOPost");

                    b.HasIndex("ReactionBy");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.CommentToPostOrComment", b =>
                {
                    b.HasOne("GQLDEMOTUT.Entities.GQLUser", "Commentor")
                        .WithMany("UserComments")
                        .HasForeignKey("CommentBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GQLDEMOTUT.Entities.CommentToPostOrComment", "CommentParent")
                        .WithMany("CommentComments")
                        .HasForeignKey("CommentOnPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GQLDEMOTUT.Entities.Post", "MainPost")
                        .WithMany("PostComments")
                        .HasForeignKey("CommentOnPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentParent");

                    b.Navigation("Commentor");

                    b.Navigation("MainPost");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.Post", b =>
                {
                    b.HasOne("GQLDEMOTUT.Entities.GQLUser", "PostOwner")
                        .WithMany("UserPosts")
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostOwner");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.ReactToPost", b =>
                {
                    b.HasOne("GQLDEMOTUT.Entities.Post", "ReactedPost")
                        .WithMany("PostReactions")
                        .HasForeignKey("ReactedTOPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GQLDEMOTUT.Entities.GQLUser", "Reactor")
                        .WithMany("UserReactions")
                        .HasForeignKey("ReactionBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReactedPost");

                    b.Navigation("Reactor");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.CommentToPostOrComment", b =>
                {
                    b.Navigation("CommentComments");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.GQLUser", b =>
                {
                    b.Navigation("UserComments");

                    b.Navigation("UserPosts");

                    b.Navigation("UserReactions");
                });

            modelBuilder.Entity("GQLDEMOTUT.Entities.Post", b =>
                {
                    b.Navigation("PostComments");

                    b.Navigation("PostReactions");
                });
#pragma warning restore 612, 618
        }
    }
}
