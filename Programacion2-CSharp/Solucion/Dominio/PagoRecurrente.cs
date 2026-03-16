namespace Dominio
{
    public class PagoRecurrente : Pago
    {
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public PagoRecurrente() { }

        public PagoRecurrente(Gasto tipoDeGasto, MetodoDePago tipoPago, Usuario usuario, string descripcion, double monto, DateTime fechaInicial, DateTime? fechaFinal = null) : base(tipoDeGasto, tipoPago, usuario, descripcion, monto)
        {
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }

        public override string MiTipo()
        {
            return "Pago Recurrente";
        }

        public override DateTime Fecha()
        {
            return FechaInicial;
        }

        public override double CalcularMonto()
        {
            if (FechaFinal == null)
            {
                double recargoSinLimite = 0.03;
                double totalSinLimite = Monto + (Monto * recargoSinLimite);
                return totalSinLimite;
            }

            int meses = ((FechaFinal.Value.Year - FechaInicial.Year) * 12) + (FechaFinal.Value.Month - FechaInicial.Month) + 1;

            if (meses < 1)
            {
                meses = 1;
            }

            double recargo = 0.03;

            if (meses >= 6) { recargo = 0.05; }

            if (meses > 10) { recargo = 0.10; }
                
            double total = (Monto * meses) + (Monto * recargo);

            return total;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarFechaInicial();
            ValidarFechaFinal();
        }

        private void ValidarFechaInicial()
        {
            if (FechaInicial == DateTime.MinValue)
            {
                throw new Exception("La fecha inicial del pago es obligatoria");
            }
        }

        private void ValidarFechaFinal()
        {
            if (FechaFinal != null)
            {
                if (FechaFinal.Value < FechaInicial)
                {
                    throw new Exception("La fecha final no puede ser anterior a la fecha inicial");
                }
            }
        }

        private int CalcularCuotasRestantes()
        {
            if (FechaFinal == null)
            {
                return -1;
            }

            int mesesTotales = ((FechaFinal.Value.Year - FechaInicial.Year) * 12) + (FechaFinal.Value.Month - FechaInicial.Month) + 1;
            if (mesesTotales < 1)
            {
                mesesTotales = 1;
            }

            DateTime hoy = DateTime.Today;
            int mesesTranscurridos = ((hoy.Year - FechaInicial.Year) * 12) + (hoy.Month - FechaInicial.Month);
            if (mesesTranscurridos < 0)
            {
                mesesTranscurridos = 0;
            }

            int restantes = mesesTotales - mesesTranscurridos;
            if (restantes < 0)
            {
                restantes = 0;
            }

            return restantes;
        }

        public override string Mostrar()
        {
            double total = CalcularMonto();
            int restantes = CalcularCuotasRestantes();
            string estado = "";

            if (restantes == -1)
            {
                estado = "recurrente";
            }
            else
            {
                estado = "pendientes: " + restantes;
            }
            string resultado = $"#{Id} | {MiTipo()} | {TipoPago} | Total: {total} | {estado}";

            return resultado;
        }

        public override double MontoFinal()
        {
            if (FechaFinal == null) return CalcularMonto();

            int meses = ((FechaFinal.Value.Year - FechaInicial.Year) * 12)
                        + (FechaFinal.Value.Month - FechaInicial.Month) + 1;
            if (meses < 1) meses = 1;

            return CalcularMonto() / meses;
        }
    }
}