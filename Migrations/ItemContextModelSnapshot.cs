﻿// <auto-generated />
using System;
using Empyreum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empyreum.Migrations
{
    [DbContext(typeof(ItemContext))]
    partial class ItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Empyreum.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Birthday")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Job")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LogicalDCName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhysicalDCName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Empyreum.Models.Item", b =>
                {
                    b.Property<int>("ItemServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CharID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ItemServerId");

                    b.HasIndex("CharID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Empyreum.Models.Item", b =>
                {
                    b.HasOne("Empyreum.Models.Character", "Character")
                        .WithMany("CharItems")
                        .HasForeignKey("CharID");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Empyreum.Models.Character", b =>
                {
                    b.Navigation("CharItems");
                });
#pragma warning restore 612, 618
        }
    }
}
