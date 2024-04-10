﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RP1.DataAccess.DataAccess;

#nullable disable

namespace RP1.DataAccess.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240410125220_v4.2.2")]
    partial class v422
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RP1.Models.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("RP1.Models.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("FilmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ageRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("RP1.Models.Models.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("filmId")
                        .HasColumnType("int");

                    b.Property<int>("seatsRemaining")
                        .HasColumnType("int");

                    b.Property<int>("theatreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("filmId");

                    b.HasIndex("theatreId");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("RP1.Models.Models.Theatre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("TheatreNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Theatres");
                });

            modelBuilder.Entity("RP1.Models.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("bookingId")
                        .HasColumnType("int");

                    b.Property<int>("screeningId")
                        .HasColumnType("int");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookingId");

                    b.HasIndex("screeningId");

                    b.HasIndex("typeId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("RP1.Models.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("RP1.Models.Models.Screening", b =>
                {
                    b.HasOne("RP1.Models.Models.Film", "Film")
                        .WithMany("Screenings")
                        .HasForeignKey("filmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RP1.Models.Models.Theatre", "Theatre")
                        .WithMany("Screenings")
                        .HasForeignKey("theatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Theatre");
                });

            modelBuilder.Entity("RP1.Models.Models.Ticket", b =>
                {
                    b.HasOne("RP1.Models.Models.Booking", "Booking")
                        .WithMany("Tickets")
                        .HasForeignKey("bookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RP1.Models.Models.Screening", "Screening")
                        .WithMany()
                        .HasForeignKey("screeningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RP1.Models.Models.Type", "Type")
                        .WithMany("Tickets")
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Screening");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("RP1.Models.Models.Booking", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("RP1.Models.Models.Film", b =>
                {
                    b.Navigation("Screenings");
                });

            modelBuilder.Entity("RP1.Models.Models.Theatre", b =>
                {
                    b.Navigation("Screenings");
                });

            modelBuilder.Entity("RP1.Models.Models.Type", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
