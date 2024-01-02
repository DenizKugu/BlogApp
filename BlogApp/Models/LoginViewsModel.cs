using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
	public class LoginViewsModel
	{
		[Required]
		[EmailAddress]
		[Display(Name ="E-Posta")]
		public string? Email { get; set; }

		[Required]
		[StringLength(10,ErrorMessage ="En Fazla 10 Karakter girebilirsin",MinimumLength =6)]
		[DataType(DataType.Password)]
		[Display(Name ="Şifreniz")]
        public string? Password { get; set; }
    }
}
