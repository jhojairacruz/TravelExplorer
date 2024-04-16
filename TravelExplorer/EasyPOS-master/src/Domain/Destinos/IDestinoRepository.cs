namespace Domain.Destinos
{
    public interface IDestinoRepository
    {
        Task<List<Destino>> GetAll();
        Task<Destino?> GetByIdAsync(DestinoId id);
        Task<bool> ExistsAsync(DestinoId id);
        void Add(Destino destino);
        void Update(Destino destino);
        void Delete(Destino destino);
    }
}
