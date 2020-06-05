using Confitec.Data.Configs;
using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Confitec.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db"));
            optionsBuilder.UseLazyLoadingProxies();
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new EscolaridadeConfig());
        }
    }
}
