﻿// <auto-generated />
using System;
using AccessPointMap.Repository.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccessPointMap.Repository.Migrations
{
    [DbContext(typeof(AccessPointMapDbContext))]
    partial class AccessPointMapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccessPointMap.Domain.AccessPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bssid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Display")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fingerprint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Frequency")
                        .HasColumnType("float");

                    b.Property<string>("FullSecurityData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsSecure")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MasterGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<double>("MaxSignalLatitude")
                        .HasColumnType("float");

                    b.Property<int>("MaxSignalLevel")
                        .HasColumnType("int");

                    b.Property<double>("MaxSignalLongitude")
                        .HasColumnType("float");

                    b.Property<double>("MinSignalLatitude")
                        .HasColumnType("float");

                    b.Property<int>("MinSignalLevel")
                        .HasColumnType("int");

                    b.Property<double>("MinSignalLongitude")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("SerializedSecurityData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SignalArea")
                        .HasColumnType("float");

                    b.Property<double>("SignalRadius")
                        .HasColumnType("float");

                    b.Property<string>("Ssid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserAddedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserAddedId");

                    b.HasIndex("UserModifiedId");

                    b.ToTable("AccessPoints");
                });

            modelBuilder.Entity("AccessPointMap.Domain.RefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("AccessPointMap.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("AdminPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActivated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("LastLoginDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LastLoginIp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<bool>("ModPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AddDate = new DateTime(2021, 8, 24, 14, 49, 54, 382, DateTimeKind.Local).AddTicks(6978),
                            AdminPermission = true,
                            EditDate = new DateTime(2021, 8, 24, 14, 49, 54, 390, DateTimeKind.Local).AddTicks(6328),
                            Email = "admin@apm.com",
                            IsActivated = true,
                            LastLoginDate = new DateTime(2021, 8, 24, 14, 49, 54, 390, DateTimeKind.Local).AddTicks(9096),
                            LastLoginIp = "",
                            ModPermission = false,
                            Name = "Administrator",
                            Password = "$05$feN415S/rRMOaPcaiobkEeo5JTPoxY7PPMCwVGkbrbItw/mj19CBS"
                        });
                });

            modelBuilder.Entity("AccessPointMap.Domain.AccessPoint", b =>
                {
                    b.HasOne("AccessPointMap.Domain.User", "UserAdded")
                        .WithMany("AddedAccessPoints")
                        .HasForeignKey("UserAddedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("AccessPointMap.Domain.User", "UserModified")
                        .WithMany("ModifiedAccessPoints")
                        .HasForeignKey("UserModifiedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserAdded");

                    b.Navigation("UserModified");
                });

            modelBuilder.Entity("AccessPointMap.Domain.RefreshToken", b =>
                {
                    b.HasOne("AccessPointMap.Domain.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessPointMap.Domain.User", b =>
                {
                    b.Navigation("AddedAccessPoints");

                    b.Navigation("ModifiedAccessPoints");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
