namespace Domain.PaquetesDestinos;

public interface IPaquetesDestinosRepository
{
    Task<List<PaquetesDestinos>> GetAll();
    Task<PaquetesDestinos?> GetByIdAsync(PaquetesDestinosId id);
    Task<bool> ExistsAsync(PaquetesDestinosId id);
    void Add(PaquetesDestinos paquetesDestinos);
    void Update(PaquetesDestinos paquetesDestinos);
    void Delete(PaquetesDestinos paquetesDestinos);
}