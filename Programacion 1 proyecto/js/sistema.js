class Sistema {
    constructor() {
        this.listaClientes = new Array();
        this.listaPaseadores = new Array();
        this.listaContrataciones = new Array();
        this.logueado = null;
    } 


preCargaTodo(){
    precargaClientes();
    precargaPaseador() ;
    precargaContrataciones() 
}

validarNombreVacio(nombreUser) {
    let valido = false;
    if (nombreUser.trim().length > 0) {
    valido = true;
    }
    return valido;
}

nombreUnico(nombreUser) {
    let esUnico = true;
    let esUnicoPaseador = true;
    let esUnicoCliente = true;
    let i = 0;
    while (i < this.listaClientes.length && esUnicoCliente) {
        let unCliente = this.listaClientes[i];
        let nombreMayus = nombreUser.toUpperCase()
        let unClienteMayus = unCliente.nombre.toUpperCase()

        if (unCliente.nombre === nombreUser || nombreMayus === unClienteMayus) {
            esUnicoCliente= false;
        }
        i++;
    }
    let e = 0;
    while (e < this.listaPaseadores.length && esUnicoPaseador) {
        let unPaseador = this.listaPaseadores[e];
        let nombreMayus = nombreUser.toUpperCase()
        let unPaseadorMayus = unPaseador.nombre.toUpperCase();

        if (unPaseador.nombre === nombreUser || nombreMayus === unPaseadorMayus) {
            esUnicoPaseador = false;
        }
        e++;
    } 
    if (!esUnicoCliente || !esUnicoPaseador) {
    esUnico = false;
} 
    return esUnico;
}

validarContrasenia(contrasenia) {
    let valido = false;
    let tieneMay= false
    let tieneMin= false
    let tieneNum= false
    if (contrasenia.length >= 5) {  
        for (let i = 0; i < contrasenia.length; i++) {
            let letra= contrasenia.charAt(i);
            if (letra === letra.toUpperCase() && isNaN(letra))tieneMay= true;
            
            if(letra === letra.toLowerCase()&& isNaN(letra))tieneMin=true
            if(!isNaN(letra))tieneNum=true
        } 
    }
    if(tieneMay && tieneMin && tieneNum)valido=true

    return valido;
}

validarPerro(nombre, tamanio) {
    let valido = false;
    if (nombre.trim().length > 0) { 
         if (tamanio === "1" || tamanio === "2" ||tamanio === "4") {
            
            valido = true;
        }
    }
    return valido;
}

esUnNumeroValido(num){
    let bandera = false;
    if (!isNaN(num) && num > 0) {
        bandera = true
    }
    return bandera;
}

 pudeAgregarCliente(nombre, contrasenia, nombrePerro, tamanioPerro) {

    if (!this.validarNombreVacio(nombre)) {
        return { pude: false, mensaje: "NOMBRE DE USUARIO NO VALIDO" };
    }                                                                       /* esta bien ya que no puede exister ninguno con el mismo nombre */
    if (!this.nombreUnico(nombre)) {
        return { pude: false, mensaje: "EL USUARIO YA EXISTE" };
    }
    if (!this.validarContrasenia(contrasenia)) {
        return { pude: false, mensaje: "SU CONTRASEÑA TIENE QUE TENER UN MÍNIMO DE 5 CARACTERES, UNA MAYÚSCULA, UNA MINÚSCULA Y UN NÚMERO" };
    }
    if (!this.validarPerro(nombrePerro, tamanioPerro)) {
        return { pude: false, mensaje: "DATOS DEL PERRO INVALIDOS" };
    }

    this.almacenarclientes(nombre, contrasenia, nombrePerro, tamanioPerro)
    return { 
        pude: true, mensaje: "Usuario agregado correctamente" };
}
    
// Paseador
 pudeAgregarPaseador(nombre, usuario, contrasenia, cuposMaximos) {

    if (!this.validarNombreVacio(nombre)) {
        return { pude: false, mensaje: "NOMBRE DE USUARIO NO VALIDO" };
    }
    if (!this.nombreUnico(nombre)) {
        return { pude: false, mensaje: "EL NOMBRE YA EXISTE" };
    }
    if (!this.validarNombreVacio(usuario)) {
        return { pude: false, mensaje: "USUARIO DE USUARIO NO VALIDO" };
    }
    if (!this.validarContrasenia(contrasenia)) {
        return { pude: false, mensaje: "SU CONTRASEÑA TIENE QUE TENER UN MÍNIMO DE 5 CARACTERES, UNA MAYÚSCULA, UNA MINÚSCULA Y UN NÚMERO" };
    }
    if (!this.esUnNumeroValido(cuposMaximos)) {
        return { pude: false, mensaje: "NUMERO DE CUPOS INVALIDO" };
    }

    this.almacenarPaseador(nombre, usuario, contrasenia, cuposMaximos)
    return { 
        pude: true, mensaje: "Usuario agregado correctamente" };
}

almacenarclientes(nombre, contrasenia, nombrePerro, tamanioPerro){
    let listaclientes = new Cliente()
    listaclientes.nombre = nombre
    listaclientes.contrasenia = contrasenia
    listaclientes.perro = nombrePerro
    listaclientes.tamanio = tamanioPerro

    this.listaClientes.push(listaclientes);
}

almacenarPaseador(nombre, usuario, contrasenia, cuposMaximos){
    let listaPaseadores = new Paseador();
    listaPaseadores.nombre = nombre
    listaPaseadores.usuario=usuario
    listaPaseadores.contrasenia=contrasenia
    listaPaseadores.cuposMaximos=cuposMaximos;

    this.listaPaseadores.push(listaPaseadores);
}

login(pUsuario, pContrenia) {
    let valido = false;
    let i = 0 
    while(!valido && i < this.listaClientes.length){
        let clienteX = this.listaClientes[i]
        if (clienteX.nombre === pUsuario) {
            if (clienteX.contrasenia === pContrenia) {
                valido=true

                this.logueado = clienteX;
            }
        }
        i++
    }
    let e = 0
        while(!valido && e < this.listaPaseadores.length){
        let paseadorX = this.listaPaseadores[e]
        if (paseadorX.usuario === pUsuario) {
            if (paseadorX.contrasenia === pContrenia) {
                valido=true

                this.logueado = paseadorX;
            }
        }
        e++
    }
    return valido
}

cuposPorTamanio(tamanio) {
    if (tamanio === "1") return 1; // pequeño
    if (tamanio === "2") return 2; // mediano
    if (tamanio === "4") return 4; // grande
    return 0;
}

paseadoresDisponiblesPorCupo(paseador) {
    let cuposCliente = this.cuposPorTamanio(this.logueado.tamanio);
    return cuposCliente <= paseador.cuposMaximos;
}

paseadoresDisponiblesPorTamanio(paseador) {
    let tamanioPerroUsuario = this.logueado.tamanio;

    for (let unaContratacion of this.listaContrataciones) {
        if (unaContratacion.Paseador.id === paseador.id) {
            let tamanioYaContratado = unaContratacion.Cliente.tamanio

            if ((tamanioYaContratado === "1" && tamanioPerroUsuario === "3") || (tamanioYaContratado === "3" && tamanioPerroUsuario === "1")) {
                return false;
            }
        }
    }

    return true;
}

crearComboPaseadoresDisponibles() {
    let paseadoresDisponibles = '<option value="-1">Paseadores disponibles</option>';

    for (let paseador of this.listaPaseadores) {
        if (this.paseadoresDisponiblesPorTamanio(paseador) &&
            this.paseadoresDisponiblesPorCupo(paseador)) {

            paseadoresDisponibles += `<option value="${paseador.id}">${paseador.nombre}</option>`;
        }
    }
    return paseadoresDisponibles;
}

armarTablaPaseador(paseador) {
    let tabla = `<table border="1">
                    <tr><th>Nombre</th><th>Acción</th></tr>
                    <tr><td>${paseador.nombre}</td><td><input type="button" value="Contratar" id="btnContratar"></td></tr>
                 </table>`;
    return tabla;
}

mostrarTablaPaseadoresDisponibles(idPaseador) {
    let paseador = null;
    for (let i = 0; i < this.listaPaseadores.length; i++) {
        if (this.listaPaseadores[i].id === idPaseador) {
            paseador = this.listaPaseadores[i];                    
            break;
        }
    }

    let tablaPaseador = this.armarTablaPaseador(paseador);
    document.querySelector("#tablaPaseador").innerHTML = tablaPaseador;
}




nuevaContratacion(cliente, paseador) {
        let nuevaContratacion = new Contratacion();
        nuevaContratacion.Cliente = cliente;
        nuevaContratacion.Paseador = paseador;
        this.listaContrataciones.push(nuevaContratacion);
}




validarContratacionEstado(){
    let valido = true
    let i = 0; 
    while (valido && i<this.listaContrataciones.length) {
        let contratacionX = this.listaContrataciones[i]
        if (this.logueado.id === contratacionX.Cliente.id) {
            if (contratacionX.estado === "PENDIENTE" || contratacionX.estado === "PROCESADA") {
                valido = false
            }
        }
        i++
    }
return valido;
}

contratarPaseadorSeleccionado(idPaseador) {
    let clienteLogueado = this.logueado;
    let paseadorSeleccionado = null;
    let estado = "PENDIENTE"
    if (this.validarContratacionEstado()) {
        
    for (let i = 0; i < this.listaPaseadores.length; i++) {
        if (this.listaPaseadores[i].id === idPaseador) {
            paseadorSeleccionado = this.listaPaseadores[i];
        }
    }

    this.nuevaContratacion(clienteLogueado, paseadorSeleccionado, estado);
    }
}

mostrarMisContrataciones() {
    let tabla= "Aun no tienes contrataciones"
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let unaContratacion = this.listaContrataciones[i];
        if (this.logueado !== null && unaContratacion.Cliente.id === this.logueado.id && unaContratacion.estado === "PENDIENTE") {

            tabla = `<table border="1"><tr><th>Nombre</th> <th>Estado</th> <th>Acción</th></tr>`+
            `<tr> <td>${unaContratacion.Paseador.nombre}</td><td> ${unaContratacion.estado}</td><td><input type="button" value="Cancelar" id="btnCancelar"></td></tr></table> <br><br>`
        }
    }
    document.querySelector("#tablaMiContratacion").innerHTML = tabla;
}

