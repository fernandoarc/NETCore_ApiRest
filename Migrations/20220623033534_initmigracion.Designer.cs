﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore_API.Model.BD;

namespace NetCore_API.Migrations
{
    [DbContext(typeof(BicicletaContext))]
    [Migration("20220623033534_initmigracion")]
    partial class initmigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.Bicicleta", b =>
                {
                    b.Property<int>("IdBicicleta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdBicicletaModelo")
                        .HasColumnType("int");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<bool>("Vigente")
                        .HasColumnType("bit")
                        .IsUnicode(false);

                    b.HasKey("IdBicicleta");

                    b.HasIndex("IdBicicletaModelo");

                    b.ToTable("Bicicleta");
                });

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.BicicletaCategoria", b =>
                {
                    b.Property<int>("IdBicicletaCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdBicicletaCategoria");

                    b.ToTable("BicicletaCategoria");
                });

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.BicicletaMarca", b =>
                {
                    b.Property<int>("IdBicicletaMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdBicicletaMarca");

                    b.ToTable("BicicletaMarca");
                });

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.BicicletaModelo", b =>
                {
                    b.Property<int>("IdBicicletaModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int")
                        .IsUnicode(false);

                    b.Property<int>("IdBicicletaCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdBicicletaMarca")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.HasKey("IdBicicletaModelo");

                    b.HasIndex("IdBicicletaCategoria");

                    b.HasIndex("IdBicicletaMarca");

                    b.ToTable("BicicletaModelo");
                });

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.Bicicleta", b =>
                {
                    b.HasOne("NetCore_API.Model.Entidades.Bike.BicicletaModelo", "BicicletaModelo")
                        .WithMany("Bicicleta")
                        .HasForeignKey("IdBicicletaModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetCore_API.Model.Entidades.Bike.BicicletaModelo", b =>
                {
                    b.HasOne("NetCore_API.Model.Entidades.Bike.BicicletaCategoria", "BicicletaCategoria")
                        .WithMany("BicicletaModelo")
                        .HasForeignKey("IdBicicletaCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCore_API.Model.Entidades.Bike.BicicletaMarca", "BicicletaMarca")
                        .WithMany("BicicletaModelo")
                        .HasForeignKey("IdBicicletaMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
