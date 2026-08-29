package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test11_AbrirVuelo {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");

        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);
    }

    @Test
    public void abrirVueloOk() {
        retorno = s.abrirVuelo("UX001");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());

        retorno = s.obtenerInformacionDeVuelo("UX001");

        assertEquals(
                "MVD:EZE;UX001;100;500;Abierto;0;0",
                retorno.getValorString()
        );
    }

    @Test
    public void abrirVueloError01() {
        retorno = s.abrirVuelo("");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.abrirVuelo(null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.abrirVuelo("   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void abrirVueloError02() {
        retorno = s.abrirVuelo("UX999");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

    @Test
    public void abrirVueloError03() {
        s.abrirVuelo("UX001");

        retorno = s.abrirVuelo("UX001");

        assertEquals(Retorno.Resultado.ERROR_3, retorno.getResultado());
    }
}