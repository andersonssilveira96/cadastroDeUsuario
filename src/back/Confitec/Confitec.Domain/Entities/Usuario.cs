using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Confitec.Domain.Entities
{
    public class Usuario
    {
     
        public int Id { get; set; }
       
        public string Nome { get; set; }
       
        public string Sobrenome { get; set; }
       
        public string Email { get; set; }             

        public DateTime DataNascimento { get; set; }       

        public int EscolaridadeId { get; set; }
       
        public virtual Escolaridade Escolaridade { get; set; }

    }
}
