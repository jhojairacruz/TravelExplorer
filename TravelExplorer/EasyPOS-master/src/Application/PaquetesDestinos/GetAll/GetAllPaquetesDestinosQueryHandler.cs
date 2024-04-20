using Application.Destinos.GetAll;
using Destinos.Common;
using Domain.Destinos;
using Domain.PaquetesDestinos;
using PaqueteDestinos.Common;

namespace Application.PaqueteDestinos.GetAll
{
    internal sealed class GetAllPaquetesDestinoQueryHandler : IRequestHandler<GetAllPaqueteDestinosQuery, ErrorOr<IReadOnlyList<PaquetesDestinoResponse>>>
    {
        private readonly IPaquetesDestinosRepository _paquetesDestinoRepository;

        public GetAllPaquetesDestinoQueryHandler(IPaquetesDestinosRepository paquetesDestinoRepository)
        {
            _paquetesDestinoRepository = paquetesDestinoRepository ?? throw new ArgumentNullException(nameof(paquetesDestinoRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PaquetesDestinoResponse>>> Handle(GetAllPaqueteDestinosQuery consulta, CancellationToken cancellationToken)
        {
            IReadOnlyList<PaquetesDestinos> paquetesdestinos = await _paquetesDestinoRepository.GetAll();

            var respuestaPaquetesDestinos = paquetesdestinos.Select(paquetesdestinos => new PaquetesDestinoResponse(
                paquetesdestinos.Id.Value,
                paquetesdestinos.PaqueteTuristicoId,
                paquetesdestinos.DestinoId
                
            )).ToList();

            return respuestaPaquetesDestinos;
        }
    }
}
