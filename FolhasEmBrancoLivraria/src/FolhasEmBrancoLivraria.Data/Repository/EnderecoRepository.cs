using FolhasEmBrancoLivraria.Business.Interfaces;
using FolhasEmBrancoLivraria.Business.Models;
using FolhasEmBrancoLivraria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataDbContext context) : base(context) { }
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
