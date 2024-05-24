﻿// <auto-generated />
using System;
using DataAccessLayer.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.Property<int>("CategoriesCategoryID")
                        .HasColumnType("int");

                    b.Property<Guid>("PostsPostID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesCategoryID", "PostsPostID");

                    b.HasIndex("PostsPostID");

                    b.ToTable("CategoryPost");
                });

            modelBuilder.Entity("EntityLayer.Entites.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Surname")
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
                });

            modelBuilder.Entity("EntityLayer.Entites.Application", b =>
                {
                    b.Property<Guid>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ApplicationStatus")
                        .HasColumnType("int");

                    b.Property<byte[]>("CV")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("EntityLayer.Entites.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "C#"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Java"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = ".NET Core"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "Spring Framework"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "Angular"
                        },
                        new
                        {
                            CategoryID = 6,
                            Name = "React"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entites.Offer", b =>
                {
                    b.Property<Guid>("OfferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OfferStatus")
                        .HasColumnType("int");

                    b.Property<string>("Offeree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OfferID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PostID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("EntityLayer.Entites.Post", b =>
                {
                    b.Property<Guid>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryIDs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postStatus")
                        .HasColumnType("int");

                    b.HasKey("PostID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EntityLayer.Entites.Stat", b =>
                {
                    b.Property<Guid>("StatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PostOfNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ReceivedOfOfferNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SentOfOfferNumber")
                        .HasColumnType("int");

                    b.HasKey("StatID");

                    b.HasIndex("AppUserID")
                        .IsUnique()
                        .HasFilter("[AppUserID] IS NOT NULL");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.HasOne("EntityLayer.Entites.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entites.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Entites.Application", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Entites.Offer", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", "AppUser")
                        .WithMany("Offers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EntityLayer.Entites.Post", "Post")
                        .WithMany("Offers")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("EntityLayer.Entites.Post", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", "AppUser")
                        .WithMany("Posts")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Entites.Stat", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", null)
                        .WithOne("Stat")
                        .HasForeignKey("EntityLayer.Entites.Stat", "AppUserID");
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
                    b.HasOne("EntityLayer.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", null)
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

                    b.HasOne("EntityLayer.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EntityLayer.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Entites.AppUser", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Posts");

                    b.Navigation("Stat")
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Entites.Post", b =>
                {
                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
