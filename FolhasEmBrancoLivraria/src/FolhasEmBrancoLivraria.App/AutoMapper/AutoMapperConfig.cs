using AutoMapper;
using FolhasEmBrancoLivraria.App.ViewModels;
using FolhasEmBrancoLivraria.Business.Models;

namespace FolhasEmBrancoLivraria.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
