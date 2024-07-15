namespace FornecedoresProdutoApp.API.DTOs.FornecedorDto
{
    public class FornecedorPutResponseDto
    {
        public Guid? IdFornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public bool Ativo { get; set; }

    }
}
