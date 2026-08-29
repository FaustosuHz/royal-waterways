using Dominio.Excepciones.EquipoException;

public record VOAnguloVisionGrado
{
    public decimal Value { get; private set; }

    private VOAnguloVisionGrado()
    {
    }

    public VOAnguloVisionGrado(decimal value)
    {
        Value = value;
        Validar();
    }

    private void Validar()
    {
        if (Value <= 0)
            throw new AnguloVisionInvalidException("El ángulo de visión debe ser mayor a 0 grados.");

        if (Value > 180)
            throw new AnguloVisionInvalidException("El ángulo de visión no puede superar 180 grados.");
    }
}