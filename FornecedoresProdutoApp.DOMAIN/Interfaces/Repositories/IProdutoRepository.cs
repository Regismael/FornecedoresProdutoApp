using FornecedoresProdutoApp.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        List<Produto>? GetAll();
        Produto? GetById(Guid id);
        Fornecedor? ConsultarFornecedorPorId(Guid id);
    }
}
