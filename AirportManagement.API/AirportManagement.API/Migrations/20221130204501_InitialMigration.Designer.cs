﻿// <auto-generated />
using System;
using AirportManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportManagement.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221130204501_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("AirportManagement.API.Models.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AirlineCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirlineCountry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Baggage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("WeightInKG")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Baggages");
                });

            modelBuilder.Entity("AirportManagement.API.Models.BaggageCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckResult")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PassangerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("BaggageChecks");
                });

            modelBuilder.Entity("AirportManagement.API.Models.BoardingPass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("QRCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("BoardingPasses");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookingPlatform")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PassangerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PassangersId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PassangersId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("AirportManagement.API.Models.FlightManifest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("FlightId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlightsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("FlightsId");

                    b.ToTable("FlightManifests");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Flights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AirlineId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AirportId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AirportId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArrivingAirportId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrivingGate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartingAirportId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartingGate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.HasIndex("AirportId");

                    b.HasIndex("AirportId1");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirportManagement.API.Models.NoFlyList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("ActiveFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ActiveTo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("NoFlyReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PassangerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PassangersId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PassangersId");

                    b.ToTable("NoFlyLists");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Passangers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryOfCitizenship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryOfResidence")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Passangers");
                });

            modelBuilder.Entity("AirportManagement.API.Models.SecurityCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckResult")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PassangerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PassangersId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PassangersId");

                    b.ToTable("SecurityChecks");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Baggage", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Booking", null)
                        .WithMany("Baggages")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportManagement.API.Models.BaggageCheck", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Booking", null)
                        .WithMany("BaggageChecks")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportManagement.API.Models.BoardingPass", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Booking", null)
                        .WithMany("BoardingPasses")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportManagement.API.Models.Booking", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Passangers", null)
                        .WithMany("Bookings")
                        .HasForeignKey("PassangersId");
                });

            modelBuilder.Entity("AirportManagement.API.Models.FlightManifest", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Booking", null)
                        .WithMany("FlightManifests")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportManagement.API.Models.Flights", null)
                        .WithMany("FlightManifests")
                        .HasForeignKey("FlightsId");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Flights", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Airline", null)
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportManagement.API.Models.Airport", null)
                        .WithMany("ArrivingFlights")
                        .HasForeignKey("AirportId");

                    b.HasOne("AirportManagement.API.Models.Airport", null)
                        .WithMany("DepartureFlights")
                        .HasForeignKey("AirportId1");
                });

            modelBuilder.Entity("AirportManagement.API.Models.NoFlyList", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Passangers", null)
                        .WithMany("NoFlyLists")
                        .HasForeignKey("PassangersId");
                });

            modelBuilder.Entity("AirportManagement.API.Models.SecurityCheck", b =>
                {
                    b.HasOne("AirportManagement.API.Models.Passangers", null)
                        .WithMany("SecurityChecks")
                        .HasForeignKey("PassangersId");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Airline", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Airport", b =>
                {
                    b.Navigation("ArrivingFlights");

                    b.Navigation("DepartureFlights");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Booking", b =>
                {
                    b.Navigation("BaggageChecks");

                    b.Navigation("Baggages");

                    b.Navigation("BoardingPasses");

                    b.Navigation("FlightManifests");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Flights", b =>
                {
                    b.Navigation("FlightManifests");
                });

            modelBuilder.Entity("AirportManagement.API.Models.Passangers", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("NoFlyLists");

                    b.Navigation("SecurityChecks");
                });
#pragma warning restore 612, 618
        }
    }
}
