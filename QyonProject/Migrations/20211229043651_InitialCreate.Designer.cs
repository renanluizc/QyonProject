﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QyonProject.Data;

namespace QyonProject.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20211229043651_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("QyonProject.Models.Historic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CompetidorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCorrida")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("PistaId")
                        .HasColumnType("integer");

                    b.Property<double>("TempoGasto")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CompetidorId");

                    b.HasIndex("PistaId");

                    b.ToTable("Historics");
                });

            modelBuilder.Entity("QyonProject.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Altura")
                        .HasColumnType("double precision");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision");

                    b.Property<string>("Sexo")
                        .HasColumnType("text");

                    b.Property<double>("TemperaturaMediaCorpo")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("QyonProject.Models.Speedway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Speedways");
                });

            modelBuilder.Entity("QyonProject.Models.Historic", b =>
                {
                    b.HasOne("QyonProject.Models.Register", "Competidor")
                        .WithMany()
                        .HasForeignKey("CompetidorId");

                    b.HasOne("QyonProject.Models.Speedway", "Pista")
                        .WithMany()
                        .HasForeignKey("PistaId");

                    b.Navigation("Competidor");

                    b.Navigation("Pista");
                });
#pragma warning restore 612, 618
        }
    }
}
