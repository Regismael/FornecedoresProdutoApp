using FornecedoresProdutoApp.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Interfaces.Services
{
    public interface IProdutoDomainService
    {
        void AdicionarProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void RemoverProduto(Guid id);
        List<Produto> ConsultarTodosOsProdutos();
        Produto? ConsultarProdutoPorId(Guid id);
    }
}
