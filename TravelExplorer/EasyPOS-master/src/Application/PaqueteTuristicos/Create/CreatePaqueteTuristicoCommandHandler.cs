using Domain.PaqueteTuristicos;
using Domain.Primitives;
using Domain.ValueObjects;
//using Domain.DomainErrors;
using ErrorOr;
using MediatR;

namespace Application.PaqueteTuristicos.Create
{
    public sealed class CreatePaqueteTuristicoCommandHandler : IRequestHandler<CreatePaqueteTuristicoCommand, ErrorOr<Guid>>
    {
        private readonly IPaqueteTuristicoRepository _paqueteturisticorepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaqueteTuristicoCommandHandler(IPaqueteTuristicoRepository paqueteturisticorepository, IUnitOfWork unitOfWork)
        {
            _paqueteturisticorepository = paqueteturisticorepository ?? throw new ArgumentNullException(nameof(paqueteturisticorepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreatePaqueteTuristicoCommand command, CancellationToken cancellationToken)
        {
            // if (Ubicacion.Create(command.Pais, command.Estado, command.CodigoPostal, true) is not Ubicacion ubicacion)
            // {
            //     return Errors.Destino.UbicacionInvalida;
            // }
            var paqueteTuristico = new PaqueteTuristico
            (new PaqueteTuristicoId(Guid.NewGuid()),command.Nombre,
             command.Descripcion,command.FechaInicio, command.FechaFin, command.Precio, true);

            _paqueteturisticorepository.Add(paqueteTuristico);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return paqueteTuristico.Id.Value;
        }
    }
}
