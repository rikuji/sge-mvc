﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.Models;

namespace SGE.Migrations
{
    [DbContext(typeof(SGEContext))]
    [Migration("20191028105236_Turma-Responsavel-EstadoCivil")]
    partial class TurmaResponsavelEstadoCivil
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGE.Models.AnoDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ano");

                    b.HasKey("Id");

                    b.ToTable("AnoDisciplina");
                });

            modelBuilder.Entity("SGE.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoDisciplinaId");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.HasIndex("AnoDisciplinaId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("SGE.Models.EstadoCivil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("EstadoCivil");
                });

            modelBuilder.Entity("SGE.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Registro");

                    b.Property<string>("Sexo");

                    b.Property<int>("TipoUsuarioId");

                    b.Property<string>("Turno");

                    b.HasKey("Id");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SGE.Models.Responsavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .HasMaxLength(15);

                    b.Property<string>("CPF")
                        .HasMaxLength(15);

                    b.Property<string>("Celular")
                        .HasMaxLength(15);

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Complemento")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateNascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .HasMaxLength(50);

                    b.Property<int>("EstadoCivilId");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .HasMaxLength(10);

                    b.Property<string>("ResposavelFinanceiro")
                        .HasMaxLength(50);

                    b.Property<string>("ResposavelLegal")
                        .HasMaxLength(50);

                    b.Property<string>("Sexo")
                        .HasMaxLength(15);

                    b.Property<string>("TelefoneFixo")
                        .HasMaxLength(15);

                    b.Property<int>("TipoUsuarioId");

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("SGE.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Perfil");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("SGE.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Periodo");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("SGE.Models.Disciplina", b =>
                {
                    b.HasOne("SGE.Models.AnoDisciplina", "AnoDisciplina")
                        .WithMany()
                        .HasForeignKey("AnoDisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGE.Models.Professor", b =>
                {
                    b.HasOne("SGE.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGE.Models.Responsavel", b =>
                {
                    b.HasOne("SGE.Models.EstadoCivil", "EstadoCivil")
                        .WithMany()
                        .HasForeignKey("EstadoCivilId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGE.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
