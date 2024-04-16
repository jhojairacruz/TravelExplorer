using Domain.Destinos;
using Domain.Primitives;
using Domain.ValueObjects;
using Domain.DomainErrors;

namespace Application.Destinos.Create
{
    public sealed class CreateDestinoCommandHandler : IRequestHandler<CreateDestinoCommand, ErrorOr<Guid>>
    {
        private readonly IDestinoRepository _destinorepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDestinoCommandHandler(IDestinoRepository destinorepository, IUnitOfWork unitOfWork)
        {
            _destinorepository = destinorepository ?? throw new ArgumentNullException(nameof(destinorepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateDestinoCommand command, CancellationToken cancellationToken)
        {
            if (Ubicacion.Create(command.Pais, command.Estado, command.CodigoPostal, true) is not Ubicacion ubicacion)
            {
                return Errors.Destino.UbicacionInvalida;
            }
            var destino =new Destino
            (new DestinoId(Guid.NewGuid()),command.Nombre,
             command.Descripcion,
              ubicacion, true);

            _destinorepository.Add(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return destino.Id.Value;
        }
    }
}
