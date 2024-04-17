using FluentValidation;

namespace Application.PaqueteTuristicos.Create
{
    public class CreatePaqueteTuristicCommandValidator : AbstractValidator<CreatePaqueteTuristicoCommand>
    {
        public CreatePaqueteTuristicCommandValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(r => r.Descripcion)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.FechaInicio)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.FechaFin)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Estado o Departamento");

            RuleFor(r => r.Precio)
                .NotEmpty().WithMessage("El precio es requerido")
                .Must(precio => precio >= 0).WithMessage("El precio debe ser mayor o igual a cero")
                .WithName("Precio");
        }
    }

}