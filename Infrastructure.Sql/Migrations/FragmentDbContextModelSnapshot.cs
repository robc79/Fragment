﻿// <auto-generated />
using System;
using Fragment.Infrastructure.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Sql.Migrations
{
    [DbContext(typeof(FragmentDbContext))]
    partial class FragmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Fragment.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Fragment.Domain.TextFragment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(-1)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TextFragments");
                });

            modelBuilder.Entity("TextFragmentTags", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TextFragmentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagsId", "TextFragmentId");

                    b.HasIndex("TextFragmentId");

                    b.ToTable("TextFragmentTags");
                });

            modelBuilder.Entity("TextFragmentTags", b =>
                {
                    b.HasOne("Fragment.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fragment.Domain.TextFragment", null)
                        .WithMany()
                        .HasForeignKey("TextFragmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
