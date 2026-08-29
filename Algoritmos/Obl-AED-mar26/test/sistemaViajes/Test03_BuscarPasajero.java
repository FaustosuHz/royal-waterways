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

public class Test03_BuscarPasajero {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void buscarPasajeroOk() {
        retorno = s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        retorno = s.buscarPasajero("3.335.321-2");
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("3.335.321-2;Juan;45;Esporádico", retorno.getValorString());
    }

    @Test
    public void buscarPasajeroError01() {
        retorno = s.buscarPasajero("3..321-2");
        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void buscarPasajeroError02() {
        retorno = s.buscarPasajero("5.365.221-1");
        assertEquals(Retorno.Resultado.ERROR_2, retorno.getResultado());
    }

}
