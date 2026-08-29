/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;
import tads.Cola;
/**
 *
 * @author HP
 */
public class Aeropuerto implements Comparable<Aeropuerto> {
    private String codigo;
    private String nombre;
    private Cola<Vuelo> colaVuelos;
    
    public Aeropuerto(String codigo, String nombre) {
        this.codigo = codigo;
        this.nombre = nombre;
        this.colaVuelos = new Cola<>();
    }
    
    public String getCodigo() {
        return codigo;
    }
    
    public String getNombre() {
        return nombre;
    }
    
    public Cola<Vuelo> getColaVuelos() {
        return colaVuelos;
    }
    
    @Override
    public int compareTo(Aeropuerto otro) {
        return this.codigo.compareTo(otro.codigo);
    }
}
