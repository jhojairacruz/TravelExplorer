using Domain.Primitives;

namespace Domain.PaqueteTuristicos
{
    public sealed class PaqueteTuristico : AggregateRoot
    {
        public PaqueteTuristico(PaqueteTuristicoId id, string nombre, string descripcion, string fechaInicio, string fechaFin, decimal precio, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Precio = precio;
            Activo = activo;
        }

        private PaqueteTuristico()
        {

        }

        public PaqueteTuristicoId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string FechaInicio { get; private set; } = string.Empty;
        public string FechaFin { get; private set; } = string.Empty;
        public decimal Precio { get; private set; }
        public bool Activo { get; private set; }

        public static PaqueteTuristico Create(string nombre, string descripcion, string fechaInicio, string fechaFin, decimal precio, bool activo)
        {
            var id = new PaqueteTuristicoId(Guid.NewGuid());
            return new PaqueteTuristico(id, nombre, descripcion, fechaInicio, fechaFin, precio, activo);
        }

        public void Update(string nombre, string descripcion, string fechaInicio, string fechaFin, decimal precio, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Precio = precio;
            Activo = activo;
        }
    }
}
