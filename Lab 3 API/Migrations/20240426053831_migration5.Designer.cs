﻿// <auto-generated />
using Lab_3_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab_3_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426053831_migration5")]
    partial class migration5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab_3_API.Models.Hobbys", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HobbyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeoplesPeopleId")
                        .HasColumnType("int");

                    b.HasKey("HobbyId");

                    b.HasIndex("PeoplesPeopleId");

                    b.ToTable("Hobbys");
                });

            modelBuilder.Entity("Lab_3_API.Models.Peoples", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeopleId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("Lab_3_API.Models.Webpages", b =>
                {
                    b.Property<int>("WebpageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WebpageId"));

                    b.Property<int>("HobbysHobbyId")
                        .HasColumnType("int");

                    b.Property<string>("Webpage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebpageId");

                    b.HasIndex("HobbysHobbyId");

                    b.ToTable("Webpages");
                });

            modelBuilder.Entity("Lab_3_API.Models.Hobbys", b =>
                {
                    b.HasOne("Lab_3_API.Models.Peoples", null)
                        .WithMany("Hobbys")
                        .HasForeignKey("PeoplesPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab_3_API.Models.Webpages", b =>
                {
                    b.HasOne("Lab_3_API.Models.Hobbys", null)
                        .WithMany("Webpages")
                        .HasForeignKey("HobbysHobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab_3_API.Models.Hobbys", b =>
                {
                    b.Navigation("Webpages");
                });

            modelBuilder.Entity("Lab_3_API.Models.Peoples", b =>
                {
                    b.Navigation("Hobbys");
                });
#pragma warning restore 612, 618
        }
    }
}
