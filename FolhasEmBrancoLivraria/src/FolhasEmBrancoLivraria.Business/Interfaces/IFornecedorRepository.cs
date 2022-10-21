using FolhasEmBrancoLivraria.Business.Models;
using System;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid fornecedorId);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid fornecedorId);
    }
}
