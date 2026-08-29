/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dominio;

import sistemaViajes.Estado;
import tads.ListaSE;
/**
 *
 * @author HP
 */
public class Vuelo implements Comparable<Vuelo> {
    private String codigoAeropuertoOrigen;
    private String codigoAeropuertoDestino;
    private String codigoDeVuelo;
    private int capacidad;
    private int costoEnDolares;
    private Estado estado;
    private ListaSE<Pasajero> reservas;
    private ListaSE<Pasajero> checkIns;

    public Vuelo(String codigoAeropuertoOrigen, String codigoAeropuertoDestino, String codigoDeVuelo, int capacidad, int costoEnDolares) {
        this.codigoAeropuertoOrigen = codigoAeropuertoOrigen;
        this.codigoAeropuertoDestino = codigoAeropuertoDestino;
        this.codigoDeVuelo = codigoDeVuelo;
        this.capacidad = capacidad;
        this.costoEnDolares = costoEnDolares;
        this.estado = Estado.PROGRAMADO;
        this.reservas = new ListaSE<>();
        this.checkIns = new ListaSE<>();
    }

    public String getCodigoAeropuertoOrigen() { 
        return codigoAeropuertoOrigen; 
    }
    
    public String getCodigoAeropuertoDestino() { 
        return codigoAeropuertoDestino; 
    }
    
    public String getCodigoDeVuelo() { 
        return codigoDeVuelo; 
    }
    
    public int getCapacidad() { 
        return capacidad; 
    }
    
    public int getCostoEnDolares() {
        return costoEnDolares; 
    }
    
    public Estado getEstado() { 
        return estado; 
    }
    
    public ListaSE<Pasajero> getReservas() { 
        return reservas; 
    }
    
    public ListaSE<Pasajero> getCheckIns() {
        return checkIns; 
    }

    public void setEstado(Estado estado) {
        this.estado = estado; 
    }

    @Override
    public int compareTo(Vuelo otro) {
        return this.codigoDeVuelo.compareTo(otro.codigoDeVuelo);
    }
}
