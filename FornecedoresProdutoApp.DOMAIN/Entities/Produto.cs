using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Entities
{
    public class Produto
    {
        public Guid? IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public bool Ativo { get; set; } = true;

        #region Relacionamentos
        public Guid? IdFornecedor { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        #endregion
    }
}