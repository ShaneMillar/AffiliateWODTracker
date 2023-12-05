﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20231123000037_IdentityLogic")]
    partial class IdentityLogic
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.AffiliateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Affiliates");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WODId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WODId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.ScoreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeCompleted")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalReps")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WODId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WODId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AffiliateId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AffiliateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.WODEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AffiliateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCap")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AffiliateId");

                    b.ToTable("WODs");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.CommentEntity", b =>
                {
                    b.HasOne("AffiliateWODTracker.Data.DataModels.UserEntity", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AffiliateWODTracker.Data.DataModels.WODEntity", "WOD")
                        .WithMany("Comments")
                        .HasForeignKey("WODId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WOD");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.ScoreEntity", b =>
                {
                    b.HasOne("AffiliateWODTracker.Data.DataModels.UserEntity", "User")
                        .WithMany("Scores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AffiliateWODTracker.Data.DataModels.WODEntity", "WOD")
                        .WithMany("Scores")
                        .HasForeignKey("WODId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WOD");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.UserEntity", b =>
                {
                    b.HasOne("AffiliateWODTracker.Data.DataModels.AffiliateEntity", "Affiliate")
                        .WithMany("Users")
                        .HasForeignKey("AffiliateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Affiliate");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.WODEntity", b =>
                {
                    b.HasOne("AffiliateWODTracker.Data.DataModels.AffiliateEntity", "Affiliate")
                        .WithMany("WODs")
                        .HasForeignKey("AffiliateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Affiliate");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.AffiliateEntity", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("WODs");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.UserEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("AffiliateWODTracker.Data.DataModels.WODEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
