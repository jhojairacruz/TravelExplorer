namespace Domain.ValueObjects;

public partial record Telefono
{
    private const int DefaultLenght = 9;
    private const string Pattern = @"^(?:-*\d-*){8}$";

    private Telefono(string value) => Value = value;

    public static Telefono? Create(string value)
    {
        if(string.IsNullOrEmpty(value) || !TelefonoRegex().IsMatch(value) || value.Length != DefaultLenght)
        {
            return null;
        }

        return new Telefono(value);
    }

    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex TelefonoRegex();
}