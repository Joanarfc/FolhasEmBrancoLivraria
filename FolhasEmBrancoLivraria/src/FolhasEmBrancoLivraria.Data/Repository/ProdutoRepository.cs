﻿using FolhasEmBrancoLivraria.Business.Interfaces;
using FolhasEmBrancoLivraria.Business.Models;
using FolhasEmBrancoLivraria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataDbContext context) : base(context) { }
        public async Task<Produto> ObterProdutoFornecedor(Guid produtoId)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == produtoId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
