using ARAINV.Infrastructure.Common.Features;
using ARAINV.Infrastructure.DTOs.Users;
using FluentValidation;

namespace ARAINV.Infrastructure.Validators
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateUserDTO>
    {
        public AuthenticateValidator()
        {
            RuleFor(pr => pr.EmailUser).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("El email no puede estar vacio.")
                                .Length(2, 100).WithMessage("El email debe tener mínimo 2 carácteres y máximo 100.")
                                .Must(p => RegexExtensions.VerifyValue(p, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")).WithMessage("El formato del Email no es correcto.");

            RuleFor(pr => pr.Password).Cascade(CascadeMode.Stop)
                                .Length(2, 300).WithMessage("La contraseña debe tener mínimo 2 carácteres y máximo 255.")
                                .Must(p => RegexExtensions.VerifyValue(p, @"^[-A-Za-z0-9+/=]|=[^=]|={3,}$")).WithMessage("La contraseña debe estar encriptada en base64.");
        }
    }
}
