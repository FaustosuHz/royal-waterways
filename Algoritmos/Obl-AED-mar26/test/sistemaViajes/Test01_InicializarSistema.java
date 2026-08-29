package sistemaViajes;

import org.junit.Test;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;
import static org.junit.Assert.*;

public class Test01_InicializarSistema {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    @Test
    public void inicializarSistemaOk() {
        retorno = s.inicializarSistema();
        assertEquals(Retorno.Resultado.OK, retorno.getResultado());    
    }
}
