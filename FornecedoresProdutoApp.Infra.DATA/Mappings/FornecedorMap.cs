using FornecedoresProdutoApp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.Infra.DATA.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("FORNECEDOR");
            builder.HasKey(f => f.IdFornecedor);

            builder.Property(f => f.IdFornecedor)
                .HasColumnName("ID_FORNECEDOR")
                .IsRequired();

            builder.Property(f => f.NomeFornecedor)
                .HasColumnName("NOME_FORNECEDOR")
                .IsRequired();

            builder.Property(f => f.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();
        }
    }
}
