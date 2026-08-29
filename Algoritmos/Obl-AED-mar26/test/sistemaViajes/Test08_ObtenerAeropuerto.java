package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test08_ObtenerAeropuerto {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void obtenerAeropuertoOk() {
        s.registrarAeropuerto("MVD", "Carrasco");

        retorno = s.obtenerAeropuerto("MVD");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("MVD;Carrasco", retorno.getValorString());
        assertEquals(0, retorno.getValorEntero());
    }

    @Test
    public void obtenerAeropuertoConVuelosEnCola() {
        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");

        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);
        s.abrirVuelo("UX001");
        s.cerrarVuelo("UX001");

        retorno = s.obtenerAeropuerto("MVD");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("MVD;Carrasco", retorno.getValorString());
        assertEquals(1, retorno.getValorEntero());
    }

    @Test
    public void obtenerAeropuertoError01() {
        retorno = s.obtenerAeropuerto("");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.obtenerAeropuerto(null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.obtenerAeropuerto("   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void obtenerAeropuertoError02() {
        retorno = s.obtenerAeropuerto("MVD");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }
}