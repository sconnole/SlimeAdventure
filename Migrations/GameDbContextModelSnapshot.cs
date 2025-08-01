﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlimeAdventure.Data;

#nullable disable

namespace SlimeAdventure.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("SlimeAdventure.Data.Models.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SlimeAdventure.Data.Models.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EastRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NorthRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SouthRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WestRoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EastRoomId");

                    b.HasIndex("NorthRoomId");

                    b.HasIndex("SouthRoomId");

                    b.HasIndex("WestRoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SlimeAdventure.Data.Models.RoomEntity", b =>
                {
                    b.HasOne("SlimeAdventure.Data.Models.RoomEntity", "EastRoom")
                        .WithMany()
                        .HasForeignKey("EastRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SlimeAdventure.Data.Models.RoomEntity", "NorthRoom")
                        .WithMany()
                        .HasForeignKey("NorthRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SlimeAdventure.Data.Models.RoomEntity", "SouthRoom")
                        .WithMany()
                        .HasForeignKey("SouthRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SlimeAdventure.Data.Models.RoomEntity", "WestRoom")
                        .WithMany()
                        .HasForeignKey("WestRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("EastRoom");

                    b.Navigation("NorthRoom");

                    b.Navigation("SouthRoom");

                    b.Navigation("WestRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
