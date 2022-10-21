using FolhasEmBrancoLivraria.Business.Interfaces;
using FolhasEmBrancoLivraria.Business.Models;
using FolhasEmBrancoLivraria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DataDbContext context) : base(context) { }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid fornecedorId)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid fornecedorId)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }
    }
}
