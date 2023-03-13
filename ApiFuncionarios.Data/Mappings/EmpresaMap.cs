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
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela dp banco de dado
            builder.ToTable("EMPRESA");

            //definir a chave primaria
            builder.HasKey(e => e.IdEmpresa);

            //mapeamento dos campos
            builder.Property(e => e.IdEmpresa)
                  .HasColumnName("IDEMPRESA");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOME FANTASIA")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAO SOCIAL")
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(8)
                .IsRequired();

          
        }
    }
}
