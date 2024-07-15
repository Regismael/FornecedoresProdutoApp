
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedoresProdutoApp.DOMAIN.Entities
{
    public class Fornecedor
    {
        public Guid? IdFornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public bool Ativo { get; set; } = true;

        #region Relacionamentos
        public List<Produto>? Produtos { get; set; }
        #endregion
    }
}