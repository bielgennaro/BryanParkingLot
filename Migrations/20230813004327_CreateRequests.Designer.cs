﻿// <auto-generated />
using System;
using BryanParkingLot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BryanParkingLot.Migrations
{
    [DbContext(typeof(BryanParkingLotContext))]
    [Migration("20230813004327_CreateRequests")]
    partial class CreateRequests
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("BryanParkingLot.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estacionado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Carros", (string)null);
                });

            modelBuilder.Entity("BryanParkingLot.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("BryanParkingLot.Models.Carro", b =>
                {
                    b.HasOne("BryanParkingLot.Models.Cliente", "Cliente")
                        .WithOne("Carro")
                        .HasForeignKey("BryanParkingLot.Models.Carro", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BryanParkingLot.Models.Cliente", b =>
                {
                    b.Navigation("Carro")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
