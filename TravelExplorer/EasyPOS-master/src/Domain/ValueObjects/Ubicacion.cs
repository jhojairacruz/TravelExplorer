namespace Domain.ValueObjects
{
    public partial record Ubicacion
    {
        public Ubicacion(string pais, string estado, string codigoPostal)
        {
            Pais = pais;
            Estado = estado;
            CodigoPostal = codigoPostal;
        }

        public string Pais { get; init; }
        public string Estado { get; init; }
        public string CodigoPostal { get; init; }

        public static Ubicacion? Create(string pais, string estado, string codigoPostal, bool V)
        {
            if (string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(codigoPostal))
            {
                return null;
            }

            return new Ubicacion(pais, estado, codigoPostal);
        }
    }
}
