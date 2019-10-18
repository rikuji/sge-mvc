﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.Models;

namespace SGE.Migrations
{
    [DbContext(typeof(SGEContext))]
    [Migration("20191018104910_anoDisciplina")]
    partial class anoDisciplina
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

            modelBuilder.Entity("SGE.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Perfil");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");
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
#pragma warning restore 612, 618
        }
    }
}
