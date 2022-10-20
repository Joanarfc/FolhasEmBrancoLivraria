using System;
using System.Collections.Generic;
using System.Text;

namespace FolhasEmBrancoLivraria.Business.Models
{
    public class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool IsAtivo { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
