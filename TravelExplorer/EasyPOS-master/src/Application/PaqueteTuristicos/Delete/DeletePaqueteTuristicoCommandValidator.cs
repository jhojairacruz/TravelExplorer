using FluentValidation;

namespace Application.PaqueteTuristicos.Delete;

public class DeletePaqueteTuristicoCommandValidator : AbstractValidator<DeletePaqueteTuristicosCommand>
{
    public DeletePaqueteTuristicoCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}