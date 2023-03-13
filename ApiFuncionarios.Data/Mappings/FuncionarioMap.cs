using ApiFuncionarios.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFuncionarios.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabel
            builder.ToTable("FUNCIONARIO");

            //chave primária
            builder.HasKey(f =>f.IdFuncionario);

            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .IsRequired();



            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADIMISSAO")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionario)
              .HasForeignKey(f => f.IdEmpresa);


        }
    }
}
