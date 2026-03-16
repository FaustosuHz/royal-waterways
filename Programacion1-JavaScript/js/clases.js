class Cliente{
    static idCliente = 0;
    constructor(){
        this.id = Cliente.idCliente++;
        this.nombre = "";
        this.contrasenia= "";
        this.perro = "";
        this.tamanio= "";
        this.tipo="CLIENTE";
    }
}
 
class Paseador{
    static idPaseador = 0;
    constructor(){
        this.id =Paseador.idPaseador++;
        this.nombre = "";
        this.usuario="";
        this.contrasenia = "";
        this.cuposMaximos= -1;
        this.tipo="PASEADOR";
    }
}

class Contratacion {
    static idContratacion= 0;
    constructor() {
        this.id = Contratacion.idContratacion++;
        this.Cliente = null;
        this.Paseador = null;
        this.estado = "PENDIENTE";
        this.comentario = ""
    }
}