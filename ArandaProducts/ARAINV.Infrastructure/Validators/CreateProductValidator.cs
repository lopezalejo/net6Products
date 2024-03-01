using ARAINV.Infrastructure.Common.Features;
using ARAINV.Infrastructure.DTOs.Products;
using FluentValidation;

namespace ARAINV.Infrastructure.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(pr => pr.NameProduct).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("El nombre del producto no puede estar vacio.")
                                .Length(2, 200).WithMessage("La descripción debe tener mínimo 2 carácteres y máximo 200.")
                                .Matches(@"^[\w\s]+$").WithMessage("Se han usado carácteres invalidos en la definición del nombre del producto.");

            RuleFor(pr => pr.Description).Cascade(CascadeMode.Stop)
                                .Length(2, 255).WithMessage("La descripción debe tener mínimo 2 carácteres y máximo 255.")
                                .Must(p => RegexExtensions.VerifyValue(p, @"^[\w\s]+$")).WithMessage("Se han usado carateres invalidos en el nombre del producto.");

            RuleFor(pr => pr.CategoryId).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("La categoria no puede ser nulo.")
                                .GreaterThan(0).WithMessage("La categoria no puede ser cero.");

            RuleFor(pr => pr.Created).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("La fecha de creación no puede ser nula.")
                                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de creación del producto debe ser menor o igual a la fecha actual.");

            RuleFor(pr => pr.Photo).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("La foto del producto es obligatoria.")
                                .NotEmpty().WithMessage("La foto del producto es obligatoria.")
                                .Must(p => RegexExtensions.VerifyValue(p, @"^data:image\/(?:gif|png|jpeg|jpg|bmp|webp|svg\+xml)(?:;charset=utf-8)?;base64,(?:[A-Za-z0-9]|[+/])+={0,2}$")).WithMessage("El formato de la imagen cargada es invalido.");
        }
    }
}
