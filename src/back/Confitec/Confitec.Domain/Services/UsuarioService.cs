using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Repositories;
using Confitec.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Add(Usuario usuario)
        {
            return _usuarioRepository.Add(usuario).Entity;
        }

        public bool Remove(int Id)
        {
            _usuarioRepository.Remove(Id);
            return true;
        }

        public bool Update(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
            return true;
        }      
    }
}
