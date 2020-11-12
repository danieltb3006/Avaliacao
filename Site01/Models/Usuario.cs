using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "O campo 'E-mail' deve ser obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo 'Senha' deve ser obrigatório!")]
        public string Senha { get; set; }
    }
}
