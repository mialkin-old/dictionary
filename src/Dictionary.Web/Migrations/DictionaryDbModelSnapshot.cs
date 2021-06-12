﻿// <auto-generated />
using System;
using Dictionary.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dictionary.Web.Migrations
{
    [DbContext(typeof(DictionaryDb))]
    partial class DictionaryDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Dictionary.Database.Models.WordDto", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Transcription")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Translation")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("WordId");

                    b.HasIndex("Name", "LanguageId")
                        .IsUnique();

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
