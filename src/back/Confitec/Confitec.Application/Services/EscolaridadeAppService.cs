using AutoMapper;
using Confitec.Application.Interfaces;
using Confitec.Application.Models;
using Confitec.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Services
{
    public class EscolaridadeAppService : IEscolaridadeAppService
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;
        private readonly IMapper _mapper;

        public EscolaridadeAppService(IMapper mapper, IEscolaridadeRepository escolaridadeRepository)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EscolaridadeModel> GetAll()
        {
            var retorno = _escolaridadeRepository.GetAll();
            return _mapper.Map<IEnumerable<EscolaridadeModel>>(retorno);
        }
    }
}
