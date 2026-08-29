namespace Dominio.InterfacesLogicaAplicacion
{
    public interface ICUEvaluacionConIA<TInput, TOutput>
    {
        TOutput Execute(TInput input);
    }
}