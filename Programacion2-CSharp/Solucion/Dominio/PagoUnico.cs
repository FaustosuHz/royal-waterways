namespace Dominio
{
    public class PagoUnico : Pago
    {
        public int NumeroDeRecibo { get; set; }
        public DateTime FechaDePago { get; set; }
        public PagoUnico() { }

        public PagoUnico(Gasto tipoDeGasto, MetodoDePago tipoPago, Usuario usuario, string descripcion, double monto, int numeroRecibo, DateTime fechaPago) : base(tipoDeGasto, tipoPago, usuario, descripcion, monto)
        {
            NumeroDeRecibo = numeroRecibo;
            FechaDePago = fechaPago;
        }

        public override DateTime Fecha()
        {
            return FechaDePago;
        }

        public override double CalcularMonto()
        {
            double descuento = 0.10;

            if (TipoPago == MetodoDePago.Efectivo)
                descuento = 0.20;

            double montoFinal = Monto - (Monto * descuento);

            return montoFinal;
        }

        public override double MontoFinal()
        {
            return CalcularMonto();
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNumeroRecibo();
            ValidarFechaDePago();
        }

        private void ValidarNumeroRecibo() 
        {
            if (NumeroDeRecibo <= 0) { throw new Exception("El número de recibo debe ser mayor a cero."); }
        }

        private void ValidarFechaDePago()
        {
            if (FechaDePago == DateTime.MinValue) { throw new Exception("La fecha de pago es obligatoria."); }
        }

        public override string MiTipo() 
        { 
            return "Pago Unico";
        }

        public override string Mostrar()
        {
            double total = CalcularMonto();
            string resultado = $"#{Id} | {MiTipo()} | {TipoPago} | Total: {total} | Unico";
            return resultado;
        }
    }
}