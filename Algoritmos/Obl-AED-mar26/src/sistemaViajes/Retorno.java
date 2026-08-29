package sistemaViajes;

public class Retorno {

    public enum Resultado {
        OK, ERROR_1, ERROR_2, ERROR_3, ERROR_4, ERROR_5, ERROR_6, ERROR_7, ERROR_8, NO_IMPLEMENTADA
    };
    private int valorEntero;
    private String valorString;
    private boolean valorbooleano;
    private Resultado resultado;

    public Retorno(Resultado resultado) {
        this.resultado = resultado;
    }

    public Retorno(Resultado resultado, String valorString) {
        this.resultado = resultado;
        this.valorString = valorString;
    }

    public Retorno(Resultado resultado, String valorString, int valorEntero) {
        this.valorEntero = valorEntero;
        this.valorString = valorString;
        this.resultado = resultado;
    }

    public Retorno(Resultado resultado, String valorString, int valorEntero, boolean valorbooleano) {
        this.valorEntero = valorEntero;
        this.valorString = valorString;
        this.valorbooleano = valorbooleano;
        this.resultado = resultado;
    }
    
    public int getValorEntero() {
        return valorEntero;
    }

    public String getValorString() {
        return valorString;
    }

    public boolean isValorbooleano() {
        return valorbooleano;
    }

    public Resultado getResultado() {
        return resultado;
    }

    public static Retorno noImplementada() {
        return new Retorno(Resultado.NO_IMPLEMENTADA);
    }

    public static Retorno ok() {
        return new Retorno(Resultado.OK);
    }

    public static Retorno ok(String valorString) {
        return new Retorno(Resultado.OK, valorString);
    }
    
    public static Retorno ok(int valorInt) {
        return new Retorno(Resultado.OK, "", valorInt);
    }

    public static Retorno error1() {
        return new Retorno(Resultado.ERROR_1);
    }

    public static Retorno error2() {
        return new Retorno(Resultado.ERROR_2);
    }

    public static Retorno error3() {
        return new Retorno(Resultado.ERROR_3);
    }

    public static Retorno error4() {
        return new Retorno(Resultado.ERROR_4);
    }

    public static Retorno error5() {
        return new Retorno(Resultado.ERROR_5);
    }

    public static Retorno error6() {
    return new Retorno(Resultado.ERROR_6);
    }

    public static Retorno error7() {
    return new Retorno(Resultado.ERROR_7);
    }

    public static Retorno error8() {
    return new Retorno(Resultado.ERROR_8);
    }
}