mostrarMisContratacionesReultado() {
    let tabla= ""
    let tabla2= ""
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let unaContratacion = this.listaContrataciones[i];
        if (this.logueado !== null && unaContratacion.Cliente.id === this.logueado.id && unaContratacion.estado != "PENDIENTE" && unaContratacion.estado != "CANCELADA") {

            tabla += `<table border="1"><tr><th>Nombre</th> <th>Estado</th>`+
            `<tr> <td>${unaContratacion.Paseador.nombre}</td><td> ${unaContratacion.estado}</td></tr></table>`
        
            document.querySelector("#tablaMiContratacion").innerHTML = tabla2;
        }
    }
    document.querySelector("#tablaMiContratacion2").innerHTML = tabla;
}

cancelarContratacion() {
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let unaContratacion = this.listaContrataciones[i];
        if (this.logueado !== null && unaContratacion.Cliente.id === this.logueado.id && unaContratacion.estado === "PENDIENTE") {
           unaContratacion.estado = "CANCELADA"
           this.mostrarMisContrataciones()
        }
    }
}


verListadosDeTodosLosPaseadores() {
    let tabla = `<table border="1"> <tr><th>Nombre</th> <th>Cantidad de Perros Asignados</th></tr>`;
    for (let i = 0; i < this.listaPaseadores.length; i++) {
        let unPaseador = this.listaPaseadores[i];
        let cantidadPerros = 0;
        for (let n = 0; n < this.listaContrataciones.length; n++) {
            let unaContratacion = this.listaContrataciones[n];
            if (unaContratacion.Paseador.id === unPaseador.id && unaContratacion.estado === "PROCESADA") {
                cantidadPerros++;
            }
        }
        tabla += `<tr>
            <td>${unPaseador.nombre}</td>
            <td>${cantidadPerros}</td>
        </tr>`;
    }
    tabla += `</table>`;
    document.querySelector("#tablaTodosLosPaseadores").innerHTML = tabla;
}

