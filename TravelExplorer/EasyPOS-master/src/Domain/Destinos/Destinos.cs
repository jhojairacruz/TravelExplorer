using Domain.Primitives;

namespace Domain.Destinos
{
    public sealed class Destino : AggregateRoot
    {
        public Destino(DestinoId id, string nombre, string descripcion, Ubicacion ubicacion, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            Activo = activo;
        }

        private Destino()
        {

        }

        public DestinoId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public Ubicacion Ubicacion { get; private set; }
        public bool Activo { get; private set; }

        public static Destino Create(string nombre, string descripcion, Ubicacion ubicacion, bool activo)
        {
            var id = new DestinoId(Guid.NewGuid());
            return new Destino(id, nombre, descripcion, ubicacion, activo);
        }

        public void Update(string nombre, string descripcion, Ubicacion ubicacion, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            Activo = activo;
        }
    }
}
