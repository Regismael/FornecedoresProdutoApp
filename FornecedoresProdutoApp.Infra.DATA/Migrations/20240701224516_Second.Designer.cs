﻿// <auto-generated />
using System;
using FornecedoresProdutoApp.Infra.DATA.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FornecedoresProdutoApp.Infra.DATA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240701224516_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FornecedoresProdutoApp.DOMAIN.Entities.Fornecedor", b =>
                {
                    b.Property<Guid?>("IdFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_FORNECEDOR");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<string>("NomeFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME_FORNECEDOR");

                    b.HasKey("IdFornecedor");

                    b.ToTable("FORNECEDOR", (string)null);
                });

            modelBuilder.Entity("FornecedoresProdutoApp.DOMAIN.Entities.Produto", b =>
                {
                    b.Property<Guid?>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_PRODUTO");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<Guid?>("IdFornecedor")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_FORNECEDOR");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)")
                        .HasColumnName("NOME_PRODUTO");

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRECO");

                    b.Property<int?>("Quantidade")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADE");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("PRODUTO", (string)null);
                });

            modelBuilder.Entity("FornecedoresProdutoApp.DOMAIN.Entities.Produto", b =>
                {
                    b.HasOne("FornecedoresProdutoApp.DOMAIN.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("FornecedoresProdutoApp.DOMAIN.Entities.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
