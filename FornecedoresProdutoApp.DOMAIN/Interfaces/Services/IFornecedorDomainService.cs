using FornecedoresProdutoApp.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Interfaces.Services
{
    public interface IFornecedorDomainService
    {
        void AdicionarFornecedor(Fornecedor fornecedor);
        void AtualizarFornecedor(Fornecedor fornecedor);
        void RemoverFornecedor(Guid id);
        List<Fornecedor> ConsultarTodosOsFornecedores();
        Fornecedor? ConsultarFornecedorPorId(Guid id);
    }
}
