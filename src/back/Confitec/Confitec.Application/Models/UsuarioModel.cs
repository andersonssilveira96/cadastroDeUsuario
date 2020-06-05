using Confitec.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Confitec.Application.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome inválido, mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "Nome inválido, máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [MinLength(2, ErrorMessage = "Sobrenome inválido, mínimo 2 caracteres")]
        [MaxLength(80, ErrorMessage = "Sobrenome inválido, máximo 80 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        [DateValidation(ErrorMessage = "Data inválida, por favor informe uma data menor do que a atual")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Escolaridade é obrigatório")]        
        public string EscolaridadeId { get; set; }
        
        public EscolaridadeModel Escolaridade { get; set; }

    }
}
