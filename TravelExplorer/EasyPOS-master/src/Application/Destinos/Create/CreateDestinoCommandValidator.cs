namespace Application.Destinos.Create
{
    public class CreateDestinoCommandValidator : AbstractValidator<CreateDestinoCommand>
    {
        public CreateDestinoCommandValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(r => r.Descripcion)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.Pais)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.Estado)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Estado o Departamento");

            RuleFor(r => r.CodigoPostal)
                .NotEmpty()
                .MaximumLength(10)
                .WithName("Código Postal");
        }
    }
}
