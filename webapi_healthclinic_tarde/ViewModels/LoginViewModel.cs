using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codefirst.ViewModels
    {
    //Classe responsável pelo modelo de login
    public class LoginViewModel
        {
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string? Senha { get; set; }
        }
    }