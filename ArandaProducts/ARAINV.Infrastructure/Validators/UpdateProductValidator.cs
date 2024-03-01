using ARAINV.Infrastructure.Common.Features;
using ARAINV.Infrastructure.DTOs.Products;
using FluentValidation;

namespace ARAINV.Infrastructure.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(pr => pr.Id).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("El id del producto es obligatorio.")
                                .GreaterThan(0).WithMessage("Para la modificación se debe enviar el Id con un valor mayor a 0.");

            RuleFor(pr => pr.Description).Cascade(CascadeMode.Stop)
                                    .Length(2, 255).WithMessage("La descripción debe tener mínimo 2 carácteres y máximo 255.");

            RuleFor(pr => pr.CategoryId).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("La categoria no puede ser nulo.")
                                    .GreaterThan(0).WithMessage("La categoria no puede ser cero.");

            RuleFor(pr => pr.LastModified).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("La fecha de modificación no puede ser nula.")
                                    .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de modificación del producto debe ser menor o igual a la fecha actual.");

            RuleFor(pr => pr.LastModifiedBy).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("El id del usuario modificador es obligatorio.")
                                    .GreaterThan(0).WithMessage("El id de usuario no puede ser cero.");

            RuleFor(pr => pr.Photo).Cascade(CascadeMode.Stop)
                                .Must(p => RegexExtensions.VerifyValue(p, @"^data:image\/(?:gif|png|jpeg|jpg|bmp|webp|svg\+xml)(?:;charset=utf-8)?;base64,(?:[A-Za-z0-9]|[+/])+={0,2}$")).WithMessage("El formato de la imagen cargada es invalido.");

        }
    }
}
