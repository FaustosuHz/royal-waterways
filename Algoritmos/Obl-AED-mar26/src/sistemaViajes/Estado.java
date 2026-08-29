package sistemaViajes;

import java.util.Arrays;
import java.util.Objects;

public enum Estado {
    PROGRAMADO(0, "Programado"),
    ABIERTO(1, "Abierto"),
    CERRADO(2, "Cerrrado"),
    FINALIZADO(3, "Finalizado");    

    private final int indice;
    private final String texto;

    Estado(int indice, String texto) {
        this.indice = indice;
        this.texto = texto;
    }

    public int getIndice() {
        return indice;
    }

    public String getTexto() {
        return texto;
    }

    public static Estado fromTexto(String texto) {
        return Arrays.stream(Estado.values())
                .filter(a -> Objects.equals(a.texto, texto))
                .findFirst()
                .orElse(null);
    }

}
