﻿// <auto-generated />
using System;
using EFCoreRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreRelations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CLAreas.AreaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("AreaModel");
                });

            modelBuilder.Entity("CLPeople.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaModelId");

                    b.Property<int?>("PlaceModelId");

                    b.Property<int?>("SpaceModelId");

                    b.HasKey("Id");

                    b.HasIndex("AreaModelId");

                    b.HasIndex("PlaceModelId");

                    b.HasIndex("SpaceModelId");

                    b.ToTable("PersonModel");
                });

            modelBuilder.Entity("CLPlaces.PlaceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("PlaceModel");
                });

            modelBuilder.Entity("CLSpaces.SpaceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("SpaceModel");
                });

            modelBuilder.Entity("CLPeople.PersonModel", b =>
                {
                    b.HasOne("CLAreas.AreaModel")
                        .WithMany("People")
                        .HasForeignKey("AreaModelId");

                    b.HasOne("CLPlaces.PlaceModel")
                        .WithMany("People")
                        .HasForeignKey("PlaceModelId");

                    b.HasOne("CLSpaces.SpaceModel")
                        .WithMany("People")
                        .HasForeignKey("SpaceModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
