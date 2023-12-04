﻿// <auto-generated />
using System;
using GameClub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameClub.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231204105005_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameClub.Domain.Entities.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Computer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("HistoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PriceOfHour")
                        .HasColumnType("double precision");

                    b.Property<long>("ScheduleOfChangesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.HasIndex("ScheduleOfChangesId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.History", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AdminId")
                        .HasColumnType("bigint");

                    b.Property<long>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("HoursCount")
                        .HasColumnType("bigint");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ScheduleOfChangesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("ScheduleOfChangesId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.ScheduleOfChanges", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AdminId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("HistoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("HistoryId");

                    b.ToTable("ScheduleOfChanges");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Computer", b =>
                {
                    b.HasOne("GameClub.Domain.Entities.History", "History")
                        .WithMany("Computers")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameClub.Domain.Entities.ScheduleOfChanges", "ScheduleOfChanges")
                        .WithMany("Computers")
                        .HasForeignKey("ScheduleOfChangesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("History");

                    b.Navigation("ScheduleOfChanges");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.History", b =>
                {
                    b.HasOne("GameClub.Domain.Entities.Admin", null)
                        .WithMany("Histories")
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Player", b =>
                {
                    b.HasOne("GameClub.Domain.Entities.Computer", "Computer")
                        .WithMany("Players")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameClub.Domain.Entities.ScheduleOfChanges", "ScheduleOfChanges")
                        .WithMany("Players")
                        .HasForeignKey("ScheduleOfChangesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");

                    b.Navigation("ScheduleOfChanges");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.ScheduleOfChanges", b =>
                {
                    b.HasOne("GameClub.Domain.Entities.Admin", null)
                        .WithMany("ScheduleOfChanges")
                        .HasForeignKey("AdminId");

                    b.HasOne("GameClub.Domain.Entities.History", "History")
                        .WithMany("ScheduleOfChanges")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("History");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Admin", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("ScheduleOfChanges");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.Computer", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.History", b =>
                {
                    b.Navigation("Computers");

                    b.Navigation("ScheduleOfChanges");
                });

            modelBuilder.Entity("GameClub.Domain.Entities.ScheduleOfChanges", b =>
                {
                    b.Navigation("Computers");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
