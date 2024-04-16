using Application.Common;
using Domain.Destinos;
using Domain.Primitives;
using Domain.ValueObjects;
using Application.Destinos.Update;
using System.Runtime.InteropServices;

namespace Application.Destinos.Actualizar
{
    internal sealed class UpdateDestinoCommandHandler : IRequestHandler<UpdateDestinoCommand, ErrorOr<Unit>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDestinoCommandHandler(IDestinoRepository destinoRepository, IUnitOfWork unitOfWork)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateDestinoCommand command, CancellationToken cancellationToken)
        {
            if (!await _destinoRepository.ExistsAsync(new DestinoId(command.Id)))
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no se encontró.");
            }

            var ubicacion = new Ubicacion(
                command.Pais,
                command.Estado,
                command.CodigoPostal
            );

            var destino = new Destino(
                new DestinoId(command.Id),
                command.Nombre,
                command.Descripcion,
                ubicacion,
                command.Activo
            );

            _destinoRepository.Update(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
