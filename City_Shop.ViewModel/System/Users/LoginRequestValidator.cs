using FluentValidation;

namespace City_Shop.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required !");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required !")
                .MinimumLength(6).WithMessage("Oh No! Password is at least 6 characters.");
        }
    }
}