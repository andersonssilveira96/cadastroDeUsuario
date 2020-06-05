using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Nome).HasMaxLength(80);
            builder.Property(u => u.Sobrenome).HasMaxLength(80);
                 
            builder.HasData(new Usuario() { Id = 1, Nome = "Usuario 1", DataNascimento = DateTime.Now, Email = "usuario1@teste.com.br", Sobrenome = "De Souza", EscolaridadeId = 1 });
            builder.HasData(new Usuario() { Id = 2, Nome = "Usuario 2", DataNascimento = DateTime.Now, Email = "usuario2@teste.com.br", Sobrenome = "De Souza", EscolaridadeId = 2 });
            builder.HasData(new Usuario() { Id = 3, Nome = "Usuario 3", DataNascimento = DateTime.Now, Email = "usuario3@teste.com.br", Sobrenome = "De Souza", EscolaridadeId = 3 });
            builder.HasData(new Usuario() { Id = 4, Nome = "Usuario 4", DataNascimento = DateTime.Now, Email = "usuario4@teste.com.br", Sobrenome = "De Souza", EscolaridadeId = 4 });
        }
    }
}
