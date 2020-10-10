using System.ComponentModel.DataAnnotations;

namespace WebAPI.Identity.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }

        public string NomeCompleto { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
