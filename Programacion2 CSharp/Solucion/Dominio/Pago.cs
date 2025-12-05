namespace Dominio
{
    public abstract class Pago : IValidar
    {
            public static int UltimoId { get; set; }
            public int Id { get; set; }
            public Gasto TipoDeGasto { get; set; }
            public MetodoDePago TipoPago { get; set; }
            public Usuario Usuario { get; set; }
            public string Descripcion { get; set; }
            public double MontoOriginal { get; set; } //monto sin descuentos
            public double Monto { get; set; }

            public Pago()
            {
                Id = UltimoId;
                UltimoId++;
            }

            public Pago(Gasto tipoDeGasto, MetodoDePago tipoPago, Usuario usuario, string descripcion, double monto)
            {
                Id = UltimoId;
                UltimoId++;
                TipoDeGasto = tipoDeGasto;
                TipoPago = tipoPago;
                Usuario = usuario;
                Descripcion = descripcion;
                Monto = monto;
                MontoOriginal = monto;
        }

        public abstract string MiTipo();
        public abstract double CalcularMonto();
        public abstract string Mostrar();
        public abstract double MontoFinal();
        public abstract DateTime Fecha();

        public virtual void Validar()
        {
            ValidarUsuario();
            ValidarTipoDeGasto();
            ValidarDescripcion();
            ValidarMonto();
        }
        private void ValidarUsuario()
        {
            if (Usuario == null) { throw new Exception("El Pago debe tener un usuario asignado"); }
        }
        private void ValidarTipoDeGasto()
        {
            if (TipoDeGasto == null) { throw new Exception("El Pago debe estar asociado a algun gasto"); }
        }
        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion)) { throw new Exception("La descripcion no puede estar vacia"); }
        }
        private void ValidarMonto()
        {
            if (Monto <= 0) { throw new Exception("El monto debe ser mayor a cero"); }
        }

        public override bool Equals(object obj)
        {
            if (obj is Pago p)
            {
                return Id == p.Id;
            }
            else
            {
                return false;
            }
        }

    }
}