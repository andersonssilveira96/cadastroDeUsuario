using Confitec.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Interfaces
{
    public interface IEscolaridadeAppService
    {
        IEnumerable<EscolaridadeModel> GetAll();
    }
}
