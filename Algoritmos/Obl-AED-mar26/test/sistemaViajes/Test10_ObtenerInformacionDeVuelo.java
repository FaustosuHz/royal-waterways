package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test10_ObtenerInformacionDeVuelo {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();

        s.registrarAeropuerto("MVD", "Carrasco");
        s.registrarAeropuerto("EZE", "Ezeiza");
    }

    @Test
    public void obtenerInformacionDeVueloOk() {
        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);

        retorno = s.obtenerInformacionDeVuelo("UX001");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals(
                "MVD:EZE;UX001;100;500;Programado;0;0",
                retorno.getValorString()
        );
    }

    @Test
    public void obtenerInformacionDeVueloConReservasYCheckIns() {
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);

        s.registrarVuelo("MVD", "EZE", "UX001", 100, 500);
        s.abrirVuelo("UX001");
        s.realizarReserva("UX001", "3.335.321-2");
        s.realizarCheckIn("UX001", "3.335.321-2");

        retorno = s.obtenerInformacionDeVuelo("UX001");

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals(
                "MVD:EZE;UX001;100;500;Abierto;1;1",
                retorno.getValorString()
        );
    }

    @Test
    public void obtenerInformacionDeVueloError01() {
        retorno = s.obtenerInformacionDeVuelo("");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.obtenerInformacionDeVuelo(null);
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());

        retorno = s.obtenerInformacionDeVuelo("   ");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void obtenerInformacionDeVueloError02() {
        retorno = s.obtenerInformacionDeVuelo("UX999");

        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }
}