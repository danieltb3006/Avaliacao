using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

//Regras de negócio, validação dos dados e dados
namespace Site01.Models
{
    public class Contato
    {
        [Required(ErrorMessage ="O campo 'Nome' deve ser obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo 'Nome' deve ser ter, no máximo, 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' deve ser obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo 'E-mail' deve ser ter, no máximo, 70 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Assunto' deve ser obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo 'Assunto' deve ser ter, no máximo, 70 caracteres")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo 'Mensagem' deve ser obrigatório!")]
        [MaxLength(2000, ErrorMessage = "O campo 'Mensagem' deve ser ter, no máximo, 2000 caracteres")]
        public string Mensagem { get; set; }
    }
}
