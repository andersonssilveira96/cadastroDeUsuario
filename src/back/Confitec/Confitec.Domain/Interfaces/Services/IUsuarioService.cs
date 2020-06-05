using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Add(Usuario usuario);

        bool Update(Usuario usuario);
       
        bool Remove(int Id);
    }
}
