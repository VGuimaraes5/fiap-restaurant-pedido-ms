using AutoMapper;
using Application.Models.CategoriaModel;
using Application.Models.ProdutoModel;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;
using Application.Models.PedidoModel;
using Domain.Models;
using Application.Models.ValueObject;

namespace Application.Mappers
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoriaResponse, Categoria>().ReverseMap();

            CreateMap<ProdutoResponse, Produto>().ReverseMap();
            CreateMap<ProdutoPostRequest, Produto>().ReverseMap();
            CreateMap<ProdutoPutRequest, Produto>().ReverseMap();

            CreateMap<PedidoSendRequest, PedidoModel>().ReverseMap();
            CreateMap<ProdutoVO, PedidoProdutoModel>().ReverseMap();
        }
    }
}
