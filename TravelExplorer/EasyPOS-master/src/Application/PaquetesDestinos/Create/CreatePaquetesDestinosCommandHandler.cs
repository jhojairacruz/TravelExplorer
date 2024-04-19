using Domain.PaquetesDestinos;
using Domain.Primitives;
using Domain.ValueObjects;
//using Domain.DomainErrors;
using ErrorOr;
using MediatR;

namespace Application.PaqueteDestinos.Create
{
    public sealed class CreatePaquetesDestinosCommandHandler : IRequestHandler<CreatePaquetesDestinosCommand, ErrorOr<Guid>>
    {
        private readonly IPaquetesDestinosRepository _paquetesDestinosrepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaquetesDestinosCommandHandler(IPaquetesDestinosRepository paquetesDestinosrepository, IUnitOfWork unitOfWork)
        {
            _paquetesDestinosrepository = paquetesDestinosrepository ?? throw new ArgumentNullException(nameof(paquetesDestinosrepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreatePaquetesDestinosCommand command, CancellationToken cancellationToken)
        {
            // if (Ubicacion.Create(command.Pais, command.Estado, command.CodigoPostal, true) is not Ubicacion ubicacion)
            // {
            //     return Errors.Destino.UbicacionInvalida;
            // }
            var paquetesDestinos = new PaquetesDestinos
            (new PaquetesDestinosId(Guid.NewGuid()),command.PaqueteTuristicoId,
             command.DestinoId);

            _paquetesDestinosrepository.Add(paquetesDestinos);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return paquetesDestinos.Id.Value;
        }
    }
}
