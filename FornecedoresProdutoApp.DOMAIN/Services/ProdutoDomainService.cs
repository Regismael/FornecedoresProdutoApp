using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FornecedoresProdutoApp.DOMAIN.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarProduto(Produto produto)
        {
            produto.IdProduto = Guid.NewGuid();
            produto.Ativo = true;

            _produtoRepository.Add(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            var existente = ConsultarProdutoPorId(produto.IdProduto.Value);

            if (existente == null)
                throw new ArgumentException("O ID solicitado é inexistente. Por favor, verifique.");

            _produtoRepository.Update(produto);
        }

        public Produto ConsultarProdutoPorId(Guid id)
        {
            var produto = _produtoRepository.GetById(id);

            if (produto == null)
                throw new ArgumentException("O ID solicitado é inexistente. Por favor, verifique.");

            if (!produto.Ativo)
                throw new ArgumentException("O produto consultado está inativo.");

            return produto;
        }

        public List<Produto> ConsultarTodosOsProdutos()
        {
            return _produtoRepository.GetAll().Where(p => p.Ativo).ToList();
        }

        public void RemoverProduto(Guid id)
        {
            var produto = ConsultarProdutoPorId(id);

            _produtoRepository.Delete(produto);
        }
    }
}
