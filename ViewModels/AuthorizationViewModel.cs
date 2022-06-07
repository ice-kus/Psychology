using System.ComponentModel.DataAnnotations;

namespace Psychology.ViewModels
{
    public class AuthorizationViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string TypeUser { get; set; }
    }
}
