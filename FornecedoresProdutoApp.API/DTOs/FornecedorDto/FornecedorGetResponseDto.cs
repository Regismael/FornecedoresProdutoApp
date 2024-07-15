namespace FornecedoresProdutoApp.API.DTOs.FornecedorDto
{
    public class FornecedorGetResponseDto
    {
        public Guid IdFornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}
