package sistemaViajes;
import dominio.Aeropuerto;
import dominio.Pasajero;
import dominio.Vuelo;
import tads.ListaSE;

//Brayan Gonzalez - 230176
//Fausto Aristimuño - 344072

public class ImplementacionSistema implements Sistema {
    
    private ListaSE<Pasajero> pasajeros;
    private ListaSE<Pasajero> pasajerosPlatino;
    private ListaSE<Pasajero> pasajerosFrecuente;
    private ListaSE<Pasajero> pasajerosEstandar;
    private ListaSE<Pasajero> pasajerosEsporadico;
    private ListaSE<Aeropuerto> aeropuertos;
    private ListaSE<Vuelo> vuelos;

    @Override
    public Retorno inicializarSistema() {
        pasajeros = new ListaSE<>();
        pasajerosPlatino = new ListaSE<>();
        pasajerosFrecuente = new ListaSE<>();
        pasajerosEstandar = new ListaSE<>();
        pasajerosEsporadico = new ListaSE<>();
        aeropuertos = new ListaSE<>();
        vuelos = new ListaSE<>();
        return Retorno.ok();
    }

    @Override
    public Retorno registrarPasajero(String cedula, String nombre, int edad, Categoria categoria) {
        
        if (cedula == null || cedula.isBlank() || nombre == null || nombre.isBlank() || categoria == null) {
            return Retorno.error1();
        }
        
        String regex = "^[1-9]\\.\\d{3}\\.\\d{3}-\\d$|^[1-9]\\d{2}\\.\\d{3}-\\d$";
        if (!cedula.matches(regex)) {
            return Retorno.error2();
        }
        
        if (edad < 0) {
            return Retorno.error3();
        }
        
        if (buscarPasajeroPorCedula(cedula) != null) {
            return Retorno.error4();
        }
        
        Pasajero nuevo = new Pasajero(cedula, nombre, edad, categoria);
        pasajeros.insertarOrdenado(nuevo);

        switch (categoria) {
            case PLATINO:
                pasajerosPlatino.insertarOrdenado(nuevo);
                break;
            case FRECUENTE:
                pasajerosFrecuente.insertarOrdenado(nuevo);
                break;
            case ESTANDAR:
                pasajerosEstandar.insertarOrdenado(nuevo);
                break;
            case ESPORADICO:
             pasajerosEsporadico.insertarOrdenado(nuevo);
                break;
        }
        return Retorno.ok();
    }

    @Override
    public Retorno buscarPasajero(String cedula) {
        
        String regex = "^[1-9]\\.\\d{3}\\.\\d{3}-\\d$|^[1-9]\\d{2}\\.\\d{3}-\\d$";
        if (cedula == null || !cedula.matches(regex)) {
            return Retorno.error1();
        }
        
        Pasajero p = buscarPasajeroPorCedula(cedula);
        if (p == null) {
            return Retorno.error2();
        }
        
        String valor = p.getCedula() + ";" + p.getNombre() + ";" + p.getEdad() + ";" + p.getCategoria().getTexto();
        return Retorno.ok(valor);
    }
    
