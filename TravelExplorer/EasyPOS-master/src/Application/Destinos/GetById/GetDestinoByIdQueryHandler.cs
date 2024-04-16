using Application.Common;
using Application.Destinos.GetById;
using Destinos.Common;
using Domain.Destinos;
using Domain.ValueObjects;

namespace Application.Destinos.GetById
{
    internal sealed class GetDestinoByIdQueryHandler : IRequestHandler<GetDestinoByIdQuery, ErrorOr<DestinoResponse>>
    {
        private readonly IDestinoRepository _destinoRepository;

        public GetDestinoByIdQueryHandler(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
        }

        public async Task<ErrorOr<DestinoResponse>> Handle(GetDestinoByIdQuery consulta, CancellationToken cancellationToken)
        {
            var destino = await _destinoRepository.GetByIdAsync(new DestinoId(consulta.Id));

            if (destino == null)
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no se encontró.");
            }

            var respuestaDireccion = new UbicacionResponse(
                destino.Ubicacion.Pais,
                destino.Ubicacion.Estado,
                destino.Ubicacion.CodigoPostal
            );

            var destinoResponse = new DestinoResponse(
                destino.Id.Value,
                destino.Nombre,
                destino.Descripcion,
                respuestaDireccion,
                destino.Activo
            );

            return destinoResponse;
        }
    }
}
