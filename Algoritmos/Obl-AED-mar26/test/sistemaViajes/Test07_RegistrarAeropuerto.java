package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test07_RegistrarAeropuerto {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void registrarAeropuertoOk() {
        retorno = s.registrarAeropuerto("MVD", "Carrasco");
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());

        retorno = s.registrarAeropuerto("EZE", "Ezeiza");
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
    }

    @Test
    public void registrarAeropuertoError01() {
        retorno = s.registrarAeropuerto("", "Carrasco");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarAeropuerto("MVD", "");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarAeropuerto(null, "Carrasco");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarAeropuerto("MVD", null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarAeropuerto("   ", "Carrasco");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.registrarAeropuerto("MVD", "   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void registrarAeropuertoError02() {
        s.registrarAeropuerto("MVD", "Carrasco");

        retorno = s.registrarAeropuerto("MVD", "Otro Aeropuerto");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }
}