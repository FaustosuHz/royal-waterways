package sistemaViajes;

import org.junit.Before;
import org.junit.Test;
import sistemaViajes.Clase;
import sistemaViajes.ImplementacionSistema;
import sistemaViajes.Retorno;
import sistemaViajes.Sistema;

import static org.junit.Assert.*;

public class Test16_ConsultaDisponibilidad {

    private Retorno retorno;
    private final Sistema s = new ImplementacionSistema();

    private static final int D = 0; // disponible
    private static final int O = 1; // ocupado
    private static final int N = 2; // no disponible

    @Before
    public void setUp() {
        s.inicializarSistema();
    }

    @Test
    public void consultaDisponibilidadError1CantidadCero() {

        int[][] asientos = new int[6][27];

        retorno = s.consultaDisponibilidad(asientos, 0, Clase.PRIMERA);

        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void consultaDisponibilidadError1CantidadNegativa() {

        int[][] asientos = new int[6][27];

        retorno = s.consultaDisponibilidad(asientos, -5, Clase.PRIMERA);

        assertEquals(Retorno.Resultado.ERROR_1, retorno.getResultado());
    }

    @Test
    public void consultaDisponibilidadPrimeraClaseCantidad2() {

        final int[][] asientos = {

                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D}
        };

        retorno = s.consultaDisponibilidad(asientos, 2, Clase.PRIMERA);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());

        assertEquals(
                "A1-C1|C1-D1|D1-F1|A2-C2|C2-D2|D2-F2|A3-C3|C3-D3|D3-F3",
                retorno.getValorString()
        );

        assertEquals(9, retorno.getValorEntero());
    }

    @Test
    public void consultaDisponibilidadPrimeraClaseLlena() {

        final int[][] asientos = {

                {O,O,O,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {O,O,O,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {O,O,O,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {O,O,O,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D}
        };

        retorno = s.consultaDisponibilidad(asientos, 1, Clase.PRIMERA);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());
        assertEquals("", retorno.getValorString());
        assertEquals(0, retorno.getValorEntero());
    }

    @Test
    public void consultaDisponibilidadEjecutivaCantidad6() {

        final int[][] asientos = {

                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D}
        };

        retorno = s.consultaDisponibilidad(asientos, 6, Clase.EJECUTIVA);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());

        assertEquals(
                "A4-B4-C4-D4-E4-F4|A5-B5-C5-D5-E5-F5|A6-B6-C6-D6-E6-F6|A7-B7-C7-D7-E7-F7",
                retorno.getValorString()
        );

        assertEquals(4, retorno.getValorEntero());
    }

    @Test
    public void consultaDisponibilidadTuristaCantidad6() {

        final int[][] asientos = {

                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {N,N,N,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D},
                {D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D,D}
        };

        retorno = s.consultaDisponibilidad(asientos, 6, Clase.TURISTA);

        assertEquals(Retorno.Resultado.OK, retorno.getResultado());

        assertEquals(
                "A8-B8-C8-D8-E8-F8|A9-B9-C9-D9-E9-F9|A10-B10-C10-D10-E10-F10|A11-B11-C11-D11-E11-F11|A12-B12-C12-D12-E12-F12|A13-B13-C13-D13-E13-F13|A14-B14-C14-D14-E14-F14|A15-B15-C15-D15-E15-F15|A16-B16-C16-D16-E16-F16|A17-B17-C17-D17-E17-F17|A18-B18-C18-D18-E18-F18|A19-B19-C19-D19-E19-F19|A20-B20-C20-D20-E20-F20|A21-B21-C21-D21-E21-F21|A22-B22-C22-D22-E22-F22|A23-B23-C23-D23-E23-F23|A24-B24-C24-D24-E24-F24|A25-B25-C25-D25-E25-F25|A26-B26-C26-D26-E26-F26",
                retorno.getValorString()
        );

        assertEquals(19, retorno.getValorEntero());
    }
}