obtenerObjetoCliente(idCliente){
        let clienteBuscado = null;
        let i = 0;
        let idNumber = Number(idCliente)

        while (clienteBuscado ===null && i < this.listaClientes.length) {
            let clienteX = this.listaClientes[i];
            if (clienteX.id === idNumber) {
                clienteBuscado = clienteX;
            }
        i++    
        }
        return clienteBuscado;
    }

obtenerObjetoPaseador(idPaseador){
        let paseadorBuscado= null;
        let i = 0;
        let idNumber = Number(idPaseador);
        while (paseadorBuscado === null && i < this.listaPaseadores.length) {
            let paseadorX = this.listaPaseadores[i];
            if (paseadorX.id === idNumber) {
                paseadorBuscado = paseadorX;
            }
            i++
        }
        return paseadorBuscado;
    }

validarPrecargaContratacion(pIdPaseador, pIdCliente) {
    let valido = false;
    let elPaseador = this.obtenerObjetoPaseador(pIdPaseador);
    let elCliente = this.obtenerObjetoCliente(pIdCliente);

    if (elCliente !==null && elPaseador !==null) {                                                          /* arreglar la validacion para la precarga, que sea como la de procesar */
            valido = true;   
    }
    return valido;
}

armarCuerpoTablaDeContrataciones(){
    let unaTablaCuerpo =`<th>Nombre</th> <th>Nombre del Perro</th> <th>tamaño</th> <th>estado</th> <th>ACCION</th><th>Respuesta</th>`
    let hayContratacionesPendientes = false
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let unaContratacion = this.listaContrataciones[i];
        if (this.logueado !== null && unaContratacion.Paseador.nombre === this.logueado.nombre  && unaContratacion.estado === "PENDIENTE" ) {
           unaTablaCuerpo += `<tr> <td> ${unaContratacion.Cliente.nombre} </td> <td> ${unaContratacion.Cliente.perro} </td> <td> ${this.obetenerNombreDeTamanio(unaContratacion.Cliente.tamanio)} </td> <td>${unaContratacion.estado} </td> `
        unaTablaCuerpo += `<td><input value="Procesar" miData="contratacionId-${unaContratacion.id}" type="button" class="procesarContratacion"/></td>`
          unaTablaCuerpo += `<td id="resultado-${unaContratacion.id}">${unaContratacion.comentario}</td></tr> `  
            hayContratacionesPendientes= true
        }
    }
    if (!hayContratacionesPendientes) {
        unaTablaCuerpo=`<td> USTED NO TIENE CONTRATACIONES PENDIENTES<td>`
    }
