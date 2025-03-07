﻿// <auto-generated />
using System;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    [DbContext(typeof(FootballLeagueDbContext))]
    [Migration("20250307044338_Delete Scaffolded Context")]
    partial class DeleteScaffoldedContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("EntityFrameworkCore.Domain.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MK Sir"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCore.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            CreatedAt = new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CSK Team"
                        },
                        new
                        {
                            TeamId = 2,
                            CreatedAt = new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MI Team"
                        },
                        new
                        {
                            TeamId = 3,
                            CreatedAt = new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "KKR Team"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
