﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nickolas_mendonca_feed_aluno.Models;

#nullable disable

namespace nickolas_mendonca_feed_aluno.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240413215609_M04AddTableDisciplina")]
    partial class M04AddTableDisciplina
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.ProfessorDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Resumo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ValorAula")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ProfessorDisciplina");
                });

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.ProfessorDisciplina", b =>
                {
                    b.HasOne("nickolas_mendonca_feed_aluno.Models.Disciplina", "Disciplina")
                        .WithMany("Disciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nickolas_mendonca_feed_aluno.Models.Usuario", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.Disciplina", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("nickolas_mendonca_feed_aluno.Models.Usuario", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
