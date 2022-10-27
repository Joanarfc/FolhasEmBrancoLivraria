using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace FolhasEmBrancoLivraria.Business.Models
{
    public enum TipoFornecedor
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}
