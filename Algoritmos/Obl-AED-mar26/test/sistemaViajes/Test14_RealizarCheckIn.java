package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test14_RealizarCheckIn {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");

        s.registrarVuelo("MVD", "EZE", "UX001", 2, 500);

        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);

        s.realizarReserva("UX001", "3.335.321-2");
        s.realizarReserva("UX001", "935.457-7");

        s.abrirVuelo("UX001");
    }

    @Test
    public void realizarCheckInOk() {
        retorno = s.realizarCheckIn("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError01() {
        retorno = s.realizarCheckIn("", "3.335.321-2");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarCheckIn("UX001", "");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarCheckIn(null, "3.335.321-2");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.realizarCheckIn("UX001", null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError02() {
        retorno = s.realizarCheckIn("UX001", "123");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError03() {
        retorno = s.realizarCheckIn("UX999", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError04() {
        retorno = s.realizarCheckIn("UX001", "5.555.555-5");

        assertEquals(Retorno.Resultado.ERROR_4, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError05() {
        s.cerrarVuelo("UX001");

        retorno = s.realizarCheckIn("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_5, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError06() {
        s.registrarPasajero("1.111.111-1", "Pedro", 30, Categoria.ESTANDAR);

        retorno = s.realizarCheckIn("UX001", "1.111.111-1");

        assertEquals(Retorno.Resultado.ERROR_6, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError07() {
        s.realizarCheckIn("UX001", "3.335.321-2");

        retorno = s.realizarCheckIn("UX001", "3.335.321-2");

        assertEquals(Retorno.Resultado.ERROR_7, retorno.getResultado());
    }

    @Test
    public void realizarCheckInError08() {
        s.realizarCheckIn("UX001", "3.335.321-2");
        s.realizarCheckIn("UX001", "935.457-7");

        s.registrarPasajero("1.111.111-1", "Pedro", 30, Categoria.ESTANDAR);
        s.realizarReserva("UX001", "1.111.111-1");

        retorno = s.realizarCheckIn("UX001", "1.111.111-1");

        assertEquals(Retorno.Resultado.ERROR_8, retorno.getResultado());
    }
}