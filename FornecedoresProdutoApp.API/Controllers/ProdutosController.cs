using FornecedoresProdutoApp.API.DTOs.ProdutoDto;
using FornecedoresProdutoApp.DOMAIN.DTOs;
using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FornecedoresProdutoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutosController(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(ProdutoPostResponseDto), 201)]
        public IActionResult Post([FromBody] ProdutoPostRequestDTO dto)
        {
            try
            {
                var produto = new Produto
                {
                    NomeProduto = dto.NomeProduto,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    Ativo = true,
                    IdFornecedor = dto.IdFornecedor
                };

                _produtoDomainService.AdicionarProduto(produto);

                var response = new ProdutoPostResponseDto
                {
                    IdProduto = produto.IdProduto.Value,
                    NomeProduto = produto.NomeProduto,
                    Preco = produto.Preco.Value,
                    Quantidade = produto.Quantidade.Value,
                    Ativo = produto.Ativo,
                    IdFornecedor = produto.IdFornecedor.Value
                };

                return StatusCode(201, new
                {
                    Message = "Produto criado com sucesso!",
                    response
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        [ProducesResponseType(typeof(ProdutoPutResponseDto), 200)]
        public IActionResult Put(ProdutoPutRequestDto dto)
        {
            try
            {
                var produto = new Produto
                {
                    IdProduto = dto.IdProduto,
                    NomeProduto = dto.NomeProduto,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    Ativo = true,
                    IdFornecedor = dto.IdFornecedor
                };

                _produtoDomainService.AtualizarProduto(produto);

                var response = new ProdutoPostResponseDto
                {
                    IdProduto = produto.IdProduto.Value,
                    NomeProduto = produto.NomeProduto,
                    Preco = produto.Preco.Value,
                    Quantidade = produto.Quantidade.Value,
                    Ativo = produto.Ativo,
                    IdFornecedor = produto.IdFornecedor.Value
                };

                return StatusCode(200, new
                {
                    Message = "Produto atualizado com sucesso!",
                    response
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("desativar/{id}")]
        public IActionResult Inactivate(Guid id)
        {
            try
            {
                _produtoDomainService.RemoverProduto(id);

                return StatusCode(200, new
                {
                    Message = "Produto desativado com sucesso!"
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("verificacaoTotal")]
        [ProducesResponseType(typeof(List<ProdutoGetResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var produtos = _produtoDomainService.ConsultarTodosOsProdutos();

                var response = produtos.Select(produto => new ProdutoGetResponseDto
                {
                    IdProduto = produto.IdProduto.Value,
                    NomeProduto = produto.NomeProduto,
                    Preco = produto.Preco.Value,
                    Quantidade = produto.Quantidade.Value,
                    Ativo = produto.Ativo,
                    IdFornecedor = produto.IdFornecedor.Value
                }).ToList();

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("verificacaoPorId/{id}")]
        [ProducesResponseType(typeof(ProdutoGetResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var produto = _produtoDomainService.ConsultarProdutoPorId(id);

                var response = new ProdutoGetResponseDto
                {
                    IdProduto = produto.IdProduto.Value,
                    NomeProduto = produto.NomeProduto,
                    Preco = produto.Preco.Value,
                    Quantidade = produto.Quantidade.Value,
                    Ativo = produto.Ativo,
                    IdFornecedor = produto.IdFornecedor.Value
                };
                return StatusCode(200, response);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
