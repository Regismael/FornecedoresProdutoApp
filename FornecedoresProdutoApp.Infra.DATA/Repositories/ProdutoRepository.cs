using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories;
using FornecedoresProdutoApp.Infra.DATA.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.Infra.DATA.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Add(Produto produto)
        {
            using (var context = new DataContext())
            {
                context.Add(produto);
                context.SaveChanges();
            }
        }

        public Fornecedor? ConsultarFornecedorPorId(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Fornecedor>()
                    .FirstOrDefault(f => f.IdFornecedor == id && f.Ativo);
            }
        }

        public void Delete(Produto produto)
        {
            using (var context = new DataContext())
            {
                var produtoExistente = context.Set<Produto>()
                    .FirstOrDefault(p => p.IdProduto == produto.IdProduto);

                if (produtoExistente != null)
                {
                    produtoExistente.Ativo = false;
                    context.SaveChanges();
                }

            }
        }

        public List<Produto>? GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Produto>()
                    .Where(p => p.Ativo)
                    .OrderBy(p => p.NomeProduto)
                    .ToList();
            }
        }

        public Produto? GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Produto>()
                   .FirstOrDefault(p => p.IdProduto == id && p.Ativo);
            }
        }

        public void Update(Produto produto)
        {
            using(var context = new DataContext())
            {
                context.Update(produto);
                context.SaveChanges();
            }
        }
    }
}
