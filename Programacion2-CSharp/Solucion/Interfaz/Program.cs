using System.Globalization;
using Dominio;

class Program
{
    static void Main()
    {
        Sistema sis = Sistema.Instancia();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1) Crear equipo");
            Console.WriteLine("2) Crear usuario");
            Console.WriteLine("3) Crear gasto");
            Console.WriteLine("4) Registrar pago unico");
            Console.WriteLine("5) Registrar pago recurrente");
            Console.WriteLine("6) Mostrar todos los usuarios");
            Console.WriteLine("7) Mostrar pagos por correo de usuario");
            Console.WriteLine("8) Mostrar usuarios de un equipo");
            Console.WriteLine("0) Salir");
            Console.Write("Elegir opción: ");

            string opcion = Console.ReadLine();
            Console.WriteLine();

            if (opcion == "1") CrearEquipo(sis);
            else if (opcion == "2") CrearUsuario(sis);
            else if (opcion == "3") CrearGasto(sis);
            else if (opcion == "4") RegistrarPagoUnico(sis);
            else if (opcion == "5") RegistrarPagoRecurrente(sis);
            else if (opcion == "6") MostrarUsuarios(sis);
            else if (opcion == "7") MostrarPagosPorCorreo(sis);
            else if (opcion == "8") MostrarUsuariosPorEquipo(sis);
            else if (opcion == "0") salir = true;
            else Console.WriteLine("Opción invalida");

            Console.WriteLine();
        }
    }

    static void CrearEquipo(Sistema sis)
    {
        Console.Write("Nombre del equipo: ");
        string nombre = Console.ReadLine();
        sis.AltaEquipo(new Equipo(nombre));
        Console.WriteLine("Equipo creado correctamente.");
    }

    static void CrearUsuario(Sistema sis)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Contraseña (mínimo 8 caracteres): ");
        string contrasenia = Console.ReadLine();

        List<Equipo> equipos = sis.GetEquipos();

        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos. Cree uno primero.");
            return;
        }

        Console.WriteLine("Equipos disponibles:");
        for (int i = 0; i < equipos.Count; i++)
        {
            Console.WriteLine((i + 1) + ") " + equipos[i].Nombre);
        }

        Console.Write("Seleccione el número del equipo: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        Equipo equipoSeleccionado = equipos[indice];

        Usuario nuevo = new Usuario(nombre, apellido, contrasenia, equipoSeleccionado,Rol.Empleado, DateTime.Today);
        sis.AltaUsuario(nuevo);

        Console.WriteLine("Usuario creado. Email generado: " + nuevo.Email);
    }

    static void CrearGasto(Sistema sis)
    {
        Console.Write("Nombre del gasto: ");
        string nombre = Console.ReadLine();
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();
        sis.AltaGasto(new Gasto(nombre, descripcion));
        Console.WriteLine("Gasto creado correctamente.");
    }

    static void RegistrarPagoUnico(Sistema sis)
    {
        Usuario usuario = ElegirUsuario(sis);
        Gasto gasto = ElegirGasto(sis);

        Console.Write("Descripción del pago: ");
        string descripcion = Console.ReadLine();
        Console.Write("Monto: ");
        double monto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Número de recibo: ");
        int numero = int.Parse(Console.ReadLine());
        Console.Write("Fecha del pago (yyyy-MM-dd): ");
        DateTime fecha = DateTime.Parse(Console.ReadLine());

        PagoUnico pago = new PagoUnico(gasto, MetodoDePago.Efectivo, usuario, descripcion, monto, numero, fecha);
        sis.AltaPago(pago);
        Console.WriteLine("Pago unico registrado. Total: " + pago.CalcularMonto());
    }

    static void RegistrarPagoRecurrente(Sistema sis)
    {
        Usuario usuario = ElegirUsuario(sis);
        Gasto gasto = ElegirGasto(sis);

        Console.Write("Descripción del pago: ");
        string descripcion = Console.ReadLine();
        Console.Write("Monto mensual: ");
        double monto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Fecha inicial yyyy-mm-dd: ");
        DateTime inicio = DateTime.Parse(Console.ReadLine());
        Console.Write("Fecha final yyyy-mm-dd (o vacio si no tiene fecha final): ");
        string textoFin = Console.ReadLine();
        DateTime? fin = string.IsNullOrEmpty(textoFin) ? (DateTime?)null : DateTime.Parse(textoFin);

        PagoRecurrente pago = new PagoRecurrente(gasto, MetodoDePago.Credito, usuario, descripcion, monto, inicio, fin);
        sis.AltaPago(pago);
        Console.WriteLine("Pago recurrente registrado. Total: " + pago.CalcularMonto());
    }

    static void MostrarUsuarios(Sistema sis)
    {
        Console.WriteLine("=== Usuarios ===");
        foreach (Usuario u in sis.GetUsuarios())
        {
            Console.WriteLine(u.Nombre + " " + u.Apellido + " | " + u.Email + " | Equipo: " + u.Equipo.Nombre);
        }
    }

    static void MostrarPagosPorCorreo(Sistema sis)
    {
        Console.Write("Correo del usuario: ");
        string correo = Console.ReadLine();

        bool encontrado = false;

        foreach (Pago p in sis.GetPagos())
        {
            if (p.Usuario != null && p.Usuario.Email.ToLower() == correo.ToLower())
            {
                Console.WriteLine(p.Mostrar());
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No hay pagos registrados para ese correo.");
        }
    }

    static void MostrarUsuariosPorEquipo(Sistema sis)
    {
        Console.Write("Nombre del equipo: ");
        string nombreEquipo = Console.ReadLine();

        bool encontrado = false;

        foreach (Usuario u in sis.GetUsuarios())
        {
            if (u.Equipo != null && u.Equipo.Nombre.ToLower() == nombreEquipo.ToLower())
            {
                Console.WriteLine(u.Nombre + " " + u.Apellido + " - " + u.Email);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No hay usuarios en ese equipo.");
        }
    }

    static Usuario ElegirUsuario(Sistema sis)
    {
        List<Usuario> usuarios = sis.GetUsuarios();

        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.WriteLine((i + 1) + ") " + usuarios[i].Nombre + " " + usuarios[i].Apellido);
        }

        Console.Write("Seleccione usuario #: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        return usuarios[indice];
    }

    static Gasto ElegirGasto(Sistema sis)
    {
        List<Gasto> gastos = sis.GetGastos();

        for (int i = 0; i < gastos.Count; i++)
        {
            Console.WriteLine((i + 1) + ") " + gastos[i].Nombre);
        }

        Console.Write("Seleccione gasto #: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        return gastos[indice];
    }
}
