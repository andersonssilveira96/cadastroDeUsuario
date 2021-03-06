﻿// <auto-generated />
using System;
using Confitec.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confitec.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200604235112_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Confitec.Domain.Entities.Escolaridade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Escolaridade");

                    b.HasData(
                        new { Id = 1, Descricao = "Infantil" },
                        new { Id = 2, Descricao = "Fundamental" },
                        new { Id = 3, Descricao = "Médio" },
                        new { Id = 4, Descricao = "Superior" }
                    );
                });

            modelBuilder.Entity("Confitec.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<int>("EscolaridadeId");

                    b.Property<string>("Nome")
                        .HasMaxLength(80);

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("EscolaridadeId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new { Id = 1, DataNascimento = new DateTime(2020, 6, 4, 20, 51, 12, 789, DateTimeKind.Local), Email = "usuario1@teste.com.br", EscolaridadeId = 1, Nome = "Usuario 1", Sobrenome = "De Souza" },
                        new { Id = 2, DataNascimento = new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), Email = "usuario2@teste.com.br", EscolaridadeId = 2, Nome = "Usuario 2", Sobrenome = "De Souza" },
                        new { Id = 3, DataNascimento = new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), Email = "usuario3@teste.com.br", EscolaridadeId = 3, Nome = "Usuario 3", Sobrenome = "De Souza" },
                        new { Id = 4, DataNascimento = new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), Email = "usuario4@teste.com.br", EscolaridadeId = 4, Nome = "Usuario 4", Sobrenome = "De Souza" }
                    );
                });

            modelBuilder.Entity("Confitec.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Confitec.Domain.Entities.Escolaridade", "Escolaridade")
                        .WithMany("Usuarios")
                        .HasForeignKey("EscolaridadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
