﻿// <auto-generated />
using System;
using LibaryWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibaryWebApi.Migrations
{
    [DbContext(typeof(LibaryContext))]
    partial class LibaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibaryWebApi.BookInfo", b =>
                {
                    b.Property<int>("BookInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Barcode");

                    b.Property<int>("Count");

                    b.Property<string>("Title");

                    b.Property<string>("Version");

                    b.HasKey("BookInfoId");

                    b.ToTable("BookInfos");
                });

            modelBuilder.Entity("LibaryWebApi.IssuedBookInfo", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("BookInfoId");

                    b.Property<DateTime>("IssueDate");

                    b.Property<DateTime>("ReturnDate");

                    b.Property<bool>("Returned");

                    b.HasKey("StudentId", "BookInfoId");

                    b.HasIndex("BookInfoId");

                    b.ToTable("IssuedBookInfos");
                });

            modelBuilder.Entity("LibaryWebApi.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FineAmount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StudentInfos");
                });

            modelBuilder.Entity("LibaryWebApi.IssuedBookInfo", b =>
                {
                    b.HasOne("LibaryWebApi.BookInfo", "BookInfo")
                        .WithMany()
                        .HasForeignKey("BookInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibaryWebApi.StudentInfo", "StudentInfo")
                        .WithMany("IssuedBookByStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}