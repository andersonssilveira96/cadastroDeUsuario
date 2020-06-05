using Confitec.Application.Interfaces;
using Confitec.Application.Services;
using Confitec.Data.Context;
using Confitec.Data.Interfaces;
using Confitec.Data.Repositories;
using Confitec.Data.UoW;
using Confitec.Domain.Interfaces.Repositories;
using Confitec.Domain.Interfaces.Services;
using Confitec.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.IoC
{
    public class Injection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();         
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
            services.AddScoped<IEscolaridadeAppService, EscolaridadeAppService>();
            services.AddScoped<IEscolaridadeAppService, EscolaridadeAppService>();           
        }
    }
}
