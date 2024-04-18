namespace Domain.ValueObjects;

public partial record Direccion
{
    public Direccion(string calle, string colonia, string municipio, string departamento)
    {
        Calle = calle;
        Colonia = colonia;
        Municipio = municipio;
        Departamento = departamento;
    }

    public string Calle { get; init; }
    public string Colonia { get; init; }
    public string Municipio { get; init; }
    public string Departamento { get; init; }

    public static Direccion? Create(string calle, string colonia, string municipio, string departamento)
    {
        if (string.IsNullOrEmpty(calle) || string.IsNullOrEmpty(colonia) ||
            string.IsNullOrEmpty(municipio) || string.IsNullOrEmpty(departamento))
        {
            return null;
        }

        return new Direccion(calle, colonia, municipio, departamento);
    }
}
