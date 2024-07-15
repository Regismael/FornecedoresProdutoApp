using System.ComponentModel.DataAnnotations;

namespace FornecedoresProdutoApp.API.DTOs.FornecedorDto
{
    public class FornecedorPostRequestDto
    {
        [MinLength(6, ErrorMessage = "O nome do fornecedor deve conter, no mínimo, {1} caracateres do ")]
        [MaxLength(180, ErrorMessage = "O nome do fornecedor deve conter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo do nome do fornecedor é de preenchimento obrigatório.")]
        public string? NomeFornecedor { get; set; }
    }
}
