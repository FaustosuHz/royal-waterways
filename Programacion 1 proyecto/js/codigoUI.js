function eventos() {
    document.querySelector("#btnRegistrar").addEventListener("click", registrarUser);
    document.querySelector("#ingresarRegistro").addEventListener("click", ingresarRegistro);
    document.querySelector("#ingresarLogin").addEventListener("click", ingresarLogin);
    document.querySelector(".volverPrincipio").addEventListener("click", volverPrincipio)
    document.querySelector("#btnLogin").addEventListener("click", loginUI)
    document.querySelector("#btnCerrarSesion").addEventListener("click", cerrarSesionUI)
    document.querySelector("#btnGestionContrataciones").addEventListener("click", gestionContratcionesUI)
    document.querySelector("#btnVerListadoAsignado").addEventListener("click", verListadoDePerrosAsignadosUI)
    document.querySelector("#btnlistaTodosPaseadores").addEventListener("click", verListadosDeTodosLosPaseadoresUI)
}

let miSistema = new Sistema();
miSistema.preCargaTodo();
eventos();
ocultarTodo()
mostrarLoginYRegistro();
asignarEventosVolver()


function ocultarTodo() {
    let lasSecciones = document.querySelectorAll(".secciones");
    for (let unaSeccion of lasSecciones) {
        unaSeccion.style.display = "none";
    }
}

function mostrarLoginYRegistro() {
    document.querySelector("#sectionLoginYRegistro").style.display="block"
}

function ingresarLogin() {
    ocultarTodo();
    document.querySelector("#sectionLogin").style.display="block"
}

function ingresarRegistro() {
    ocultarTodo();
    document.querySelector("#sectionRegistro").style.display="block"
}

function asignarEventosVolver() {
    let botones = document.querySelectorAll(".volverPrincipio");
    
    for (let i = 0; i < botones.length; i++) {
        botones[i].addEventListener("click", volverPrincipio);
    }
}

function volverPrincipio() {
    ocultarTodo()
    mostrarLoginYRegistro();
}

function registrarUser() {
    let nombre = document.querySelector("#txtUsuario").value;
    let contrasenia = document.querySelector("#txtContrasenia").value;
    let nombrePerro = document.querySelector("#txtNombrePerro").value;
    let tamanioPerro = document.querySelector("#tamanioPerro").value;

    let resultadoRegistro = miSistema.pudeAgregarCliente(nombre, contrasenia, nombrePerro, tamanioPerro)
        
    document.querySelector("#divMostrar").innerHTML = resultadoRegistro.mensaje;
}

function loginUI() {
    let mensaje=""
    document.querySelector("#errorLogin").innerHTML=""
    let usuario = document.querySelector("#txtUsuarioExistente").value;
    let contrasenia = document.querySelector("#txtContraseniaExistente").value;
    if (miSistema.login(usuario, contrasenia)) {
        ocultarTodo();
        document.querySelector("#cerrarSesion").style.display="block"

        if (miSistema.logueado.tipo ==="CLIENTE") {
           
            document.querySelector("#sectionCliente").style.display="block"
            document.querySelector("#pMostrarNombreCliente").innerHTML=miSistema.logueado.nombre;
            document.querySelector("#contratarPaseador").style.display="block"
            document.querySelector("#misContrataciones").style.display="block"
            mostrarComboPaseadoresUI()
            mostrarTablaPaseadorUI()
            mostrarResultadosUI()
        }
        if (miSistema.logueado.tipo==="PASEADOR") {

            document.querySelector("#sectionPaseador").style.display="block"
            document.querySelector("#pMostrarNombrePaseador").innerHTML=miSistema.logueado.nombre;
            document.querySelector("#sectionMostrarContrataciones").style.display= "block"
            document.querySelector("#sectionListadoDePerroAsignados").style.display ="block"
        }
    }
    else{
        mensaje="Nombre o contraseña incorrecta"
    }
   document.querySelector("#errorLogin").innerHTML=mensaje
}

function mostrarComboPaseadoresUI() {
  var comboPaseadores = miSistema.crearComboPaseadoresDisponibles();
  document.querySelector("#selPaseadores").innerHTML = comboPaseadores;
}

