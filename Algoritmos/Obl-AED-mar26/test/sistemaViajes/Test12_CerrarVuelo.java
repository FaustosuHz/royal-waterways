package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test12_CerrarVuelo {

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
    }

    @Test
    public void cerrarVueloOkSinReservas() {
        s.abrirVuelo("UX001");

        retorno = s.cerrarVuelo("UX001");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("", retorno.getValorString());
        assertEquals(0, retorno.getValorEntero());
    }

    @Test
    public void cerrarVueloOkConCheckIns() {
        s.realizarReserva("UX001", "3.335.321-2");
        s.realizarReserva("UX001", "935.457-7");

        s.abrirVuelo("UX001");

        s.realizarCheckIn("UX001", "3.335.321-2");

        retorno = s.cerrarVuelo("UX001");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals(
                "3.335.321-2;Juan;45;Esporádico",
                retorno.getValorString()
        );
        assertEquals(1, retorno.getValorEntero());
    }

    @Test
    public void cerrarVueloError01() {
        retorno = s.cerrarVuelo("");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.cerrarVuelo(null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.cerrarVuelo("   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void cerrarVueloError02() {
        retorno = s.cerrarVuelo("UX999");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void cerrarVueloError03() {
        retorno = s.cerrarVuelo("UX001");

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }
}