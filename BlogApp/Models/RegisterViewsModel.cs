using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
	public class RegisterViewsModel
	{
		[Required]
		[Display(Name = "Kullanıcı Adı")]
		public string? UserName { get; set; }
		[Required]
		[Display(Name = "Ad Soyad")]
		public string? Name { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "E-Posta")]
		public string? Email { get; set; }

		[Required]
		[StringLength(10, ErrorMessage = "{0} alanı en az {2} karakterden uzunluğunda olmalıdır.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Şifreniz")]
		public string? Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage = "Şifreler aynı değil")]
		[Display(Name = "Şifre  Tekrar")]
		public string? ConfirmPassword { get; set; }
	}
}
