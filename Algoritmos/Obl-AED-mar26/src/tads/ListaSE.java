package tads;

public class ListaSE<T extends Comparable<T>> implements ILista<T> {

    protected NodoSE<T> cabeza;
    protected int longitud;

    public ListaSE() {
        cabeza = null;
        longitud = 0;
    }

    @Override
    public void adicionar(T x) {

        NodoSE<T> elem = new NodoSE<>(x);

        if (vacia()) {

            cabeza = elem;

        } else {

            NodoSE<T> aux = cabeza;

            while (aux.getSiguiente() != null) {
                aux = aux.getSiguiente();
            }

            aux.setSiguiente(elem);
        }

        longitud++;
    }

    @Override
    public void insertar(T x, int pos) throws Exception {

        if (pos < 0 || pos > longitud) {
            throw new Exception("Posición fuera de rango");
        }

        NodoSE<T> nodo = new NodoSE<>(x, null);

        if (pos == 0) {

            nodo.setSiguiente(cabeza);
            cabeza = nodo;

        } else {

            NodoSE<T> cursor = cabeza;

            int i = 0;

            while (i < pos - 1) {
                cursor = cursor.getSiguiente();
                i++;
            }

            nodo.setSiguiente(cursor.getSiguiente());
            cursor.setSiguiente(nodo);
        }

        longitud++;
    }

    @Override
    public T obtener(int pos) throws Exception {

        if (vacia()) {
            throw new Exception("Lista vacía");
        }

        if (pos < 0 || pos >= longitud) {
            throw new Exception("Posición fuera de rango");
        }

        NodoSE<T> aux = cabeza;

        int i = 0;

        while (i < pos) {
            aux = aux.getSiguiente();
            i++;
        }

        return aux.getDato();
    }

    @Override
    public void eliminar(int pos) throws Exception {

        if (vacia()) {
            throw new Exception("Lista vacía");
        }

        if (pos < 0 || pos >= longitud) {
            throw new Exception("Posición fuera de rango");
        }

        if (pos == 0) {

            cabeza = cabeza.getSiguiente();

        } else {

            NodoSE<T> aux = cabeza;

            int i = 0;

            while (i < pos - 1) {
                aux = aux.getSiguiente();
                i++;
            }

            aux.setSiguiente(aux.getSiguiente().getSiguiente());
        }

        longitud--;
    }

    @Override
    public int longitud() {
        return longitud;
    }

    @Override
    public boolean vacia() {
        return (longitud == 0);
    }

    public void adicionarInicio(T elem) {

        NodoSE<T> nuevo = new NodoSE<>(elem);

        nuevo.setSiguiente(cabeza);

        cabeza = nuevo;

        longitud++;
    }

    public boolean existeElemento(T elem) {

        NodoSE<T> aux = cabeza;

        while (aux != null) {

            if (aux.getDato().compareTo(elem) == 0) {
                return true;
            }

            aux = aux.getSiguiente();
        }

        return false;
    }

    public void eliminarInicio() {

        if (!vacia()) {

            cabeza = cabeza.getSiguiente();

            longitud--;
        }
    }

    public void eliminarFinal() {

        if (!vacia()) {

            if (longitud == 1) {

                cabeza = null;

            } else {

                NodoSE<T> aux = cabeza;

                while (aux.getSiguiente().getSiguiente() != null) {
                    aux = aux.getSiguiente();
                }

                aux.setSiguiente(null);
            }

            longitud--;
        }
    }

    public void invertirIterativo() {

        NodoSE<T> anterior = null;
        NodoSE<T> actual = cabeza;
        NodoSE<T> siguiente;

        while (actual != null) {

            siguiente = actual.getSiguiente();

            actual.setSiguiente(anterior);

            anterior = actual;

            actual = siguiente;
        }

        cabeza = anterior;
    }

    public void invertirRecursivo() {

    }

    public boolean estaOrdenada() {

        if (vacia() || longitud == 1) {
            return true;
        }

        NodoSE<T> aux = cabeza;

        while (aux.getSiguiente() != null) {

            if (aux.getDato().compareTo(aux.getSiguiente().getDato()) > 0) {
                return false;
            }

            aux = aux.getSiguiente();
        }

        return true;
    }

    public void insertarOrdenado(T elem) {

        NodoSE<T> nuevo = new NodoSE<>(elem);

        if (vacia() || cabeza.getDato().compareTo(elem) > 0) {

            nuevo.setSiguiente(cabeza);

            cabeza = nuevo;

        } else {

            NodoSE<T> aux = cabeza;

            while (aux.getSiguiente() != null &&
                   aux.getSiguiente().getDato().compareTo(elem) < 0) {

                aux = aux.getSiguiente();
            }

            nuevo.setSiguiente(aux.getSiguiente());

            aux.setSiguiente(nuevo);
        }

        longitud++;
    }

    public int contar(T elem) {

        int contador = 0;

        NodoSE<T> aux = cabeza;

        while (aux != null) {

            if (aux.getDato().compareTo(elem) == 0) {
                contador++;
            }

            aux = aux.getSiguiente();
        }

        return contador;
    }

    public T maximo() {

        if (vacia()) {
            return null;
        }

        T max = cabeza.getDato();

        NodoSE<T> aux = cabeza.getSiguiente();

        while (aux != null) {

            if (aux.getDato().compareTo(max) > 0) {
                max = aux.getDato();
            }

            aux = aux.getSiguiente();
        }

        return max;
    }

    public ListaSE<T> cambiar(T n, T m) {

        NodoSE<T> aux = cabeza;

        while (aux != null) {

            if (aux.getDato().compareTo(n) == 0) {
                aux.setDato(m);
            }

            aux = aux.getSiguiente();
        }

        return this;
    }
}


