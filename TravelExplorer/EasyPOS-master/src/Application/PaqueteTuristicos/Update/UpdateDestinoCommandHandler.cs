using Application.Common;
using Domain.PaqueteTuristicos;
using Domain.Primitives;
using Domain.ValueObjects;
using Application.PaqueteTuristicos.Update;
using System.Runtime.InteropServices;
using MediatR;
using ErrorOr;

namespace Application.PaqueteTuristicos.Actualizar
{
    internal sealed class UpdatePaqueteTuristicoCommandHandler : IRequestHandler<UpdatePaqueteTuristicoCommand, ErrorOr<Unit>>
    {
        private readonly IPaqueteTuristicoRepository _paqueteTuristicoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaqueteTuristicoCommandHandler(IPaqueteTuristicoRepository paqueteTuristicoRepository, IUnitOfWork unitOfWork)
        {
            _paqueteTuristicoRepository = paqueteTuristicoRepository ?? throw new ArgumentNullException(nameof(paqueteTuristicoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdatePaqueteTuristicoCommand command, CancellationToken cancellationToken)
        {
            if (!await _paqueteTuristicoRepository.ExistsAsync(new PaqueteTuristicoId(command.Id)))
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no se encontró.");
            }

            // var ubicacion = new Ubicacion(
            //     command.Pais,
            //     command.Estado,
            //     command.CodigoPostal
            // );

            var paqueteTuristicoRepository = new PaqueteTuristico(
                new PaqueteTuristicoId(command.Id),
                command.Nombre,
                command.Descripcion,
                command.FechaInicio,
                command.FechaFin,
                command.Precio,
                command.Activo
            );

            _paqueteTuristicoRepository.Update(paqueteTuristicoRepository);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
