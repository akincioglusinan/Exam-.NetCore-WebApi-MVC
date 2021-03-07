using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinavProje.Entities.Concrete.ClientEntities.Request
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        [MinLength(5, ErrorMessage = "Kullanıcı Adı en az 5 karakter olmalıdır.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "İsim girilmesi zorunludur.")]
        [MinLength(5, ErrorMessage = "Kullanıcı Adı en az 5 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email adresi girilmesi zorunludur.")]
        [EmailAddress(ErrorMessage = "Lütfen bir email adresi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola girilmesi zorunludur.")]
        [MinLength(5, ErrorMessage = "Password en az 5 karakter olmalıdır.")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
