using FolhasEmBrancoLivraria.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task AtualizarEndereco(Endereco endereco);

        Task Remover(Guid id);
    }
}
