using ARAINV.Infrastructure.DTOs.Products;
using FluentValidation;

namespace ARAINV.Infrastructure.Validators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDTO>
    {
        public DeleteProductValidator()
        {
            RuleFor(pr => pr.Id).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("El id del producto es obligatorio.")
                                .GreaterThan(0).WithMessage("Para la eliminacion se debe enviar el Id con un valor mayor a 0.");

            RuleFor(pr => pr.LastModified).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("La fecha de eliminación no puede ser nula.")
                                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de eliminación del producto debe ser menor o igual a la fecha actual.");

            RuleFor(pr => pr.LastModifiedBy).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("El id del usuario eliminador es obligatorio.")
                                .GreaterThan(0).WithMessage("El id de usuario no puede ser cero.");

        }
    }
}
