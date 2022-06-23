﻿// <auto-generated />
using System;
using AccessPointMap.Infrastructure.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccessPointMap.Infrastructure.MySql.Migrations
{
    [DbContext(typeof(AccessPointMapDbContext))]
    [Migration("20220623185228_PcapSystemImplementation")]
    partial class PcapSystemImplementation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("apm")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AccessPointMap.Domain.AccessPoints.AccessPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("AccessPoints", "apm");
                });

            modelBuilder.Entity("AccessPointMap.Domain.Identities.Identity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Identities", "apm");
                });

            modelBuilder.Entity("AccessPointMap.Domain.AccessPoints.AccessPoint", b =>
                {
                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointContributorId", "ContributorId", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointCreationTimestamp", "CreationTimestamp", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointDeviceType", "DeviceType", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointFrequency", "Frequency", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasColumnType("double");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointPositioning", "Positioning", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("HighSignalLatitude")
                                .HasColumnType("double");

                            b1.Property<int>("HighSignalLevel")
                                .HasColumnType("int");

                            b1.Property<double>("HighSignalLongitude")
                                .HasColumnType("double");

                            b1.Property<double>("LowSignalLatitude")
                                .HasColumnType("double");

                            b1.Property<int>("LowSignalLevel")
                                .HasColumnType("int");

                            b1.Property<double>("LowSignalLongitude")
                                .HasColumnType("double");

                            b1.Property<double>("SignalArea")
                                .HasColumnType("double");

                            b1.Property<double>("SignalRadius")
                                .HasColumnType("double");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointSecurity", "Security", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("IsSecure")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("RawSecurityPayload")
                                .HasColumnType("longtext");

                            b1.Property<string>("SerializedSecurityPayload")
                                .HasColumnType("longtext");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointSsid", "Ssid", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointBssid", "Bssid", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("varchar(255)");

                            b1.HasKey("AccessPointId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointDisplayStatus", "DisplayStatus", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("Value")
                                .HasColumnType("tinyint(1)");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointManufacturer", "Manufacturer", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointNote", "Note", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointVersionTimestamp", "VersionTimestamp", b1 =>
                        {
                            b1.Property<Guid>("AccessPointId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("AccessPointId");

                            b1.ToTable("AccessPoints", "apm");

                            b1.WithOwner()
                                .HasForeignKey("AccessPointId");
                        });

                    b.OwnsMany("AccessPointMap.Domain.AccessPoints.AccessPointAdnnotations.AccessPointAdnnotation", "Adnnotations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("accesspointId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("accesspointId");

                            b1.ToTable("AccessPointAdnnotation", "apm");

                            b1.WithOwner()
                                .HasForeignKey("accesspointId");

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointAdnnotations.AccessPointAdnnotationContent", "Content", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointAdnnotationId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointAdnnotationId");

                                    b2.ToTable("AccessPointAdnnotation", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointAdnnotationId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointAdnnotations.AccessPointAdnnotationTimestamp", "Timestamp", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointAdnnotationId")
                                        .HasColumnType("char(36)");

                                    b2.Property<DateTime>("Value")
                                        .HasColumnType("datetime(6)");

                                    b2.HasKey("AccessPointAdnnotationId");

                                    b2.ToTable("AccessPointAdnnotation", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointAdnnotationId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointAdnnotations.AccessPointAdnnotationTitle", "Title", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointAdnnotationId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointAdnnotationId");

                                    b2.ToTable("AccessPointAdnnotation", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointAdnnotationId");
                                });

                            b1.Navigation("Content")
                                .IsRequired();

                            b1.Navigation("Timestamp");

                            b1.Navigation("Title")
                                .IsRequired();
                        });

                    b.OwnsMany("AccessPointMap.Domain.AccessPoints.AccessPointPackets.AccessPointPacket", "Packets", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("accesspointId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("accesspointId");

                            b1.ToTable("AccessPointPacket", "apm");

                            b1.WithOwner()
                                .HasForeignKey("accesspointId");

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointPackets.AccessPointPacketData", "Data", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointPacketId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointPacketId");

                                    b2.ToTable("AccessPointPacket", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointPacketId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointPackets.AccessPointPacketDestinationAddress", "DestinationAddress", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointPacketId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointPacketId");

                                    b2.ToTable("AccessPointPacket", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointPacketId");
                                });

                            b1.Navigation("Data")
                                .IsRequired();

                            b1.Navigation("DestinationAddress")
                                .IsRequired();
                        });

                    b.OwnsMany("AccessPointMap.Domain.AccessPoints.AccessPointStamps.AccessPointStamp", "Stamps", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("accesspointId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("accesspointId");

                            b1.ToTable("AccessPointStamp", "apm");

                            b1.WithOwner()
                                .HasForeignKey("accesspointId");

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointContributorId", "ContributorId", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("Value")
                                        .HasColumnType("char(36)");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointCreationTimestamp", "CreationTimestamp", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<DateTime>("Value")
                                        .HasColumnType("datetime(6)");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointDeviceType", "DeviceType", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointFrequency", "Frequency", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<double>("Value")
                                        .HasColumnType("double");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointPositioning", "Positioning", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<double>("HighSignalLatitude")
                                        .HasColumnType("double");

                                    b2.Property<int>("HighSignalLevel")
                                        .HasColumnType("int");

                                    b2.Property<double>("HighSignalLongitude")
                                        .HasColumnType("double");

                                    b2.Property<double>("LowSignalLatitude")
                                        .HasColumnType("double");

                                    b2.Property<int>("LowSignalLevel")
                                        .HasColumnType("int");

                                    b2.Property<double>("LowSignalLongitude")
                                        .HasColumnType("double");

                                    b2.Property<double>("SignalArea")
                                        .HasColumnType("double");

                                    b2.Property<double>("SignalRadius")
                                        .HasColumnType("double");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointSecurity", "Security", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<bool>("IsSecure")
                                        .HasColumnType("tinyint(1)");

                                    b2.Property<string>("RawSecurityPayload")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("SerializedSecurityPayload")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointSsid", "Ssid", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .HasColumnType("longtext");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.OwnsOne("AccessPointMap.Domain.AccessPoints.AccessPointStamps.AccessPointStampStatus", "Status", b2 =>
                                {
                                    b2.Property<Guid>("AccessPointStampId")
                                        .HasColumnType("char(36)");

                                    b2.Property<bool>("Value")
                                        .HasColumnType("tinyint(1)");

                                    b2.HasKey("AccessPointStampId");

                                    b2.ToTable("AccessPointStamp", "apm");

                                    b2.WithOwner()
                                        .HasForeignKey("AccessPointStampId");
                                });

                            b1.Navigation("ContributorId");

                            b1.Navigation("CreationTimestamp");

                            b1.Navigation("DeviceType")
                                .IsRequired();

                            b1.Navigation("Frequency");

                            b1.Navigation("Positioning");

                            b1.Navigation("Security");

                            b1.Navigation("Ssid")
                                .IsRequired();

                            b1.Navigation("Status");
                        });

                    b.Navigation("Adnnotations");

                    b.Navigation("Bssid")
                        .IsRequired();

                    b.Navigation("ContributorId");

                    b.Navigation("CreationTimestamp");

                    b.Navigation("DeviceType")
                        .IsRequired();

                    b.Navigation("DisplayStatus");

                    b.Navigation("Frequency");

                    b.Navigation("Manufacturer")
                        .IsRequired();

                    b.Navigation("Note")
                        .IsRequired();

                    b.Navigation("Packets");

                    b.Navigation("Positioning");

                    b.Navigation("Security");

                    b.Navigation("Ssid")
                        .IsRequired();

                    b.Navigation("Stamps");

                    b.Navigation("VersionTimestamp");
                });

            modelBuilder.Entity("AccessPointMap.Domain.Identities.Identity", b =>
                {
                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityActivation", "Activation", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("Value")
                                .HasColumnType("tinyint(1)");

                            b1.HasKey("IdentityId");

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityEmail", "Email", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("varchar(255)");

                            b1.HasKey("IdentityId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityLastLogin", "LastLogin", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("IpAddress")
                                .HasColumnType("longtext");

                            b1.HasKey("IdentityId");

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityName", "Name", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)");

                            b1.HasKey("IdentityId");

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityPasswordHash", "PasswordHash", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext");

                            b1.HasKey("IdentityId");

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsOne("AccessPointMap.Domain.Identities.IdentityRole", "Role", b1 =>
                        {
                            b1.Property<Guid>("IdentityId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("IdentityId");

                            b1.ToTable("Identities", "apm");

                            b1.WithOwner()
                                .HasForeignKey("IdentityId");
                        });

                    b.OwnsMany("AccessPointMap.Domain.Identities.Tokens.Token", "Tokens", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("CreatedByIpAddress")
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("DeletedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime(6)");

                            b1.Property<bool>("IsRevoked")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("ReplacedByTokenHash")
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("RevokedByIpAddress")
                                .HasColumnType("longtext");

                            b1.Property<string>("TokenHash")
                                .HasColumnType("varchar(255)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("identityId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("TokenHash")
                                .IsUnique();

                            b1.HasIndex("identityId");

                            b1.ToTable("Token", "apm");

                            b1.WithOwner()
                                .HasForeignKey("identityId");
                        });

                    b.Navigation("Activation");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("LastLogin");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("PasswordHash")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
