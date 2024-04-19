using Application.PaqueteTuristicos.Delete;
using Domain.PaqueteTuristicos;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.PaqueteTuristicos.Eliminar
{
    internal sealed class DeletePaqueteTuristicoCommandHandler : IRequestHandler<DeletePaqueteTuristicosCommand, ErrorOr<Unit>>
    {
        private readonly IPaqueteTuristicoRepository _paqueteturisticoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePaqueteTuristicoCommandHandler(IPaqueteTuristicoRepository paqueteturisticoRepository, IUnitOfWork unitOfWork)
        {
            _paqueteturisticoRepository = paqueteturisticoRepository ?? throw new ArgumentNullException(nameof(paqueteturisticoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeletePaqueteTuristicosCommand comando, CancellationToken cancellationToken)
        {
            if (await _paqueteturisticoRepository.GetByIdAsync(new PaqueteTuristicoId(comando.Id)) is not PaqueteTuristico paqueteTuristico)
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no fue encontrado.");
            }

            _paqueteturisticoRepository.Delete(paqueteTuristico);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
