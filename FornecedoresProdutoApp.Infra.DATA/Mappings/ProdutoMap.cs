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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("ID_PRODUTO")
                .IsRequired();

            builder.Property(p => p.NomeProduto)
                .HasColumnName("NOME_PRODUTO")
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("PRECO")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(p => p.IdFornecedor)
                .HasColumnName("ID_FORNECEDOR")
                .IsRequired();

            builder.HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
