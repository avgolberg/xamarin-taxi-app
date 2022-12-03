﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiWebApi.Context;

namespace TaxiWebApi.Migrations
{
    [DbContext(typeof(TaxiContext))]
    [Migration("20221203132837_UpdateDB")]
    partial class UpdateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DriverDriverOption", b =>
                {
                    b.Property<int>("DriverOptionsDriverOptionId")
                        .HasColumnType("int");

                    b.Property<int>("DriversId")
                        .HasColumnType("int");

                    b.HasKey("DriverOptionsDriverOptionId", "DriversId");

                    b.HasIndex("DriversId");

                    b.ToTable("DriverDriverOption");
                });

            modelBuilder.Entity("OrderParameter", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ParametersParameterId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "ParametersParameterId");

                    b.HasIndex("ParametersParameterId");

                    b.ToTable("OrderParameter");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarInsurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<bool>("HasAirConditioner")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSeatBeltsBehind")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUkrRegistration")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationCertificate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TaxiWebApi.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TaxiWebApi.Models.DriverOption", b =>
                {
                    b.Property<int>("DriverOptionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverOptionId");

                    b.ToTable("DriverOptions");

                    b.HasData(
                        new
                        {
                            DriverOptionId = 0,
                            Name = "OrderForTime"
                        },
                        new
                        {
                            DriverOptionId = 1,
                            Name = "DrivePassengerCar"
                        },
                        new
                        {
                            DriverOptionId = 2,
                            Name = "DeliverParcel"
                        },
                        new
                        {
                            DriverOptionId = 3,
                            Name = "TruckDriver"
                        },
                        new
                        {
                            DriverOptionId = 4,
                            Name = "EnglishSpeaking"
                        });
                });

            modelBuilder.Entity("TaxiWebApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("RiderId")
                        .HasColumnType("int");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("CityId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RiderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParameterId");

                    b.ToTable("Parameters");

                    b.HasData(
                        new
                        {
                            ParameterId = 0,
                            Name = "AirConditioner"
                        },
                        new
                        {
                            ParameterId = 1,
                            Name = "UseSeatBeltsBehind"
                        },
                        new
                        {
                            ParameterId = 2,
                            Name = "UkrainianRegistration"
                        },
                        new
                        {
                            ParameterId = 3,
                            Name = "EnglishSpeakingDriver"
                        },
                        new
                        {
                            ParameterId = 4,
                            Name = "WithChildren"
                        },
                        new
                        {
                            ParameterId = 5,
                            Name = "WithPets"
                        },
                        new
                        {
                            ParameterId = 6,
                            Name = "SilentDriver"
                        },
                        new
                        {
                            ParameterId = 7,
                            Name = "DoNotCall"
                        },
                        new
                        {
                            ParameterId = 8,
                            Name = "Deaf"
                        },
                        new
                        {
                            ParameterId = 9,
                            Name = "EmptyTrunk"
                        });
                });

            modelBuilder.Entity("TaxiWebApi.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("DriverDriverOption", b =>
                {
                    b.HasOne("TaxiWebApi.Models.DriverOption", null)
                        .WithMany()
                        .HasForeignKey("DriverOptionsDriverOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiWebApi.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderParameter", b =>
                {
                    b.HasOne("TaxiWebApi.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiWebApi.Models.Parameter", null)
                        .WithMany()
                        .HasForeignKey("ParametersParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiWebApi.Models.Car", b =>
                {
                    b.HasOne("TaxiWebApi.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Driver", b =>
                {
                    b.HasOne("TaxiWebApi.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxiWebApi.Models.Order", b =>
                {
                    b.HasOne("TaxiWebApi.Models.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId");

                    b.HasOne("TaxiWebApi.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("TaxiWebApi.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("TaxiWebApi.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId");

                    b.Navigation("Administrator");

                    b.Navigation("City");

                    b.Navigation("Driver");

                    b.Navigation("Rider");
                });
#pragma warning restore 612, 618
        }
    }
}