    @Override
    public Retorno listarPasajerosAscendente() {
        
        if (pasajeros.vacia()) {
            return Retorno.ok("");
        }
        
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < pasajeros.longitud(); i++) {
            try {
                Pasajero p = pasajeros.obtener(i);
                if (sb.length() > 0) sb.append("|");
                    sb.append(p.getCedula()).append(";")
                      .append(p.getNombre()).append(";")
                      .append(p.getEdad()).append(";")
                      .append(p.getCategoria().getTexto());
            } catch (Exception e) {}
        } return Retorno.ok(sb.toString());
    }

    @Override
    public Retorno listarPasajerosDescendente() {
        
        if (pasajeros.vacia()) {
            return Retorno.ok("");
        }

        pasajeros.invertirIterativo();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < pasajeros.longitud(); i++) {
            try {
                Pasajero p = pasajeros.obtener(i);
                if (sb.length() > 0) sb.append("|");
                    sb.append(p.getCedula()).append(";")
                      .append(p.getNombre()).append(";")
                      .append(p.getEdad()).append(";")
                      .append(p.getCategoria().getTexto());
            } catch (Exception e) {}
        }
        pasajeros.invertirIterativo();
        return Retorno.ok(sb.toString());
    }

    @Override
    public Retorno listarPasajerosPorCategoría(Categoria unaCategoria) {
        ListaSE<Pasajero> lista;
        switch (unaCategoria) {
            case PLATINO:
                lista = pasajerosPlatino;
                break;
            case FRECUENTE:
                lista = pasajerosFrecuente;
                break;
            case ESTANDAR:
                lista = pasajerosEstandar;
                break;
            case ESPORADICO:
                lista = pasajerosEsporadico;
                break;
            default:
                lista = new ListaSE<>();
                break;
        }
        
        if (lista.vacia()) {
            return Retorno.ok("");
        }
        
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lista.longitud(); i++) {
            try {
                Pasajero p = lista.obtener(i);
                if (sb.length() > 0) sb.append("|");
                    sb.append(p.getCedula()).append(";")
                      .append(p.getNombre()).append(";")
                      .append(p.getEdad()).append(";")
                      .append(p.getCategoria().getTexto());
            } catch (Exception e) {}
        } return Retorno.ok(sb.toString());
    }
    
    @Override
    public Retorno registrarAeropuerto(String codigo, String nombre) {
        if (codigo == null || codigo.isBlank() || nombre == null || nombre.isBlank()) {
            return Retorno.error1();
        }
        
        for (int i = 0; i < aeropuertos.longitud(); i++) {
            try {
                if (aeropuertos.obtener(i).getCodigo().equals(codigo)) {
                    return Retorno.error2();
                }
            } catch (Exception e) {}
        }
        
        aeropuertos.adicionarInicio(new Aeropuerto(codigo, nombre));
        return Retorno.ok();
    }

    @Override
    public Retorno obtenerAeropuerto(String codigo) {
        if (codigo == null || codigo.isBlank()) {
            return Retorno.error1();
        }
        
        for (int i = 0; i < aeropuertos.longitud(); i++) {
            try {
                Aeropuerto a = aeropuertos.obtener(i);
                if (a.getCodigo().equals(codigo)) {
                    String valor = a.getCodigo() + ";" + a.getNombre();
                    int cantVuelos = a.getColaVuelos().longitud();
                    return new Retorno(Retorno.Resultado.OK, valor, cantVuelos);
                }
            } catch (Exception e) {}
        } return Retorno.error2();
    }

    @Override
    public Retorno registrarVuelo(String codigoAeropuertoOrigen, String codigoAeropuertoDestino, String codigoDeVuelo, int capacidad, int costoEnDolares) {
        if (capacidad <= 0 || costoEnDolares <= 0) {
            return Retorno.error1();
        }
        
        if (codigoAeropuertoOrigen == null || codigoAeropuertoOrigen.isBlank() ||
            codigoAeropuertoDestino == null || codigoAeropuertoDestino.isBlank() ||
            codigoDeVuelo == null || codigoDeVuelo.isBlank()) {
            return Retorno.error2();
        }
        
        if (!existeAeropuerto(codigoAeropuertoOrigen)) {
            return Retorno.error3();
        }
        
        if (!existeAeropuerto(codigoAeropuertoDestino)) {
            return Retorno.error4();
        }
        
        if (buscarVuelo(codigoDeVuelo) != null) {
            return Retorno.error5();
        }
        
        vuelos.adicionar(new Vuelo(codigoAeropuertoOrigen, codigoAeropuertoDestino,
                                codigoDeVuelo, capacidad, costoEnDolares));
        return Retorno.ok();
    }

    @Override
    public Retorno obtenerInformacionDeVuelo(String codigoDeVuelo) {
        if (codigoDeVuelo == null || codigoDeVuelo.isBlank()) {
            return Retorno.error1();
        }

        Vuelo v = buscarVuelo(codigoDeVuelo);
        if (v == null) {
            return Retorno.error2();
        }   

        String valor = v.getCodigoAeropuertoOrigen() + ":" + v.getCodigoAeropuertoDestino() + ";" +
                       v.getCodigoDeVuelo() + ";" + v.getCapacidad() + ";" +
                       v.getCostoEnDolares() + ";" + v.getEstado().getTexto() + ";" +
                       v.getReservas().longitud() + ";" + v.getCheckIns().longitud();
        return Retorno.ok(valor);
    }
    
    @Override
    public Retorno abrirVuelo(String codigoDeVuelo) {
        if (codigoDeVuelo == null || codigoDeVuelo.isBlank()) {
            return Retorno.error1();
        }

        Vuelo v = buscarVuelo(codigoDeVuelo);
        if (v == null) {
            return Retorno.error2();
        }

        if (v.getEstado() != Estado.PROGRAMADO) {
            return Retorno.error3();
        }

        v.setEstado(Estado.ABIERTO);
            return Retorno.ok();
        }

    @Override
    public Retorno cerrarVuelo(String codigoDeVuelo) {
        if (codigoDeVuelo == null || codigoDeVuelo.isBlank()) {
            return Retorno.error1();
        }
        
        Vuelo v = buscarVuelo(codigoDeVuelo);
        if (v == null) {
            return Retorno.error2();
        }
        
        if (v.getEstado() != Estado.ABIERTO) {
            return Retorno.error3();
        }
        
        v.setEstado(Estado.CERRADO);
        
        Aeropuerto origen = buscarAeropuerto(v.getCodigoAeropuertoOrigen());
        if (origen != null) {
            origen.getColaVuelos().encolar(v);
        }
        
        StringBuilder sb = new StringBuilder();
        ListaSE<Pasajero> confirmados = v.getCheckIns();
        
        for (int i = 0; i < confirmados.longitud(); i++) {
            try {
                Pasajero p = confirmados.obtener(i);
                if (sb.length() > 0) sb.append("|");
                    sb.append(p.getCedula()).append(";").append(p.getNombre()).append(";")
                    .append(p.getEdad()).append(";")
                    .append(p.getCategoria().getTexto());
            } catch (Exception e) {}
        }
        int reservadosSinCheckIn = v.getReservas().longitud() - v.getCheckIns().longitud();
        return new Retorno(Retorno.Resultado.OK, sb.toString(), reservadosSinCheckIn);
    }

    @Override
    public Retorno realizarReserva(String codigoDeVuelo, String cedula) {
        
        if (codigoDeVuelo == null || codigoDeVuelo.isBlank() || cedula == null || cedula.isBlank()) 
        {
          return Retorno.error1();        
        }
    
        String regex = "^[1-9]\\.\\d{3}\\.\\d{3}-\\d$|^[1-9]\\d{2}\\.\\d{3}-\\d$";
        if (!cedula.matches(regex)) 
        {
           return Retorno.error2();
        }
        
        if (buscarVuelo(codigoDeVuelo) == null)
        {
           return Retorno.error3(); 
        }
        
        if (buscarPasajeroPorCedula(cedula) == null)
        {
           return Retorno.error4(); 
        }
        
        Vuelo v = buscarVuelo(codigoDeVuelo);
        
        if (v.getEstado() != Estado.PROGRAMADO && v.getEstado() != Estado.ABIERTO)
        {
           return Retorno.error5(); 
        }
        
        if (tieneReserva(v, cedula) || hizoCheckIn(v, cedula))
        {
            return Retorno.error6();
        }
        
        int maxReservas = (int) Math.ceil(v.getCapacidad() * 1.10);

        if (v.getReservas().longitud() >= maxReservas)
        {
          return Retorno.error7();
        } 
        
        Pasajero pasajero = buscarPasajeroPorCedula(cedula);

        v.getReservas().insertarOrdenado(pasajero);

        return Retorno.ok();
        
    }
 
    @Override
    public Retorno realizarCheckIn(String codigoDeVuelo, String cedula) {
        
        if (codigoDeVuelo == null || codigoDeVuelo.isBlank()|| cedula == null || cedula.isBlank())
        {
            return Retorno.error1();
        }
        
        String regex = "^[1-9]\\.\\d{3}\\.\\d{3}-\\d$|^[1-9]\\d{2}\\.\\d{3}-\\d$";
        if (!cedula.matches(regex)) 
        {
           return Retorno.error2();
        }
        
        Vuelo v = buscarVuelo(codigoDeVuelo);

        if (v == null)
        {
           return Retorno.error3();
        }
        
        Pasajero pasajero = buscarPasajeroPorCedula(cedula);

        if (pasajero == null)
        {
            return Retorno.error4();
        }
        
        if (v.getEstado() != Estado.ABIERTO)
        {
           return Retorno.error5(); 
        }
        
        if (!tieneReserva(v, cedula))
        {
            return Retorno.error6();
        }
        
        if (hizoCheckIn(v, cedula))
        {
            return Retorno.error7();
        }
        
        if (v.getCheckIns().longitud() >= v.getCapacidad())
        {
            return Retorno.error8();
        }
        
        v.getCheckIns().insertarOrdenado(pasajero);
        
        return Retorno.ok();
   }

    @Override
    public Retorno embarqueYDespegueDeVuelo(String codigoAeropuerto) {
       
      if (codigoAeropuerto == null || codigoAeropuerto.isBlank())
        {
            return Retorno.error1();
        }
        
      Aeropuerto aeropuerto = buscarAeropuerto(codigoAeropuerto);

      if (aeropuerto == null) 
        {
            return Retorno.error2();
        }
        
      if (aeropuerto.getColaVuelos().vacia())
        {
            return Retorno.error3();
        }
        
       Vuelo vuelo = aeropuerto.getColaVuelos().desencolar();
        
       vuelo.setEstado(Estado.FINALIZADO); 
        
       String codigoVuelo = vuelo.getCodigoDeVuelo();
       int restantes = aeropuerto.getColaVuelos().longitud();
       
        Retorno retorno = new Retorno(Retorno.Resultado.OK, codigoVuelo, restantes);
        
        return retorno;
    }
    
    @Override
    public Retorno consultaDisponibilidad(int[][] matriz, int cantidad, Clase unaClase) {

        if (cantidad <= 0) 
        {
            return Retorno.error1();
        }

        int inicio = 0;
        int fin = 0;

    switch (unaClase) {

        case PRIMERA:
            inicio = 0;
            fin = 2;
            break;

        case EJECUTIVA:
            inicio = 3;
            fin = 6;
            break;

        case TURISTA:
            inicio = 7;
            fin = 25;
            break;
    }

    StringBuilder listadoDisponibilidades = new StringBuilder();
    int opciones = 0;

    for (int columna = inicio; columna <= fin; columna++) {

        int[] filasLibres = new int[matriz.length];
        int cantLibres = 0;

        for (int fila = 0; fila < matriz.length; fila++) {

            if (matriz[fila][columna] == 0) {
                filasLibres[cantLibres] = fila;
                cantLibres++;
            }
        }

        for (int i = 0; i <= cantLibres - cantidad; i++) {

            if (listadoDisponibilidades.length() > 0) {
                listadoDisponibilidades.append("|");
            }

            for (int j = 0; j < cantidad; j++) {

                char filaActual = (char) ('A' + filasLibres[i + j]);

                listadoDisponibilidades.append(filaActual)
                                       .append(columna + 1);

                if (j < cantidad - 1) {
                    listadoDisponibilidades.append("-");
                }
            }

            opciones++;
        }
    }

    return new Retorno(Retorno.Resultado.OK, listadoDisponibilidades.toString(), opciones);
}



    //Metodos Auxiliares
    
    private Pasajero buscarPasajeroPorCedula(String cedula) {
        for (int i = 0; i < pasajeros.longitud(); i++) {
            try {
                Pasajero p = pasajeros.obtener(i);
                if (p.getCedula().equals(cedula)) {
                    return p;
                }
            } catch (Exception e) {}
        }
        return null;
    }
    
    private boolean existeAeropuerto(String codigo) {
        for (int i = 0; i < aeropuertos.longitud(); i++) {
            try {
                if (aeropuertos.obtener(i).getCodigo().equals(codigo)) {
                    return true;
                }
            } catch (Exception e) {}
        }
        return false;
    }
    
    private Vuelo buscarVuelo(String codigoDeVuelo) {
        for (int i = 0; i < vuelos.longitud(); i++) {
            try {
                Vuelo v = vuelos.obtener(i);
                if (v.getCodigoDeVuelo().equals(codigoDeVuelo)) {
                    return v;
                }
            } catch (Exception e) {}
        }
        return null;
    }
    
    private Aeropuerto buscarAeropuerto(String codigo) {
        for (int i = 0; i < aeropuertos.longitud(); i++) {
            try {
                Aeropuerto a = aeropuertos.obtener(i);
                if (a.getCodigo().equals(codigo)) {
                    return a;
                }
            } catch (Exception e) {}
        }
        return null;
    }

    private boolean tieneReserva(Vuelo vuelo, String cedula) {

    for (int i = 0; i < vuelo.getReservas().longitud(); i++) {
        try {
            Pasajero p = vuelo.getReservas().obtener(i);

            if (p.getCedula().equals(cedula)) {
                return true;
            }

        } catch (Exception e) {
        }
    }

        return false;
    }
    
    private boolean hizoCheckIn(Vuelo vuelo, String cedula) {

    for (int i = 0; i < vuelo.getCheckIns().longitud(); i++) {
        try {
            Pasajero p = vuelo.getCheckIns().obtener(i);

            if (p.getCedula().equals(cedula)) {
                return true;
            }

        } catch (Exception e) {
        }
    }
        return false;
    }
}
