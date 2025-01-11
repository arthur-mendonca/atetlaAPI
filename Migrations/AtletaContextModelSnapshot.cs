﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using atetlaAPI.models;

#nullable disable

namespace AtletaApi.Migrations
{
    [DbContext(typeof(AtletaContext))]
    partial class AtletaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AtetlaAPI.models.Atleta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Altura")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Peso")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Atletas");
                });
#pragma warning restore 612, 618
        }
    }
}
