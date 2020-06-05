using AutoMapper;
using Confitec.Application.Interfaces;
using Confitec.Application.Models;
using Confitec.Data.Interfaces;
using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Repositories;
using Confitec.Domain.Interfaces.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IMapper mapper, IUsuarioService usuarioService, IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _uow = uow;
        }   

        public IEnumerable<UsuarioModel> GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            return _mapper.Map<IEnumerable<UsuarioModel>>(usuarios);
        }

        public UsuarioModel GetById(int Id)
        {
            return _mapper.Map<UsuarioModel>(_usuarioRepository.GetById(Id));
        }

        public UsuarioModel Add(UsuarioModel usuarioModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);

            _uow.BeginTransaction();

            usuario = _usuarioService.Add(usuario);

            _uow.Commit();

            return _mapper.Map<UsuarioModel>(usuario);
        }

        public bool Put(int Id, UsuarioModel usuarioModel)
        {
            _uow.BeginTransaction();

            var usuario = _usuarioRepository.GetById(Id);

            if (usuario != null)
            {
                usuario.Nome = usuarioModel.Nome;
                usuario.Sobrenome = usuarioModel.Sobrenome;
                usuario.EscolaridadeId = Convert.ToInt32(usuarioModel.EscolaridadeId);
                usuario.Email = usuarioModel.Email;
                usuario.DataNascimento = Convert.ToDateTime(usuarioModel.DataNascimento);
            }
            else
            {
                return false;
            }

            if (_usuarioService.Update(usuario))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Patch(int Id, JsonPatchDocument<UsuarioModel> usuarioModel)
        {
            _uow.BeginTransaction();

            var usuario = _usuarioRepository.GetById(Id);
            var model = _mapper.Map<UsuarioModel>(usuario);           
            usuarioModel.ApplyTo(model);

            usuario = _mapper.Map<Usuario>(model);

            if (_usuarioService.Update(usuario))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                return false;
            }           
        }

        public bool Remove(int Id)
        {
            _uow.BeginTransaction();

            if (_usuarioService.Remove(Id))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                return false;
            }      
        }       
    }
}
