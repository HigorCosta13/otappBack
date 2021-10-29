﻿// <auto-generated />
using System;
using BackEndOTP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndOTP.Migrations
{
    [DbContext(typeof(OTAPPContext))]
    partial class OTAPPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndOTP.entity.Consulta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("hospitalID")
                        .HasColumnType("int");

                    b.Property<int>("usuarioID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("hospitalID");

                    b.HasIndex("usuarioID");

                    b.ToTable("consultas");
                });

            modelBuilder.Entity("BackEndOTP.entity.Hospital", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataconsulta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaConslta")
                        .HasColumnType("datetime2");

                    b.Property<string>("hospital")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("hospitals");
                });

            modelBuilder.Entity("BackEndOTP.entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("BackEndOTP.entity.Consulta", b =>
                {
                    b.HasOne("BackEndOTP.entity.Hospital", "hospital")
                        .WithMany()
                        .HasForeignKey("hospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndOTP.entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hospital");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
