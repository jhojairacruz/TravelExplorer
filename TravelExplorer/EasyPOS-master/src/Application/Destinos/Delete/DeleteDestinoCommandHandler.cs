using Application.Destinos.Delete;
using Domain.Destinos;
using Domain.Primitives;

namespace Application.Destinos.Eliminar
{
    internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteDestinosCommand, ErrorOr<Unit>>
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IDestinoRepository destinoRepository, IUnitOfWork unitOfWork)
        {
            _destinoRepository = destinoRepository ?? throw new ArgumentNullException(nameof(destinoRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteDestinosCommand comando, CancellationToken cancellationToken)
        {
            if (await _destinoRepository.GetByIdAsync(new DestinoId(comando.Id)) is not Destino destino)
            {
                return Error.NotFound("Destino.NoEncontrado", "El destino con el ID proporcionado no fue encontrado.");
            }

            _destinoRepository.Delete(destino);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
