namespace WebApi.Excepciones
{
    public class CredencialesIncorrectasException : Exception
    {
        public CredencialesIncorrectasException()
            : base("Credenciales incorrectas")
        {
        }

        public CredencialesIncorrectasException(string message)
            : base(message)
        {
        }
    }
}