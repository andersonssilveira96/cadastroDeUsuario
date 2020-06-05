using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Entities
{
    public class Escolaridade
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
