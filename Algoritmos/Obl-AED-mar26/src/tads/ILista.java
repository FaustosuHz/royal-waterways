package tads;

public interface ILista<T> {

    void adicionar(T x);

    void insertar(T x, int pos) throws Exception;

    T obtener(int pos) throws Exception;

    void eliminar(int pos) throws Exception;

    int longitud();

    boolean vacia();
}