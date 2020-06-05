using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Confitec.Application.Models;
using Confitec.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;


namespace Confitec.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Injeção de dependencia do Automapper
            var config = AutoMapperInjection.Config();        
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Injeção de dependencia do projeto em geral.
            Injection.Inject(services);

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Cadastro de Usuários",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core para teste na Confitec",
                       
                    });

                string caminhoAplicacao =
                    AppDomain.CurrentDomain.BaseDirectory;
                string nomeAplicacao =
                    AppDomain.CurrentDomain.FriendlyName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(option => {
                    option.AllowAnyOrigin();
                    option.AllowAnyMethod();
                    option.AllowAnyHeader();                  
                });

                // Ativando middlewares para uso do Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Cadastro de Usuários");
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
