package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test05_ListarPasajerosDescendente {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void listarPasajerosDescendenteVacio() {
        retorno = s.listarPasajerosDescendente();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("", retorno.getValorString());
    }

    @Test
    public void listarPasajerosDescendenteSoloUnUsuario() {
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);

        retorno = s.listarPasajerosDescendente();

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("3.335.321-2;Juan;45;Esporádico", retorno.getValorString());
    }

    @Test
    public void listarPasajerosDescendenteIngresoOrdenado() {
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);

        retorno = s.listarPasajerosDescendente();

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("6.430.147-9;Nicolas;0;Estándar|3.335.321-2;Juan;45;Esporádico|935.457-7;Maria;82;Platino", retorno.getValorString());
    }

    @Test
    public void listarPasajerosDescendenteIngresoDesordenado() {
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);

        retorno = s.listarPasajerosDescendente();

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("6.430.147-9;Nicolas;0;Estándar|3.335.321-2;Juan;45;Esporádico|935.457-7;Maria;82;Platino", retorno.getValorString());
    }
}