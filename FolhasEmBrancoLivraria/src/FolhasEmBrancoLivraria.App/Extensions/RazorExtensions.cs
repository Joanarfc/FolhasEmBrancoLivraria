using FolhasEmBrancoLivraria.Business.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace FolhasEmBrancoLivraria.App.Extensions
{
    public static class RazorExtensions
    {
        public static string CpfCnpjFormatacao(this RazorPage page, TipoFornecedor tipoFornecedor, string documento)
        {
            return ((int)tipoFornecedor) == 1 ? Convert.ToInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
