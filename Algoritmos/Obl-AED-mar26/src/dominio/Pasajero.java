/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

/**
 *
 * @author HP
 */
public class Pasajero implements Comparable<Pasajero> {
    private String cedula;
    private String nombre;
    private int edad;
    private sistemaViajes.Categoria categoria;
    
    public Pasajero(String cedula, String nombre, int edad, sistemaViajes.Categoria categoria) {
        this.cedula = cedula;
        this.nombre = nombre;
        this.edad = edad;
        this.categoria = categoria;
    }
    
    public String getCedula() {
        return cedula;
    }

    public String getNombre() {
        return nombre;
    }

    public int getEdad() {
        return edad;
    }
    
    public sistemaViajes.Categoria getCategoria() {
        return categoria;
    }
    
    @Override
    public int compareTo(Pasajero otro) {
        long miNumero = Long.parseLong(this.cedula.replaceAll("[^\\d]", ""));
        long otroNumero = Long.parseLong(otro.cedula.replaceAll("[^\\d]", ""));
        return Long.compare(miNumero, otroNumero);
    }
}
