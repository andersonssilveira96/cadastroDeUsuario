using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Configs
{
    public class EscolaridadeConfig : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(u => u.Usuarios).WithOne(u => u.Escolaridade).HasForeignKey(u => u.EscolaridadeId).IsRequired();

            builder.HasData(new Escolaridade() { Id = 1, Descricao = "Infantil" });
            builder.HasData(new Escolaridade() { Id = 2, Descricao = "Fundamental" });
            builder.HasData(new Escolaridade() { Id = 3, Descricao = "Médio" });
            builder.HasData(new Escolaridade() { Id = 4, Descricao = "Superior" });
        }
    }
}
