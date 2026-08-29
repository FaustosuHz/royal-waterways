package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test09_RegistrarVuelo {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");
    }

    @Test
    public void registrarVueloOk() {
        retorno = s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
    }

    @Test
    public void registrarVueloError01() {
        retorno = s.registrarVuelo("MVD", "EZE", "UX001", 0, 500);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "EZE", "UX001", -1, 500);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "EZE", "UX001", 100, 0);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "EZE", "UX001", 100, -1);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void registrarVueloError02() {
        retorno = s.registrarVuelo("", "EZE", "UX001", 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "", "UX001", 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "EZE", "", 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());

        retorno = s.registrarVuelo(null, "EZE", "UX001", 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", null, "UX001", 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());

        retorno = s.registrarVuelo("MVD", "EZE", null, 100, 500);
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void registrarVueloError03() {
        retorno = s.registrarVuelo("XXX", "EZE", "UX001", 100, 500);

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }

    @Test
    public void registrarVueloError04() {
        retorno = s.registrarVuelo("MVD", "XXX", "UX001", 100, 500);

        assertEquals(Retorno.Resultado.ERROR_4, retorno.getResultado());
    }

    @Test
    public void registrarVueloError05() {
        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);

        retorno = s.registrarVuelo("MVD", "EZE", "UX001", 200, 700);

        assertEquals(Retorno.Resultado.ERROR_5, retorno.getResultado());
    }
}