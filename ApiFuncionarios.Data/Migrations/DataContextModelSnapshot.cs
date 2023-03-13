﻿// <auto-generated />
using System;
using ApiFuncionarios.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiFuncionarios.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiFuncionarios.Data.Entities.Empresa", b =>
                {
                    b.Property<Guid>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CNPJ");

                  

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME FANTASIA");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RAZAO SOCIAL");

                    b.HasKey("IdEmpresa");

                    b.ToTable("EMPRESA", (string)null);
                });

            modelBuilder.Entity("ApiFuncionarios.Data.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDFUNCIONARIO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAADIMISSAO");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("MATRICULA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("FUNCIONARIO", (string)null);
                });

            modelBuilder.Entity("ApiFuncionarios.Data.Entities.Funcionario", b =>
                {
                    b.HasOne("ApiFuncionarios.Data.Entities.Empresa", "Empresa")
                        .WithMany("Funcionario")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ApiFuncionarios.Data.Entities.Empresa", b =>
                {
                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
