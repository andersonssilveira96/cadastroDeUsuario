using AutoMapper;
using Confitec.Application.Models;
using Confitec.Domain.Entities;
using System;

namespace Confitec.IoC
{
    public class AutoMapperInjection
    {
        public static MapperConfiguration Config()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));

                cfg.CreateMap<int, string>().ConvertUsing(i => i.ToString());
                cfg.CreateMap<DateTime, string>().ConvertUsing(d => string.Format("{0:s}", d));

                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioModel>();

                cfg.CreateMap<Escolaridade, EscolaridadeModel>();
                cfg.CreateMap<EscolaridadeModel, Escolaridade>();
            });
        }
    }
}