return unaTablaCuerpo
}

armarCuerpoTablaContratacionesProcesando(){
    let unaTablaCuerpo =`<th>Nombre</th> <th>Nombre del Perro</th> <th>tamaño</th> <th>estado</th> <th>ACCION</th><th>Respuesta</th>`
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let unaContratacion = this.listaContrataciones[i];
        if (this.logueado !==null && unaContratacion.Paseador.id === this.logueado.id) {
             unaTablaCuerpo += `<tr> <td> ${unaContratacion.Cliente.nombre} </td> <td> ${unaContratacion.Cliente.perro} </td> <td> ${this.obetenerNombreDeTamanio(unaContratacion.Cliente.tamanio)} </td> <td>${unaContratacion.estado} </td> `
            if (unaContratacion.estado === "PENDIENTE") {
                unaTablaCuerpo += `<td><input value="Procesar" miData="contratacionId-${unaContratacion.id}" type="button" class="procesarContratacion"/></td>`
            }else{
                unaTablaCuerpo+= "<td> </td>"
            }
            unaTablaCuerpo += `<td id="resultado-${unaContratacion.id}">${unaContratacion.comentario}</td></tr> `
        }
    }
    return unaTablaCuerpo
}

armarCuerpoTablaListadoPerroAsignado(){
    let unaTablaCuerpo = `<th>Nombre del perro</th> <th>Tamaño</th> <th>CUPOS</th><th>CuposTotales/CUPOs Maximos</th> <th>Porcetaje</th>`
  let cuposUtilizados=0
  let hayContratcionesAsignadsa= false
        for (let i = 0; i < this.listaContrataciones.length; i++) {
            let unaContratacion = this.listaContrataciones[i];
            
            if (this.logueado !== null && unaContratacion.Paseador.id === this.logueado.id && unaContratacion.estado=== "PROCESADA") {
                cuposUtilizados+= this.cuposPorTamanio(unaContratacion.Cliente.tamanio)
                let porcentaje = parseInt((cuposUtilizados / unaContratacion.Paseador.cuposMaximos) * 100);
                unaTablaCuerpo+= `<tr> <td>${unaContratacion.Cliente.perro}</td> <td>${this.obetenerNombreDeTamanio(unaContratacion.Cliente.tamanio)}</td><td>${unaContratacion.Cliente.tamanio}</td><td>${cuposUtilizados}/${unaContratacion.Paseador.cuposMaximos}</td> <td>%${porcentaje}</td> </tr>`
                hayContratcionesAsignadsa = true
            }
        }
        if (!hayContratcionesAsignadsa) {
            unaTablaCuerpo=`<td> USTED NO TIENE CONTRATACIONES ASIGNADAS<td>`
        }
       
    return unaTablaCuerpo
}

