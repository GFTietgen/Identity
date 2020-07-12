using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Identity.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome do usuário")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
