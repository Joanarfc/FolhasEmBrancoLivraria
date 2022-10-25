using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FolhasEmBrancoLivraria.Business.Models
{
    public class Produto : Entidade
    {
        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public decimal Valor { get; set; }
        public string Ano { get; set; }

        public bool IsAtivo { get; set; }

        /* EF RELATION */
        public Fornecedor Fornecedor { get; set; }
    }
}
