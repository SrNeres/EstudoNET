using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Usuario
    {


        public string usuarioId { get; set; }

        [Display(Name = "Login: ")]
        [Required]
        public string login { get; set; }

        [Display(Name = "Senha: ")]
        [Required]
        public string senha { get; set; }

        [Display(Name = "E-Mail: ")]
        public string email { get; set; }
        [Display(Name = "Telefone: ")]
        public string telefone { get; set; }

    }
}