obetenerNombreDeTamanio(numTamanio){
    let numDeTamanño = this.cuposPorTamanio(numTamanio)
    let tamnioTexto=""
    if (numDeTamanño === 1) tamnioTexto ="Pequeño";

    if (numDeTamanño === 2) tamnioTexto ="Intermedio";

    if (numDeTamanño === 4) tamnioTexto ="Grande";

    return tamnioTexto
}

obtenerContratacionXid(idCon){
    let laContratacion = null;
    let i = 0;
    while (laContratacion === null && i< this.listaContrataciones.length) {
        let contratacionX = this.listaContrataciones[i];
        if (contratacionX.id ===idCon ) {
            laContratacion = contratacionX;
        }
        i++
    }
return laContratacion
}

obtenerCuposDisponible(pContratacionID) {
    let laContratacion = this.obtenerContratacionXid(pContratacionID);
    let idPaseador = laContratacion.Paseador.id;

    let CantidadCuposUsandos = 0;

    for (let i = 0; i < this.listaContrataciones.length; i++) {
        let contratacionX = this.listaContrataciones[i];
        if (contratacionX.Paseador.id === idPaseador && contratacionX.estado === "PROCESADA") {
            CantidadCuposUsandos += Number(contratacionX.Cliente.tamanio);
        }
    }

    let elPaseador = this.obtenerObjetoPaseador(idPaseador);
    let cuposDisponibles = elPaseador.cuposMaximos - CantidadCuposUsandos;
    return cuposDisponibles;
}


procesarContratacion(pIdContratacion){
    let todoBien = false;
    let laContratacion = this.obtenerContratacionXid(pIdContratacion);
     let tamanioPerro = this.validacionDeCondicionalDeTamanio(laContratacion.Paseador.id);
    let tamanioCliente = this.cuposPorTamanio(laContratacion.Cliente.tamanio)
    if (this.contratacionNoContratada(laContratacion.Cliente.id) && laContratacion.estado === "PENDIENTE"){
            if (
                (tamanioPerro === 1 && (tamanioCliente === 1 || tamanioCliente === 2)) ||
                (tamanioPerro === 4 && (tamanioCliente === 4|| tamanioCliente === 2)) ||
                (tamanioPerro === 2 )
            ) {

                let cuposDisponibles = this.obtenerCuposDisponible(laContratacion.id)
        if (cuposDisponibles  >= Number(laContratacion.Cliente.tamanio)) {
             laContratacion.estado ="PROCESADA"
            laContratacion.comentario = "PROCESADA"
            todoBien = true

        }else{
            laContratacion.comentario="Cupos insuficinetes"
        }
        }else{

if (tamanioPerro === 1) laContratacion.comentario="Usted solo puede pasear perro pequeños"
if (tamanioPerro === 4) laContratacion.comentario="Usted solo puede pasear perro grandes"
        }
    }else{
        laContratacion.comentario ="ya tiene una contratacion procesada"
    }
    if (!todoBien) {
        laContratacion.estado="CANCELADO"
    }
    return todoBien
}


