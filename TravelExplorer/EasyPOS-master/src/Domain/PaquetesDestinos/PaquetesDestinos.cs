using Domain.Primitives;

namespace Domain.PaquetesDestinos;

public sealed class PaquetesDestinos : AggregateRoot
{
    
    public PaquetesDestinos(PaquetesDestinosId id, string paqueteTuristicoId, string destinoId)
    {
        Id = id;
        PaqueteTuristicoId = paqueteTuristicoId;
        DestinoId = destinoId;
    }

    private PaquetesDestinos()
    {

    }

    
    public PaquetesDestinosId Id { get; private set; }
    public string PaqueteTuristicoId { get; private set; } = string.Empty;
    public string DestinoId { get; set; } = string.Empty;

    public static PaquetesDestinos UpdateCliente(Guid id, string paqueteTuristicoId, string destinoId)
    {
        return new PaquetesDestinos(new PaquetesDestinosId(id), paqueteTuristicoId, destinoId);
    }
}