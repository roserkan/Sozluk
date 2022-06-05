﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

#nullable disable

namespace Sozluk.Api.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SozlukContext))]
    [Migration("20220605195615_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EmailConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NewEmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("OldEmailAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmailConfirmations", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Entries", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryId");

                    b.ToTable("EntryComments", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("entrycommentfavorite", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoteType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("EntryCommentVotes", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryId");

                    b.ToTable("EntryFavorites", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoteType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("EntryVotes", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.Entry", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("Entries")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("EntryComments")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryComments")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.User", "CreatedUser")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sozluk.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentVotes")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.User", "CreatedUser")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryVote", b =>
                {
                    b.HasOne("Sozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryVotes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.Entry", b =>
                {
                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryCommentVotes");
                });

            modelBuilder.Entity("Sozluk.Api.Domain.Models.User", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
