using Confitec.Application.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        IEnumerable<UsuarioModel> GetAll();
        UsuarioModel GetById(int Id);
        UsuarioModel Add(UsuarioModel usuarioModel);
        bool Patch(int Id, JsonPatchDocument<UsuarioModel> usuarioModel);
        bool Put(int Id, UsuarioModel usuarioModel);
        bool Remove(int Id);
    }
}
