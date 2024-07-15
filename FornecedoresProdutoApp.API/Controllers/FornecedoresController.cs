using FornecedoresProdutoApp.API.DTOs.FornecedorDto;
using FornecedoresProdutoApp.DOMAIN.Entities;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FornecedoresProdutoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorDomainService _fornecedorDomainService;

        public FornecedoresController(IFornecedorDomainService fornecedorDomainService)
        {
            _fornecedorDomainService = fornecedorDomainService;
        }

        [HttpPost]
        [Route("cadastrar")]
        [ProducesResponseType(typeof(FornecedorPostResponseDto), 201)]
        public IActionResult Post(FornecedorPostRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor
                {
                    NomeFornecedor = dto.NomeFornecedor,
                    Ativo = true
                };

                _fornecedorDomainService.AdicionarFornecedor(fornecedor);

                var response = new FornecedorPostResponseDto
                {
                    IdFornecedor = fornecedor.IdFornecedor.Value,
                    NomeFornecedor = fornecedor.NomeFornecedor,
                    Ativo = fornecedor.Ativo
                };

                return StatusCode(201, new
                {
                    Message = "Fornecedor cadastrado com sucesso!",
                    response
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro desconhecido ao cadastrar fornecedor." });
            }
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(FornecedorPutResponseDto), 200)]
        public IActionResult Put(FornecedorPutRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor
                {
                    IdFornecedor = dto.IdFornecedor,
                    NomeFornecedor = dto.NomeFornecedor,
                    Ativo = true
                };

                _fornecedorDomainService.AtualizarFornecedor(fornecedor);

                var response = new FornecedorPutResponseDto
                {
                    IdFornecedor = fornecedor.IdFornecedor.Value,
                    NomeFornecedor = fornecedor.NomeFornecedor,
                    Ativo = fornecedor.Ativo
                };

                return Ok(new
                {
                    Message = "Fornecedor editado com sucesso!",
                    response
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro desconhecido ao editar fornecedor." });
            }
        }

        [HttpPut("desativar/{id}")]
        public IActionResult Inactive(Guid id)
        {
            try
            {
                _fornecedorDomainService.RemoverFornecedor(id);

                return Ok(new
                {
                    Message = "Fornecedor desativado com sucesso!"
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro desconhecido ao desativar fornecedor." });
            }
        }

        [HttpGet]
        [Route("consultaTotal")]
        [ProducesResponseType(typeof(List<FornecedorGetResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var fornecedores = _fornecedorDomainService.ConsultarTodosOsFornecedores();

                var response = fornecedores.Select(fornecedor => new FornecedorGetResponseDto
                {
                    IdFornecedor = fornecedor.IdFornecedor.Value,
                    NomeFornecedor = fornecedor.NomeFornecedor,
                    Ativo = fornecedor.Ativo
                }).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro desconhecido ao consultar fornecedores." });
            }
        }

        [HttpGet("consultaPorId/{id}")]
        [ProducesResponseType(typeof(FornecedorGetResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var fornecedor = _fornecedorDomainService.ConsultarFornecedorPorId(id);

                var response = new FornecedorGetResponseDto
                {
                    IdFornecedor = fornecedor.IdFornecedor.Value,
                    NomeFornecedor = fornecedor.NomeFornecedor,
                    Ativo = fornecedor.Ativo
                };

                return Ok(response);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro desconhecido ao consultar fornecedor." });
            }
        }
    }
}
