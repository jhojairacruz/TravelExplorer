namespace Application.Clientes.Update;

public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Apellido)
             .NotEmpty()
             .MaximumLength(50)
             .WithName("Last Name");

        RuleFor(r => r.Email)
             .NotEmpty()
             .EmailAddress()
             .MaximumLength(255);

        RuleFor(r => r.Telefono)
             .NotEmpty()
             .MaximumLength(9)
             .WithName("Telefono");

        RuleFor(r => r.Calle)
            .NotEmpty()
            .MaximumLength(150)
            .WithName("Calle");

        RuleFor(r => r.Colonia)
            .MaximumLength(220)
            .WithName("Colonia");

        RuleFor(r => r.Municipio)
            .NotEmpty()
            .MaximumLength(40)
            .WithName("Municipio");

        RuleFor(r => r.Departamento)
            .NotEmpty()
            .MaximumLength(40)
            .WithName("Departamento");
    }
}
