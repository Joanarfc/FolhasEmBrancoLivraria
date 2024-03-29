﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FolhasEmBrancoLivraria.App.ViewModels;
using FolhasEmBrancoLivraria.Business.Interfaces;
using AutoMapper;
using FolhasEmBrancoLivraria.Business.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FolhasEmBrancoLivraria.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;

        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        [Route("detalhes-de-produtos/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            var imgPrefix = Guid.NewGuid() + "_";

            if (!await UploadFicheiro(produtoViewModel.ImagemUpload, imgPrefix))
            {
                return View(produtoViewModel);
            }

            produtoViewModel.Imagem = imgPrefix + produtoViewModel.ImagemUpload.FileName;

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();
            
            var atualizacaoProduto = await ObterProduto(id);

            produtoViewModel.Fornecedor = atualizacaoProduto.Fornecedor;

            produtoViewModel.Imagem = atualizacaoProduto.Imagem;

            if (!ModelState.IsValid) return View(produtoViewModel);

            if(produtoViewModel.ImagemUpload != null)
            {
                var imgPrefix = Guid.NewGuid() + "_";

                if (!await UploadFicheiro(produtoViewModel.ImagemUpload, imgPrefix))
                {
                    return View(produtoViewModel);
                }
                atualizacaoProduto.Imagem = imgPrefix + produtoViewModel.ImagemUpload.FileName;
            }

            atualizacaoProduto.Nome = produtoViewModel.Nome;
            atualizacaoProduto.Autor = produtoViewModel.Autor;
            atualizacaoProduto.Descricao = produtoViewModel.Descricao;
            atualizacaoProduto.Valor = produtoViewModel.Valor;
            atualizacaoProduto.Ano = produtoViewModel.Ano;
            atualizacaoProduto.IsAtivo = produtoViewModel.IsAtivo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(atualizacaoProduto));

            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction("Index");
        }

        [Route("eliminar-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("eliminar-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null) return NotFound();
            
            await _produtoService.Remover(id);

            if (!OperacaoValida()) return View(produtoViewModel);
            TempData["Sucesso"] = "Produto excluído com sucesso";

            return RedirectToAction("Index");
        }

        public async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        public async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produtoViewModel;
        }

        private async Task<bool> UploadFicheiro(IFormFile file, string imgPrefix)
        {
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/livros", imgPrefix + file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Um ficheiro com o mesmo nome já existe!");
                return false;
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;

        }
    }
}