validacionDeCondicionalDeTamanio(pPaseadorId) {
    let listaContrtacionXPaseador = this.obtenerListaContratacionPorPaseador(pPaseadorId);
    let valido = false;
    let i = 0;

    while (i < listaContrtacionXPaseador.length && !valido) {
        let contratacionX = listaContrtacionXPaseador[i];
        let numTamanio = this.cuposPorTamanio(contratacionX.Cliente.tamanio)
            if (contratacionX.estado ==="PROCESADA") {
    

        if (numTamanio === 1) {
            valido = true;
            return 1; 
        }

        if (numTamanio === 4) {
            valido = true;
            return 4; // Solo puede pasear grande e intermedio
        }
}
        i++;
    }
    return 2;
}

validarContratacionesDespuesDeProcesar(idContratacion){

     let laContratacion = this.listaContrataciones[idContratacion];
    let elPaseador = laContratacion.Paseador;
let tamanioPerro = this.validacionDeCondicionalDeTamanio(elPaseador.id);
    let listaContratcionesDePaseadorX = this.obtenerListaContratacionPorPaseador(elPaseador.id); 
    for (let i = 0; i < listaContratcionesDePaseadorX.length; i++) {
        let contratacionX = listaContratcionesDePaseadorX[i];
        
        let tamanioCliente = this.cuposPorTamanio(contratacionX.Cliente.tamanio)
        let modificado= true;
        if (contratacionX.estado ==="PENDIENTE" ) {

            if (this.contratacionNoContratada(contratacionX.Cliente.id)) {
                if (
                    (tamanioPerro === 1 && (tamanioCliente === 1 || tamanioCliente === 2)) ||
                    (tamanioPerro === 4 && (tamanioCliente === 4 || tamanioCliente === 2)) ||
                  (tamanioPerro === 2 /* && tamanioCliente === 2 */)
                ) {
                    
                
                    if (this.obtenerCuposDisponible(contratacionX.id) >= Number(contratacionX.Cliente.tamanio)) {
                    modificado = false;
                    }else{
                    contratacionX.comentario="Cupos insuficinetes"
                    }   
            }
                else{
                    if (tamanioPerro ===1) contratacionX.comentario="Usted solo puede pasear perro pequeños"
                    if (tamanioPerro ===4) contratacionX.comentario="Usted solo puede pasear perro grandes"
                }

            }else{
                contratacionX.comentario= "ya tiene una contratacion preocesada"
            }
            if (modificado) {
                
                contratacionX.estado = "CANCELADO"
                console.log(contratacionX.id +"RECHAZADO AUTOMATICO")
            }
            
        }
    }
}

obtenerListaContratacionPorPaseador(pPaseadorId){
    let lista = new Array();
    for (let i = 0; i < this.listaContrataciones.length; i++) {
        if (this.listaContrataciones[i].Paseador.id === pPaseadorId) {
            lista.push(this.listaContrataciones[i])
        }    
    }
    return lista
}

contratacionNoContratada(pIdCliente){
    let noTiene= true;
    let i = 0;
    while (noTiene && i < this.listaContrataciones.length) {
        let unaContratacion = this.listaContrataciones[i];
        if (unaContratacion.Cliente.id == pIdCliente) {
            if (unaContratacion.estado == "PROCESADA") {
                noTiene=false;

            }
        }
        i++
    }
    return noTiene;
}

cerrarSesion() {
    this.logueado = null;
    this.mostrarMisContrataciones() //refresca la vista luego de cerrar sesion
    this.mostrarMisContratacionesReultado()
}

}