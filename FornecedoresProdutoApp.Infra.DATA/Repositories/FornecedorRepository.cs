using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories;
using FornecedoresProdutoApp.Infra.DATA.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.Infra.DATA.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public void Add(Fornecedor fornecedor)
        {
            using (var context = new DataContext())
            {
                context.Add(fornecedor);
                context.SaveChanges();
            }
        }

        public void Delete(Fornecedor fornecedor)
        {
            using (var context = new DataContext())
            {
                var fornecedorExistente = context.Set<Fornecedor>()
                    .FirstOrDefault(f => f.IdFornecedor == fornecedor.IdFornecedor);

                if (fornecedorExistente != null)
                {
                    fornecedorExistente.Ativo = false;
                    context.SaveChanges();
                }
            }
        }

        public List<Fornecedor> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Fornecedor>()
                    .Where(p => p.Ativo)
                    .OrderBy(f => f.NomeFornecedor)
                    .ToList();
            }
        }

        public Fornecedor GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Fornecedor>()
                   .FirstOrDefault(f => f.IdFornecedor == id && f.Ativo);
            }
        }

        public void Update(Fornecedor fornecedor)
        {
            using(var context = new DataContext())
            {
                context.Update(fornecedor);
                context.SaveChanges();
            }
        }
    }
}
