package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Categoria;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test06_ListarPasajerosPorCategoria {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void listarPasajerosPorCategoriaVacio() {
        retorno = s.listarPasajerosPorCategoría(Categoria.PLATINO);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("", retorno.getValorString());
    }

    @Test
    public void listarPasajerosPorCategoriaPlatino() {
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);

        retorno = s.listarPasajerosPorCategoría(Categoria.PLATINO);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("935.457-7;Maria;82;Platino", retorno.getValorString());
    }

    @Test
    public void listarPasajerosPorCategoriaEstandar() {
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);
        s.registrarPasajero("6.430.147-9", "Nicolas", 0, Categoria.ESTANDAR);

        retorno = s.listarPasajerosPorCategoría(Categoria.ESTANDAR);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("6.430.147-9;Nicolas;0;Estándar", retorno.getValorString());
    }

    @Test
    public void listarPasajerosPorCategoriaMultiples() {
        s.registrarPasajero("935.457-7", "Maria", 82, Categoria.PLATINO);
        s.registrarPasajero("1.111.111-1", "Ana", 25, Categoria.PLATINO);
        s.registrarPasajero("3.335.321-2", "Juan", 45, Categoria.ESPORADICO);

        retorno = s.listarPasajerosPorCategoría(Categoria.PLATINO);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals(
                "935.457-7;Maria;82;Platino|1.111.111-1;Ana;25;Platino",
                retorno.getValorString()
        );
    }
}