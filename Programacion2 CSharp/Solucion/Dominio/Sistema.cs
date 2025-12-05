namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Equipo> _equipos = new List<Equipo>();
        private List<Gasto> _gastos = new List<Gasto>();
        private List<Pago> _pagos = new List<Pago>();

        private static Sistema _instancia;

        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        private Sistema()
        {
            PrecargarEquipos();
            PrecargarGastos();
            PrecargarUsuarios();
            PrecargarPagos();
        }

        public List<Usuario> GetUsuarios() { return _usuarios; }
        public List<Equipo> GetEquipos() { return _equipos; }
        public List<Gasto> GetGastos() { return _gastos; }
        public List<Pago> GetPagos() { return _pagos; }

        public void AltaUsuario(Usuario u)
        {
            if (u != null && !_usuarios.Contains(u))
            {
                try
                {
                    u.Validar();
                    GenerarEmailUnico(u);
                    _usuarios.Add(u);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de alta el usuario: " + ex.Message);
                }
            }
        }

        public Usuario ObtenerUsuarioPorEmailYContrasenia(string email, string contrasenia)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Email.Equals(email) && u.Contrasenia.Equals(contrasenia))
                {
                    return u;
                }
            }

            return null;
        }

        public List<Usuario> ObtenerMiembrosDeEquipo(Usuario usuario)
        {
            List<Usuario> lista = new List<Usuario>();

            foreach (Usuario u in _usuarios)
            {
                if (u.Equipo != null
                    && usuario.Equipo != null
                    && u.Equipo.Nombre == usuario.Equipo.Nombre)
                {
                    lista.Add(u);
                }
            }

            lista.Sort((a, b) => a.Email.CompareTo(b.Email));   // ya los mandamos ordenados

            return lista;
        }

        public List<Pago> ObtenerPagoPorUsuarioPorId(int unId)
        {
            List<Pago> pagosDeUsuario = new List<Pago>();
            foreach (Pago p in _pagos)
            {
                if (p.Usuario != null && p.Usuario.Id.Equals(unId))
                {
                    pagosDeUsuario.Add(p);
                }
            }

            int orden = -1;

            pagosDeUsuario.Sort(CompararPagos);

            int CompararPagos(Pago a, Pago b)
            {
                return orden * a.Monto.CompareTo(b.Monto);
            }

            return pagosDeUsuario;
        }

        public List<Pago> ObtenerPagosDeMiembrosDeEquipo(Usuario Gerente)
        {
            List<Usuario> miembrosEquipo = ObtenerMiembrosDeEquipo(Gerente);
            List<Pago> pagosDeEquipo = new List<Pago>();

            foreach (Usuario u in miembrosEquipo)
            {
                List<Pago> pagosdeUsuario = ObtenerPagoPorUsuarioPorId(u.Id);

                foreach (Pago p in pagosdeUsuario)
                {
                    pagosDeEquipo.Add(p);
                }
            }

            int orden = -1; // -1 para descendente
            pagosDeEquipo.Sort(CompararPagos);

            int CompararPagos(Pago a, Pago b)
            {
                return orden * a.Monto.CompareTo(b.Monto);
            }

            return pagosDeEquipo;
        }

        public Usuario ObtenerUsuarioPorId(int unId)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Id.Equals(unId))
                {
                    return u;
                }
            }

            return null;
        }

        public Gasto ObtenerGastoPorId(int unId)
        {
            foreach (Gasto g in _gastos)
            {
                if (g.Id.Equals(unId))
                {
                    return g;
                }
            }

            return null;
        }

        public void BajaGasto(Gasto g)
        {
           _gastos.Remove(g);
        }

        public double ObtenerGastosDelMes(int? unId)
        {
            double monto = 0;

            if (unId == null) return monto;

            DateTime hoy = DateTime.Today;
            int mesActual = hoy.Month;
            int anioActual = hoy.Year;

            foreach (Pago p in _pagos)
            {
                if (p.Usuario != null && p.Usuario.Id.Equals(unId) && p.Fecha().Month == mesActual && p.Fecha().Year == anioActual)
                {
                    monto += p.Monto;
                }
            }

            return monto;
        }

        public void AltaEquipo(Equipo e)
        {
            if (e != null && !_equipos.Contains(e))
            {
                try
                {
                    e.Validar();
                    _equipos.Add(e);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de alta el equipo: " + ex.Message);
                }
            }
        }

        public void AltaGasto(Gasto g)
        {
            if (g != null && !_gastos.Contains(g))
            {
                try
                {
                    g.Validar();
                    _gastos.Add(g);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de alta el gasto: " + ex.Message);
                }
            }
        }

        public void CargarGasto(string nombre, string descripcion)
        {
            Gasto nuevoGasto = new Gasto (nombre, descripcion);

            AltaGasto (nuevoGasto);
        }

        public void AltaPago(Pago p)
        {
            if (p != null && !_pagos.Contains(p))
            {
                try
                {
                    p.Validar();
                    _pagos.Add(p);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de alta el pago" + ex.Message);
                }
            }
        }

        public void AltaPagoUnico(Gasto tipoDeGasto, MetodoDePago metodoPago, Usuario usuario, string descripcion, double monto, int numeroRecibo, DateTime fechaPago)
        {
            Pago nuevoPago = new PagoUnico(tipoDeGasto, metodoPago, usuario, descripcion, monto, numeroRecibo, fechaPago);

            nuevoPago.MontoOriginal = monto; //guardamos en montoOriginal el valor sin tocar
            nuevoPago.Monto = nuevoPago.MontoFinal(); // monto final devuelve calcularMonto, que simplemente calcula los descuentos en base al tipo de pago, pero use este metodo para usar la herencia desde Pago

            AltaPago(nuevoPago);
        }

        public void AltaPagoRecurrente(Gasto tipoDeGasto, MetodoDePago metodoPago, Usuario usuario, string descripcion, double monto, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            var nuevoPago = new PagoRecurrente(tipoDeGasto, metodoPago, usuario, descripcion, monto, fechaInicial, fechaFinal);

            nuevoPago.MontoOriginal = monto; //guardamos en montoOriginal el valor sin tocar
            nuevoPago.Monto = nuevoPago.MontoFinal(); //con monto final muestra el valor de la cuota y en caso de que la fecha final sea null mostraria su total teniendo en cuenta los descuentos

            AltaPago(nuevoPago);
        }

        public void GenerarEmailUnico(Usuario nuevoUsuario)
        {
            string baseEmail = CrearEmailBase(nuevoUsuario);
            string dominio = "@laEmpresa.com";
            string emailFinal = baseEmail + dominio;
            int contador = 1;
            bool existe = false;

            while (!existe)
            {
                existe = true;

                foreach (Usuario u in _usuarios)
                {
                    if (u.Email == emailFinal)
                    {
                        emailFinal = baseEmail + contador + dominio;
                        contador++;
                        existe = false;
                    }
                }
            }

            nuevoUsuario.Email = emailFinal;
        }

        private string CrearEmailBase(Usuario nuevoUsuario)
        {
            string nombreBase;
            string apellidoBase;

            if (nuevoUsuario.Nombre.Length >= 3)
            {
                nombreBase = nuevoUsuario.Nombre.Substring(0, 3).ToLower(); //tomamos las tres primeras letras del nombre
            }
            else
            {
                nombreBase = nuevoUsuario.Nombre.ToLower();
            }

            if (nuevoUsuario.Apellido.Length >= 3)
            {
                apellidoBase = nuevoUsuario.Apellido.Substring(0, 3).ToLower(); //tomamos las tres primeras letras del apellido
            }
            else
            {
                apellidoBase = nuevoUsuario.Apellido.ToLower();
            }

            string emailBase = nombreBase + apellidoBase;
            return emailBase;
        }

        #region Precargas

        private void PrecargarEquipos()
        {
            AltaEquipo(new Equipo("Marketing"));
            AltaEquipo(new Equipo("IT"));
            AltaEquipo(new Equipo("Ventas"));
            AltaEquipo(new Equipo("Finanzas"));
        }

        private void PrecargarGastos()
        {
            AltaGasto(new Gasto("Auto", "Gastos del vehículo"));
            AltaGasto(new Gasto("Comidas", "Restaurantes y viandas"));
            AltaGasto(new Gasto("Servicios", "Suscripciones mensuales"));
            AltaGasto(new Gasto("Oficina", "Insumos de oficina"));
            AltaGasto(new Gasto("Viajes", "Traslados y hospedajes"));
            AltaGasto(new Gasto("Eventos", "Capacitaciones y conferencias"));
            AltaGasto(new Gasto("Tecnología", "Licencias y software"));
            AltaGasto(new Gasto("Publicidad", "Campañas de marketing"));
            AltaGasto(new Gasto("Regalos", "Obsequios corporativos"));
            AltaGasto(new Gasto("Transporte", "Taxis, buses o movilidad corporativa"));
        }

        private void PrecargarUsuarios()
        {
            var e1 = _equipos[0];
            var e2 = _equipos[1];
            var e3 = _equipos[2];
            var e4 = _equipos[3];

            var lista = new List<Usuario>
    {
        // Gerentes primero
        new Usuario("Natalia", "Rojas", "clave12345", e1, Rol.Gerente, DateTime.Today.AddMonths(-12)),
        new Usuario("Tomas", "Moreno", "clave12345", e2, Rol.Gerente, DateTime.Today.AddMonths(-10)),
        new Usuario("Camila", "Ruiz", "clave12345", e3, Rol.Gerente, DateTime.Today.AddMonths(-8)),
        new Usuario("Carla", "Mendez", "clave12345", e4, Rol.Gerente, DateTime.Today.AddMonths(-6)),

        // Empleados Marketing
        new Usuario("Juan", "Perez", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-10)),
        new Usuario("Ana", "Lopez", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-8)),
        new Usuario("Mario", "Diaz", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-6)),
        new Usuario("Laura", "Fernandez", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-4)),
        new Usuario("Jose", "Ramirez", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-3)),
        new Usuario("Lucia", "Gomez", "clave12345", e1, Rol.Empleado, DateTime.Today.AddMonths(-2)),

        // Empleados IT
        new Usuario("Pedro", "Suarez", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-10)),
        new Usuario("Clara", "Lopez", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-9)),
        new Usuario("Diego", "Paz", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-7)),
        new Usuario("Sandra", "Vega", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-5)),
        new Usuario("Sergio", "Campos", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-3)),
        new Usuario("Isabel", "Figueroa", "clave12345", e2, Rol.Empleado, DateTime.Today.AddMonths(-2)),

        // Empleados Ventas
        new Usuario("Hector", "Flores", "clave12345", e3, Rol.Empleado, DateTime.Today.AddMonths(-9)),
        new Usuario("Sofia", "Navarro", "clave12345", e3, Rol.Empleado, DateTime.Today.AddMonths(-6)),
        new Usuario("Martina", "Perez", "clave12345", e3, Rol.Empleado, DateTime.Today.AddMonths(-5)),
        new Usuario("Ricardo", "Salas", "clave12345", e3, Rol.Empleado, DateTime.Today.AddMonths(-4)),

        // Empleados Finanzas
        new Usuario("Valentina", "Costa", "clave12345", e4, Rol.Empleado, DateTime.Today.AddMonths(-12)),
        new Usuario("Luciano", "Santos", "clave12345", e4, Rol.Empleado, DateTime.Today.AddMonths(-4))
    };

            foreach (var u in lista)
                AltaUsuario(u);
        }

        private void PrecargarPagos()
        {
            var g = _gastos;
            var u = _usuarios;

            AltaPagoUnico(g[0], MetodoDePago.Efectivo, u[0], "Nafta auto", 5000, 1001, DateTime.Today.AddDays(-3));
            AltaPagoUnico(g[1], MetodoDePago.Credito, u[0], "Cena equipo", 8000, 1002, DateTime.Today.AddDays(-10));
            AltaPagoUnico(g[2], MetodoDePago.Debito, u[1], "Almuerzo", 3000, 1003, DateTime.Today.AddDays(-5));
            AltaPagoUnico(g[3], MetodoDePago.Efectivo, u[1], "Compra insumos", 12000, 1004, DateTime.Today.AddMonths(-1));
            AltaPagoUnico(g[4], MetodoDePago.Credito, u[2], "Hotel viaje", 18000, 1005, DateTime.Today.AddMonths(-2));
            AltaPagoUnico(g[5], MetodoDePago.Debito, u[2], "Taxi viaje", 700, 1006, DateTime.Today.AddMonths(-1));
            AltaPagoUnico(g[6], MetodoDePago.Efectivo, u[3], "Regalos corporativos", 9500, 1007, DateTime.Today.AddDays(-12));
            AltaPagoUnico(g[7], MetodoDePago.Credito, u[3], "Licencia software", 15000, 1008, DateTime.Today.AddMonths(-3));
            AltaPagoUnico(g[8], MetodoDePago.Debito, u[4], "Campaña marketing", 12000, 1009, DateTime.Today.AddDays(-2));
            AltaPagoUnico(g[9], MetodoDePago.Efectivo, u[4], "Material oficina", 4000, 1010, DateTime.Today.AddDays(-15));

            // Pagos únicos para gerentes
            AltaPagoUnico(g[0], MetodoDePago.Credito, u[5], "Reunión corporativa", 22000, 1011, DateTime.Today.AddDays(-7));
            AltaPagoUnico(g[1], MetodoDePago.Debito, u[6], "Cena con clientes", 18000, 1012, DateTime.Today.AddDays(-4));
            AltaPagoUnico(g[2], MetodoDePago.Efectivo, u[7], "Evento interno", 25000, 1013, DateTime.Today.AddDays(-1));
            AltaPagoUnico(g[3], MetodoDePago.Credito, u[8], "Capacitación externa", 17000, 1014, DateTime.Today.AddDays(-6));

            // Pagos recurrentes empleados
            AltaPagoRecurrente(g[0], MetodoDePago.Credito, u[0], "Netflix", 1500, DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(-1)); // ya finalizado
            AltaPagoRecurrente(g[1], MetodoDePago.Debito, u[0], "Spotify", 1000, DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-1)); // ya finalizado
            AltaPagoRecurrente(g[2], MetodoDePago.Credito, u[1], "Disney+", 1200, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[3], MetodoDePago.Credito, u[1], "Amazon Prime", 1300, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[4], MetodoDePago.Debito, u[2], "HBO Max", 1400, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[5], MetodoDePago.Credito, u[3], "Office 365", 2200, DateTime.Today.AddMonths(-2), null);
            AltaPagoRecurrente(g[6], MetodoDePago.Debito, u[4], "Adobe Creative Cloud", 3000, DateTime.Today.AddMonths(-2), null);

            // Pagos recurrentes gerentes
            AltaPagoRecurrente(g[0], MetodoDePago.Credito, u[5], "ERP mensual", 5000, DateTime.Today.AddMonths(-2), null);
            AltaPagoRecurrente(g[1], MetodoDePago.Debito, u[5], "Suscripción herramientas", 2000, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[2], MetodoDePago.Efectivo, u[6], "Consultoría", 7000, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[3], MetodoDePago.Credito, u[6], "Publicidad mensual", 4500, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[4], MetodoDePago.Debito, u[7], "Capacitación online", 3500, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[5], MetodoDePago.Credito, u[7], "Software adicional", 2500, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[6], MetodoDePago.Debito, u[8], "Servicios externos", 6000, DateTime.Today.AddMonths(-1), null);
            AltaPagoRecurrente(g[7], MetodoDePago.Credito, u[8], "Evento interno mensual", 4000, DateTime.Today.AddMonths(-1), null);

            // Pagos recurrentes extra para empleados para el mes actual
            AltaPagoRecurrente(g[0], MetodoDePago.Credito, u[9], "Netflix", 1500, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[1], MetodoDePago.Debito, u[10], "Spotify", 1000, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[2], MetodoDePago.Credito, u[11], "Disney+", 1200, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[3], MetodoDePago.Credito, u[12], "Amazon Prime", 1300, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[4], MetodoDePago.Debito, u[13], "HBO Max", 1400, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[5], MetodoDePago.Credito, u[14], "Office 365", 2200, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);
            AltaPagoRecurrente(g[6], MetodoDePago.Debito, u[15], "Adobe Creative Cloud", 3000, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), null);

        }
        #endregion

    }
}
