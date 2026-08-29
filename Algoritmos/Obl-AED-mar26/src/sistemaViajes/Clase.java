package sistemaViajes;

import java.util.Arrays;
import java.util.Objects;

public enum Clase {
    PRIMERA(0, "Primera Clase"),
    EJECUTIVA(1, "Clase Ejecutiva"),
    TURISTA(2, "Clase Turista");

    private final int indice;
    private final String texto;

    Clase(int indice, String texto) {
        this.indice = indice;
        this.texto = texto;
    }

    public int getIndice() {
        return indice;
    }

    public String getTexto() {
        return texto;
    }

    public static Clase fromTexto(String texto) {
        return Arrays.stream(Clase.values())
                .filter(a -> Objects.equals(a.texto, texto))
                .findFirst()
                .orElse(null);
    }

}
