using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Authentication;
public class LoginViewModel
{
    [Required(ErrorMessage ="شماره تلفن اجباری است")]
    [MaxLength(11,ErrorMessage =ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "رمز عبور اجباری است")]
    public string Password { get; set; }
}


