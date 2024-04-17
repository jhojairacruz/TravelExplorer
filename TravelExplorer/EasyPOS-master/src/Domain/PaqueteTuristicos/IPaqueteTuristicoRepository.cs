namespace Domain.PaqueteTuristicos
{
    public interface IPaqueteTuristicoRepository
    {
        Task<List<PaqueteTuristico>> GetAll();
        Task<PaqueteTuristico?> GetByIdAsync(PaqueteTuristicoId id);
        Task<bool> ExistsAsync(PaqueteTuristicoId id);
        void Add(PaqueteTuristico PaqueteTuristico);
        void Update(PaqueteTuristico PaqueteTuristico);
        void Delete(PaqueteTuristico PaqueteTuristico);
    }
}