function mostrarTablaPaseadoresDisponiblesUi() {
    let idPaseador = Number(document.querySelector("#selPaseadores").value);

    if (idPaseador === -1) {  document.querySelector("#tablaPaseador").innerHTML = "";
    }
    else{miSistema.mostrarTablaPaseadoresDisponibles(idPaseador);

    document.querySelector("#btnContratar").addEventListener("click", contratarPaseadorUI)
    }
}

function mostrarTablaPaseadorUI() {
    document.querySelector("#selPaseadores").addEventListener("change", mostrarTablaPaseadoresDisponiblesUi);
}

function mostrarResultadosUI() {
    miSistema.mostrarMisContrataciones()
    miSistema.mostrarMisContratacionesReultado()
    const btnCancelar = document.querySelector("#btnCancelar");
    if (btnCancelar) {btnCancelar.addEventListener("click", cancelarContratacionUI);
    }
}

function contratarPaseadorUI(){
    let mensaje = "Usted no puede realizar una contratacion ya que tiene una en proceso!"
    let id = Number(document.querySelector("#selPaseadores").value);
    if (id !== -1) {
        if (miSistema.validarContratacionEstado()) {
            miSistema.contratarPaseadorSeleccionado(id);
        mensaje = "Contratación exitosa"
        }
    }
    document.querySelector("#tablaPaseador").innerHTML = mensaje;
    mostrarResultadosUI()
    document.querySelector("#btnCancelar").addEventListener("click", cancelarContratacionUI)
}

function cancelarContratacionUI(){
    miSistema.cancelarContratacion()
}

function verListadosDeTodosLosPaseadoresUI(){
     document.querySelector("#tablaTodosLosPaseadores").style.display="block"
     miSistema.verListadosDeTodosLosPaseadores()
}

function limpiarInputYSelect() {
    let inputsYSelect = document.querySelectorAll("input, select")
    for (let i = 0; i< inputsYSelect.length; i++) {
      let inputX= inputsYSelect[i]
      if (inputX.type !== "button") {
        inputX.value=""
      }
    }
}

function limpiarTablas(){
    document.querySelector("#tablaPaseador").innerHTML = "";
    document.querySelector("#tblGestionContrataciones").innerHTML = "";
    document.querySelector("#tblListadoPerroAsignado").innerHTML = "";
}

function limpiarMensajes() {
    document.querySelector("#errorLogin").innerHTML = "";
    document.querySelector("#divMostrar").innerHTML = "";
    document.querySelector("#pMostrarNombreCliente").innerHTML = "";
    document.querySelector("#pMostrarNombrePaseador").innerHTML = "";
}

function gestionContratcionesUI() {
    let tablaCuerpo = miSistema.armarCuerpoTablaDeContrataciones();
    document.querySelector("#tblGestionContrataciones").innerHTML = tablaCuerpo;

    darVidaTablaProcesarContratacionesUI() 
}

function darVidaTablaProcesarContratacionesUI() {
    let losBotones = document.querySelectorAll(".procesarContratacion");
    for(let unBoton of losBotones){
        unBoton.addEventListener("click", diClickEnProcesarContratacionUI)
    }
}

function diClickEnProcesarContratacionUI(){
    let miDato = this.getAttribute("miData");
    let idContratacionX = miDato.substr(15,miDato.length)
    let idContratacionNro = Number(idContratacionX)
      miSistema.procesarContratacion(idContratacionNro) 
      miSistema.validarContratacionesDespuesDeProcesar(idContratacionNro)
      gestionContratcionesProcesadoUI()

}

function gestionContratcionesProcesadoUI(){

    let tablaCuerpo = miSistema.armarCuerpoTablaContratacionesProcesando();
    document.querySelector("#tblGestionContrataciones").innerHTML = tablaCuerpo

    darVidaTablaProcesarContratacionesUI() 
}

function verListadoDePerrosAsignadosUI() {
    let tablaCuerpo = miSistema.armarCuerpoTablaListadoPerroAsignado();
    document.querySelector("#tblListadoPerroAsignado").innerHTML =tablaCuerpo;
}

function cerrarSesionUI() {
    ocultarTodo();
    miSistema.cerrarSesion()
    limpiarMensajes()
    limpiarTablas()
    limpiarInputYSelect()
    mostrarLoginYRegistro();
}

window.sistema = miSistema;