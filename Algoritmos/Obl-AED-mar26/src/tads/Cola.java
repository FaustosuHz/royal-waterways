/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package tads;

/**
 *
 * @author HP
 */
public class Cola<T extends Comparable<T>> {
    private final ListaSE<T> lista;
    
    public Cola() {
        lista = new ListaSE<>();
    }
    
    public void encolar(T elem) {
        lista.adicionar(elem);
    }
    
    public T desencolar() {
        
        if (vacia()) return null;
        T dato = lista.cabeza.getDato();
        lista.eliminarInicio();
        return dato;
    }
    
    public boolean vacia() {
        return lista.vacia();
    }
    
    public int longitud() {
        return lista.longitud();
    }
    
}
