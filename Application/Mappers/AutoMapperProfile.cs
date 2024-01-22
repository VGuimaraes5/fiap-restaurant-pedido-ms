using AutoMapper;
using Application.Models.CategoriaModel;
using Application.Models.ProdutoModel;
using Domain.Entities;

namespace Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoriaResponse, Categoria>().ReverseMap();

            CreateMap<ProdutoResponse, Produto>().ReverseMap();
            CreateMap<ProdutoPostRequest, Produto>().ReverseMap();
            CreateMap<ProdutoPutRequest, Produto>().ReverseMap();
        }
    }
}
