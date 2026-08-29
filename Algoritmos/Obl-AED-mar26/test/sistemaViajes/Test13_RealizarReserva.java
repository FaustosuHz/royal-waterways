package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test13_RealizarReserva {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");

        s.registrarVuelo("MVD", "EZE", "UX001", 10, 500);

        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
    }

    @Test
    public void realizarReservaOk() {
        retorno = s.realizarReserva("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
    }

    @Test
    public void realizarReservaError01() {
        retorno = s.realizarReserva("", "3.335.321-2");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarReserva("UX001", "");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarReserva(null, "3.335.321-2");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarReserva("UX001", null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void realizarReservaError02() {
        retorno = s.realizarReserva("UX001", "123");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void realizarReservaError03() {
        retorno = s.realizarReserva("UX999", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }

    @Test
    public void realizarReservaError04() {
        retorno = s.realizarReserva("UX001", "5.555.555-5");

        assertEquals(Retorno.Resultado.ERROR_4, retorno.getResultado());
    }

    @Test
    public void realizarReservaError05() {
        s.abrirVuelo("UX001");
        s.cerrarVuelo("UX001");

        retorno = s.realizarReserva("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_5, retorno.getResultado());
    }

    @Test
    public void realizarReservaError06PorReservaExistente() {
        s.realizarReserva("UX001", "3.335.321-2");

        retorno = s.realizarReserva("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_6, retorno.getResultado());
    }

    @Test
    public void realizarReservaError06PorCheckInExistente() {
        s.realizarReserva("UX001", "3.335.321-2");
        s.abrirVuelo("UX001");
        s.realizarCheckIn("UX001", "3.335.321-2");

        retorno = s.realizarReserva("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_6, retorno.getResultado());
    }

    @Test
    public void realizarReservaError07() {
        s.registrarPasajero("1.111.111-1", "A", 20, Categoria.PLATINO);
        s.registrarPasajero("2.222.222-2", "B", 20, Categoria.PLATINO);
        s.registrarPasajero("4.444.444-4", "C", 20, Categoria.PLATINO);
        s.registrarPasajero("5.555.555-5", "D", 20, Categoria.PLATINO);
        s.registrarPasajero("6.666.666-6", "E", 20, Categoria.PLATINO);
        s.registrarPasajero("7.777.777-7", "F", 20, Categoria.PLATINO);
        s.registrarPasajero("8.888.888-8", "G", 20, Categoria.PLATINO);
        s.registrarPasajero("9.999.999-9", "H", 20, Categoria.PLATINO);
        s.registrarPasajero("1.234.567-8", "I", 20, Categoria.PLATINO);

        s.realizarReserva("UX001", "3.335.321-2");
        s.realizarReserva("UX001", "935.457-7");
        s.realizarReserva("UX001", "1.111.111-1");
        s.realizarReserva("UX001", "2.222.222-2");
        s.realizarReserva("UX001", "4.444.444-4");
        s.realizarReserva("UX001", "5.555.555-5");
        s.realizarReserva("UX001", "6.666.666-6");
        s.realizarReserva("UX001", "7.777.777-7");
        s.realizarReserva("UX001", "8.888.888-8");
        s.realizarReserva("UX001", "9.999.999-9");
        s.realizarReserva("UX001", "1.234.567-8");

        s.registrarPasajero("3.123.123-3", "Z", 20, Categoria.PLATINO);

        retorno = s.realizarReserva("UX001", "3.123.123-3");

        assertEquals(Retorno.Resultado.ERROR_7, retorno.getResultado());
    }
}