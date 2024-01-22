using Microsoft.Extensions.DependencyInjection;
using Application.Models.CategoriaModel;
using Application.Models.ProdutoModel;
using Application.UseCases;
using Application.UseCases.CategoriaUseCase;
using Application.UseCases.ProdutoUseCase;
using Domain.Gateways;
using Infrastructure.DataProviders;
using Infrastructure.DataProviders.Repositories;

namespace Infrastructure.Extensions
{
    public static class RegisterServiceExtensions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            AddUseCase(services);
            AddRepositories(services);
            AddOthers(services);
        }
        private static void AddUseCase(IServiceCollection services)
        {
            services.AddTransient<IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>>, GetAllCategoriaUseCaseAsync>();
            services.AddTransient<IUseCaseIEnumerableAsync<IEnumerable<ProdutoResponse>>, GetAllProdutoUseCaseAsync>();
            services.AddTransient<IUseCaseIEnumerableAsync<ProdutoRequest, IEnumerable<ProdutoResponse>>, GetProdutoByCategoriaIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<ProdutoPostRequest>, PostProdutoUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<ProdutoPutRequest>, PutProdutoUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<ProdutoDeleteRequest>, DeleteProdutoUseCaseAsync>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICategoriaGateway, CategoriaRepository>();
            services.AddTransient<IProdutoGateway, ProdutoRepository>();
        }

        private static void AddOthers(IServiceCollection services)
        {
            services.AddTransient<DBContext>();
        }
    }
}
