using PaqueteTuristicos.Common;
using Domain.PaqueteTuristicos;
using MediatR;
using ErrorOr;

namespace Application.PaqueteTuristicos.GetAll
{
    internal sealed class GetAllPaqueteTuristicoQueryHandler : IRequestHandler<GetAllPaqueteTuristicosQuery, ErrorOr<IReadOnlyList<PaqueteTuristicoResponse>>>
    {
        private readonly IPaqueteTuristicoRepository _paqueteTuristicoRepository;

        public GetAllPaqueteTuristicoQueryHandler(IPaqueteTuristicoRepository paqueteTuristicoRepository)
        {
            _paqueteTuristicoRepository = paqueteTuristicoRepository ?? throw new ArgumentNullException(nameof(paqueteTuristicoRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PaqueteTuristicoResponse>>> Handle(GetAllPaqueteTuristicosQuery consulta, CancellationToken cancellationToken)
        {
            IReadOnlyList<PaqueteTuristico> paqueteTuristico = await _paqueteTuristicoRepository.GetAll();

            var respuestaPaqueteTuristico = paqueteTuristico.Select(paqueteTuristico => new PaqueteTuristicoResponse(
                paqueteTuristico.Id.Value,
                paqueteTuristico.Nombre,
                paqueteTuristico.Descripcion,
                paqueteTuristico.FechaInicio,
                paqueteTuristico.FechaFin,
                paqueteTuristico.Precio,
                paqueteTuristico.Activo
            )).ToList();

            return respuestaPaqueteTuristico;
        }
    }
}
