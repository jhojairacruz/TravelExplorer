namespace Application.Clientes.Delete;

public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}