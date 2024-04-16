namespace Application.Destinos.Delete;

public class DeleteDestinoCommandValidator : AbstractValidator<DeleteDestinosCommand>
{
    public DeleteDestinoCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}