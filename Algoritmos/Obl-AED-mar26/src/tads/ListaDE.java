package tads;

public class ListaDE<T extends Comparable<T>> implements ILista<T> {

    protected NodoDE<T> cabeza;
    protected int longitud;

    public ListaDE() {
        cabeza = null;
        longitud = 0;
    }

    @Override
    public void adicionar(T x) {

    }

    @Override
    public void insertar(T x, int pos) throws Exception {

    }

    @Override
    public T obtener(int pos) throws Exception {
        return null;
    }

    @Override
    public void eliminar(int pos) throws Exception {

    }

    @Override
    public int longitud() {
        return longitud;
    }

    @Override
    public boolean vacia() {
        return (longitud == 0);
    }

    public void eliminarInicio() {

    }

    public void invertirIterativo() {

    }

    public void insertarOrdenado(T elem) {

    }

}