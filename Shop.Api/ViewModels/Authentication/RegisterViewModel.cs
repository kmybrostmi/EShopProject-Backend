using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Authentication;

public class RegisterViewModel
{
    [Required(ErrorMessage = "شماره تلفن اجباری است")]
    [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "کلمه عبور اجباری است")]
    [MinLength(6, ErrorMessage = "کلمه عبور باید ببیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }
    [Required(ErrorMessage = "تکرار کلمه عبور اجباری است")]
    [MinLength(6, ErrorMessage = "کلمه عبور باید ببیشتر از 5 کاراکتر باشد")]
    [Compare(nameof(Password),ErrorMessage ="کلمه عبور های وارد شده یکسان نیستند")]
    public string ConfirmPassword { get; set; }
}


