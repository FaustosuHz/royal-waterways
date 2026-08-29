package sistemaViajes;

import sistemaViajes.Retorno;
import sistemaViajes.ImplementacionSistema;
import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import static org.junit.Assert.*;
import sistemaViajes.Sistema;
import sistemaViajes.Sistema;

public class Test04_ListarPasajeros {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void listarPasajerosVacio() {
        retorno = s.listarPasajerosAscendente();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("", retorno.getValorString());
    }

    @Test
    public void listarPasajerosAscendenteSoloUnUsuario() {
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        retorno = s.listarPasajerosAscendente();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("3.335.321-2;Juan;45;Esporádico", retorno.getValorString());
    }

    @Test
    public void listarPasajerosAscendenteIngresoOrdenado() {
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);        
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);
        retorno = s.listarPasajerosAscendente();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("935.457-7;Maria;82;Platino|3.335.321-2;Juan;45;Esporádico|6.430.147-9;Nicolas;0;Estándar", retorno.getValorString());
    }

    @Test
    public void listarPasajerosAscendenteIngresoDesordenado() {
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);
         s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);        
        retorno = s.listarPasajerosAscendente();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("935.457-7;Maria;82;Platino|3.335.321-2;Juan;45;Esporádico|6.430.147-9;Nicolas;0;Estándar", retorno.getValorString());
    }

}
