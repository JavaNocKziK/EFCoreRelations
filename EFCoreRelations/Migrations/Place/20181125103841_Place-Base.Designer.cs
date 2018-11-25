﻿// <auto-generated />
using System;
using EFCoreRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreRelations.Migrations.Place
{
    [DbContext(typeof(PlaceContext))]
    [Migration("20181125103841_Place-Base")]
    partial class PlaceBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreRelations.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlaceEntityId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("EFCoreRelations.PlaceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("EFCoreRelations.PersonEntity", b =>
                {
                    b.HasOne("EFCoreRelations.PlaceEntity")
                        .WithMany("People")
                        .HasForeignKey("PlaceEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}