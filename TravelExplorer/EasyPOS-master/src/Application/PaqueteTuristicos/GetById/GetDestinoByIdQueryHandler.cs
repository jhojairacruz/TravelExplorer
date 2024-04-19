using Application.Common;
using Application.PaqueteTuristicos.GetById;
using PaqueteTuristicos.Common;
using Domain.PaqueteTuristicos;
using Domain.ValueObjects;
using MediatR;
using ErrorOr;

namespace Application.PaqueteTuristicos.GetById
{
    internal sealed class GetPaqueteTuristicoByIdQueryHandler : IRequestHandler<GetPaqueteTuristicoByIdQuery, ErrorOr<PaqueteTuristicoResponse>>
    {
        private readonly IPaqueteTuristicoRepository _paqueteTuristicoRepository;

        public GetPaqueteTuristicoByIdQueryHandler(IPaqueteTuristicoRepository paqueteTuristicoRepository)
        {
            _paqueteTuristicoRepository = paqueteTuristicoRepository ?? throw new ArgumentNullException(nameof(paqueteTuristicoRepository));
        }

        public async Task<ErrorOr<PaqueteTuristicoResponse>> Handle(GetPaqueteTuristicoByIdQuery consulta, CancellationToken cancellationToken)
        {
            var paqueteTuristico = await _paqueteTuristicoRepository.GetByIdAsync(new PaqueteTuristicoId(consulta.Id));

            if (paqueteTuristico == null)
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no se encontró.");
            }

            // var respuestaDireccion = new UbicacionResponse(
            //     destino.Ubicacion.Pais,
            //     destino.Ubicacion.Estado,
            //     destino.Ubicacion.CodigoPostal
            // );

            var paqueteTuristicoResponse = new PaqueteTuristicoResponse(
                paqueteTuristico.Id.Value,
                paqueteTuristico.Nombre,
                paqueteTuristico.Descripcion,
                paqueteTuristico.FechaInicio,
                paqueteTuristico.FechaFin,
                paqueteTuristico.Precio,
                paqueteTuristico.Activo
            );

            return paqueteTuristicoResponse;
        }
    }
}
