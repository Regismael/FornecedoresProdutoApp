

using FornecedoresProdutoApp.DOMAIN.Interfaces.Repositories;
using FornecedoresProdutoApp.DOMAIN.Interfaces.Services;
using FornecedoresProdutoApp.DOMAIN.Services;
using FornecedoresProdutoApp.Infra.DATA.Repositories;

namespace UsuariosApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para mapear as injeções de dependência do projeto
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            #region Adicionando as injeções de dependência do projeto

            services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            services.AddTransient<IFornecedorDomainService, FornecedorDomainService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();

            #endregion
        }
    }
}
