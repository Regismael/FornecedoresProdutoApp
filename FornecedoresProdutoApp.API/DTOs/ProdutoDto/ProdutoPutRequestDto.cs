using System.ComponentModel.DataAnnotations;

namespace FornecedoresProdutoApp.API.DTOs.ProdutoDto
{
    public class ProdutoPutRequestDto
    {
        public Guid? IdProduto { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome do produto é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do produto deve ter, no máximo, 100 caracteres.")]
        [MinLength(6, ErrorMessage = "O nome do produto deve ter, mo mínimo, 6 caracteres.")]
        public string? NomeProduto { get; set; }

        [Required(ErrorMessage = "O preenchimento do preço é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O preenchimento da quantidade é obrigatório.")]
        public int Quantidade { get; set; }
        public Guid IdFornecedor { get; set; }
    }
}
