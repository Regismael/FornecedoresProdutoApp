using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Services
{
    public class FornecedorDomainService : IFornecedorDomainService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorDomainService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                throw new ArgumentNullException(nameof(fornecedor));
            }

            var fornecedorExistente = _fornecedorRepository.GetAll()
                .FirstOrDefault(f => f.NomeFornecedor == fornecedor.NomeFornecedor);

            if (fornecedorExistente != null)
            {
                throw new ArgumentException("Fornecedor já existe.");
            }

            fornecedor.IdFornecedor = Guid.NewGuid();
            _fornecedorRepository.Add(fornecedor);
        }

        public void AtualizarFornecedor(Fornecedor fornecedor)
        {
            var existente = _fornecedorRepository.GetById(fornecedor.IdFornecedor.Value);

            if (existente == null)
            {
                throw new ArgumentException("O ID solicitado é inexistente. Por favor, verifique.");
            }

            _fornecedorRepository.Update(fornecedor);
        }

        public Fornecedor? ConsultarFornecedorPorId(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);

            if (fornecedor == null)
            {
                throw new ArgumentException("O ID solicitado é inexistente. Por favor, verifique.");
            }

            if (!fornecedor.Ativo)
            {
                throw new ArgumentException("O fornecedor consultado está inativo.");
            }

            return fornecedor;
        }

        public List<Fornecedor> ConsultarTodosOsFornecedores()
        {
            return _fornecedorRepository.GetAll()
                .Where(f => f.Ativo)
                .ToList();
        }

        public void RemoverFornecedor(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);

            if (fornecedor == null)
            {
                throw new ArgumentException("O ID solicitado é inexistente. Por favor, verifique.");
            }

            _fornecedorRepository.Delete(fornecedor);
        }
    }
}
