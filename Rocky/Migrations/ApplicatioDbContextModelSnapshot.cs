﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rocky.Data;

namespace Rocky.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicatioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Rocky.Models.ApplicationType", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ApplicationType");
                });

            modelBuilder.Entity("Rocky.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Rocky.Models.Question", b =>
                {
                    b.Property<string>("questionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RootsurveyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("questionId");

                    b.HasIndex("RootsurveyId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Rocky.Models.Root", b =>
                {
                    b.Property<string>("surveyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Schema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("publishType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("surveyVersion")
                        .HasColumnType("bigint");

                    b.HasKey("surveyId");

                    b.ToTable("Root");
                });

            modelBuilder.Entity("Rocky.Models.Question", b =>
                {
                    b.HasOne("Rocky.Models.Root", null)
                        .WithMany("questions")
                        .HasForeignKey("RootsurveyId");
                });

            modelBuilder.Entity("Rocky.Models.Root", b =>
                {
                    b.Navigation("questions");
                });
#pragma warning restore 612, 618
        }
    }
}