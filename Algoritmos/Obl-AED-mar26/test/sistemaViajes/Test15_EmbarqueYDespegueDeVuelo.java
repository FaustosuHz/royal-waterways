package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test15_EmbarqueYDespegueDeVuelo {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");

        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);
        s.registrarVuelo("MVD", "EZE", "UX002", 100, 600);

        s.abrirVuelo("UX001");
        s.cerrarVuelo("UX001");

        s.abrirVuelo("UX002");
        s.cerrarVuelo("UX002");
    }

    @Test
    public void embarqueYDespegueDeVueloOk() {
        retorno = s.embarqueYDespegueDeVuelo("MVD");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("UX001", retorno.getValorString());
        assertEquals(1, retorno.getValorEntero());
    }

    @Test
    public void embarqueYDespegueDeVueloSegundoVuelo() {
        s.embarqueYDespegueDeVuelo("MVD");

        retorno = s.embarqueYDespegueDeVuelo("MVD");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("UX002", retorno.getValorString());
        assertEquals(0, retorno.getValorEntero());
    }

    @Test
    public void embarqueYDespegueDeVueloError01() {
        retorno = s.embarqueYDespegueDeVuelo("");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.embarqueYDespegueDeVuelo(null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.embarqueYDespegueDeVuelo("   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void embarqueYDespegueDeVueloError02() {
        retorno = s.embarqueYDespegueDeVuelo("XXX");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void embarqueYDespegueDeVueloError03() {
        s.inicializarSistema();
        s.registrarAeropuerto("MVD", "Carrasco");

        retorno = s.embarqueYDespegueDeVuelo("MVD");

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }
}