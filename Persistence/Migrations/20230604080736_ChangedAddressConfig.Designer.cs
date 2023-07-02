﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230604080736_ChangedAddressConfig")]
    partial class ChangedAddressConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.CleaningEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Venue")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isCancelled")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CleaningEvents");
                });

            modelBuilder.Entity("Domain.CleaningEventAttendee", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CleaningEventId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsHost")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppUserId", "CleaningEventId");

                    b.HasIndex("CleaningEventId");

                    b.ToTable("CleaningEventAttendees");
                });

            modelBuilder.Entity("Domain.Complaint", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplainantName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ComplaintStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComplaintSubType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComplaintType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("Domain.Complaints.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pincode")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Addresses");

                    b.HasDiscriminator<string>("AddressType").HasValue("Address");
                });

            modelBuilder.Entity("Domain.Complaints.AddressTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedComplainantLocationArea")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedComplainantLocationHouseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedComplainantLocationLandmark")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedComplaintLocationArea")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedComplaintLocationLandmark")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AddressTranslation");
                });

            modelBuilder.Entity("Domain.Complaints.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.Complaints.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("StateName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Domain.Complaints.TranslatedComplaint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AddressTranslationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ComplaintId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FeedbackMessage")
                        .HasColumnType("TEXT");

                    b.Property<int>("Language")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TranslatedComplainantName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressTranslationId");

                    b.HasIndex("ComplaintId");

                    b.ToTable("TranslatedComplaints");
                });

            modelBuilder.Entity("Domain.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ComplaintId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "84455f24-2acd-4502-919a-a8ffbe50eb84",
                            ConcurrencyStamp = "f461cc62-40b2-4802-9017-d47f2cde7c9b",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "d1540805-2213-49eb-ba22-d6984f00805d",
                            ConcurrencyStamp = "7cd271b0-8914-4842-864b-ff79c48a4724",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Complaints.ComplainantLocation", b =>
                {
                    b.HasBaseType("Domain.Complaints.Address");

                    b.Property<string>("ComplainantLocationArea")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplainantLocationHouseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplainantLocationHouseNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplainantLocationLandmark")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplainantWardNo")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ComplainantLocation");
                });

            modelBuilder.Entity("Domain.Complaints.ComplaintLocation", b =>
                {
                    b.HasBaseType("Domain.Complaints.Address");

                    b.Property<string>("ComplaintLocationArea")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplaintLocationLandmark")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComplaintWardNo")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ComplaintLocation");
                });

            modelBuilder.Entity("Domain.CleaningEventAttendee", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("CleaningEvents")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CleaningEvent", "CleaningEvent")
                        .WithMany("Attendees")
                        .HasForeignKey("CleaningEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("CleaningEvent");
                });

            modelBuilder.Entity("Domain.Complaint", b =>
                {
                    b.HasOne("Domain.Complaints.Address", "Address")
                        .WithMany("Complaints")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Feedback", "Feedback")
                        .WithOne("Complaint")
                        .HasForeignKey("Domain.Complaint", "Id");

                    b.Navigation("Address");

                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("Domain.Complaints.Address", b =>
                {
                    b.HasOne("Domain.Complaints.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Complaints.State", "State")
                        .WithMany("Addresses")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Complaints.City", b =>
                {
                    b.HasOne("Domain.Complaints.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Complaints.TranslatedComplaint", b =>
                {
                    b.HasOne("Domain.Complaints.AddressTranslation", "AddressTranslation")
                        .WithMany()
                        .HasForeignKey("AddressTranslationId");

                    b.HasOne("Domain.Complaint", "Complaint")
                        .WithMany("TranslatedComplaints")
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressTranslation");

                    b.Navigation("Complaint");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("CleaningEvents");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Domain.CleaningEvent", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("Domain.Complaint", b =>
                {
                    b.Navigation("TranslatedComplaints");
                });

            modelBuilder.Entity("Domain.Complaints.Address", b =>
                {
                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("Domain.Complaints.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Complaints.State", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Feedback", b =>
                {
                    b.Navigation("Complaint");
                });
#pragma warning restore 612, 618
        }
    }
}