using Destinos.Common;
using Domain.Destinos;

namespace Application.Destinos.GetAll
{
    internal sealed class GetAllDestinoQueryHandler : IRequestHandler<GetAllDestinosQuery, ErrorOr<IReadOnlyList<DestinoResponse>>>
    {
        private readonly IDestinoRepository _destinoRepository;

        public GetAllDestinoQueryHandler(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<DestinoResponse>>> Handle(GetAllDestinosQuery consulta, CancellationToken cancellationToken)
        {
            IReadOnlyList<Destino> destinos = await _destinoRepository.GetAll();

            var respuestaDestinos = destinos.Select(destino => new DestinoResponse(
                destino.Id.Value,
                destino.Nombre,
                destino.Descripcion,
                new UbicacionResponse(
                    destino.Ubicacion.Pais,
                    destino.Ubicacion.Estado,
                    destino.Ubicacion.CodigoPostal
                ),
                destino.Activo
            )).ToList();

            return respuestaDestinos;
        }
    }
}
