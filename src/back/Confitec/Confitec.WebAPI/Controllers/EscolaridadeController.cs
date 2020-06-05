using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Application.Interfaces;
using Confitec.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeAppService _escolaridadeAppService;

        public EscolaridadeController(IEscolaridadeAppService escolaridadeAppService)
        {
            _escolaridadeAppService = escolaridadeAppService;
        }
      
        [HttpGet]
        public IEnumerable<EscolaridadeModel> Get()
        {
            return _escolaridadeAppService.GetAll();
        }
    }
}
