﻿// <auto-generated />
using System;
using Hittahem.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hittahem.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220405090428_Changed_Images_format")]
    partial class Changed_Images_format
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hittahem.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3c27a053-4447-4aef-8220-95ff805603b0",
                            Email = "test@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "TEST@EXAMPLE.COM",
                            NormalizedUserName = "TEST@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEP49exl7ynjFa5tsvI3t0wz+euWQTv/eYpnCmtMDS3hGw3LLkBSH+fWkAcenzVNsEA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2QIVNQYKHPKRPOXZPLLD24QJ242LMWLZ",
                            TwoFactorEnabled = false,
                            UserName = "test@example.com"
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BuildYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<decimal?>("GardenArea")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("HousingTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("LivingArea")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int>("OwnershipTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.Property<string>("StreetNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimePosted")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("UninhabitableArea")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HousingTypeId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("OwnershipTypeId");

                    b.HasIndex("StreetId");

                    b.HasIndex("UserId");

                    b.ToTable("Homes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fett trevligt jag svär",
                            HousingTypeId = 1,
                            LivingArea = 18.5m,
                            MunicipalityId = 1,
                            OwnershipTypeId = 1,
                            Price = 1000000,
                            Rooms = 1,
                            StreetId = 1,
                            StreetNr = "69",
                            TimePosted = new DateTime(2022, 4, 5, 9, 4, 27, 627, DateTimeKind.Utc).AddTicks(9285),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HomeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeImages");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HomeViewing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeViewings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 4, 5, 11, 4, 27, 627, DateTimeKind.Local).AddTicks(9317),
                            HomeId = 1
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HousingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HousingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lägenhet"
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.InterestedUser", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("InterestedUser");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Municipalities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Stockholm"
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.OwnershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OwnershipTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bostadsrätt"
                        });
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Stockholmsvägen"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Home", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.HousingType", "HousingType")
                        .WithMany("Homes")
                        .HasForeignKey("HousingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.Municipality", "Municipality")
                        .WithMany("Homes")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.OwnershipType", "OwnershipType")
                        .WithMany("Homes")
                        .HasForeignKey("OwnershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.Street", "Street")
                        .WithMany("Homes")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", "User")
                        .WithMany("Homes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HousingType");

                    b.Navigation("Municipality");

                    b.Navigation("OwnershipType");

                    b.Navigation("Street");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HomeImage", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.Home", "Home")
                        .WithMany("HomeImages")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HomeViewing", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.Home", "Home")
                        .WithMany("HomeViewings")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.InterestedUser", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.Home", "Home")
                        .WithMany("InterestedUsers")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", "User")
                        .WithMany("InterestedUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Home");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Hittahem.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("Homes");

                    b.Navigation("InterestedUsers");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Home", b =>
                {
                    b.Navigation("HomeImages");

                    b.Navigation("HomeViewings");

                    b.Navigation("InterestedUsers");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.HousingType", b =>
                {
                    b.Navigation("Homes");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Municipality", b =>
                {
                    b.Navigation("Homes");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.OwnershipType", b =>
                {
                    b.Navigation("Homes");
                });

            modelBuilder.Entity("Hittahem.Mvc.Models.Street", b =>
                {
                    b.Navigation("Homes");
                });
#pragma warning restore 612, 618
        }
    }
}
