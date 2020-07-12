using System.ComponentModel.DataAnnotations;

namespace WebApp.Identity.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
