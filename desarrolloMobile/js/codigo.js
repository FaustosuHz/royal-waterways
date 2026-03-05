const MENU = document.querySelector("#menu");
const ROUTER = document.querySelector("#ruteo");
const HOME = document.querySelector("#pantalla-home");
const REGISTRO = document.querySelector("#pantalla-registro");
const LOGIN = document.querySelector("#pantalla-login");
const MAPA = document.querySelector("#pantalla-map");
const URL_BASE = "https://movielist.develotion.com/";
const NAV = document.querySelector("ion-nav");
const AGREGAR_PELICULA = document.querySelector("#pantalla-agregarPelicula");
const ESTADISTICAS = document.querySelector("#pantalla-estadisticas");
let CATEGORIAS = [];
let PELICULAS = [];

Inicio();

function Inicio() {
  ArmarMenu();
  Eventos();
}

function Eventos() {
  ROUTER.addEventListener("ionRouteDidChange", Navegar);
  document.querySelector("#btnLogin").addEventListener("click", HacerLogin);
  document
    .querySelector("#btnIrAlRegistro")
    .addEventListener("click", IrAPaginaRegistro);
  document
    .querySelector("#btnIrAlLogin")
    .addEventListener("click", IrAPaginaLogin);
  document
    .querySelector("#btnIrAlHome")
    .addEventListener("click", IrAPaginaHome);
  document
    .querySelector("#btnRegistro")
    .addEventListener("click", AltaDeUsuario);
  document
    .querySelector("#btnAgregarPelicula")
    .addEventListener("click", AltaDePelicula);
  document
    .querySelector("#selectFiltroFecha")
    .addEventListener("ionChange", AplicarFiltro);
}

// Login 

async function HacerLogin() {
  let usuario = document.querySelector("#txtLoginUsuario").value;
  let password = document.querySelector("#txtLoginContrasenia").value;

  let ObjLogin = new Object();

  ObjLogin.usuario = usuario;
  ObjLogin.password = password;

  PrenderLoader("Ingresando");

  let response = await fetch(`${URL_BASE}login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(ObjLogin),
  });

  let data = await response.json();
  let mensaje = data.mensaje;

    if (data.codigo == 200) {
     localStorage.setItem("token", data.token);
     ArmarMenu();
     NAV.push("page-home");
     ApagarLoader();
  } else {
    ApagarLoader();
    Alertar("AVISO", "ERROR DE LOGIN", mensaje);
  }
}

function ArmarMenu() {
  let hayToken = localStorage.getItem("token");

  let html = ` `;

  if (hayToken) {
    html += `<ion-item href="/">Home</ion-item>
                 <ion-item href="/agregar-pelicula">Agregar Pelicula</ion-item>
                 <ion-item href="/map">Mapa de Usuarios</ion-item>
                 <ion-item href="/estadisticas">Estadisticas</ion-item>
                 <ion-item onclick="CerrarSesion()">Cerrar Sesion</ion-item>`;
  } else {
    html += `<ion-item href="/login">Login</ion-item>
                <ion-item href="/registro">Registrarse</ion-item> `;
  }

  document.querySelector("#menu-opciones").innerHTML = html;
}

function IrAPaginaRegistro() {
  NAV.push("page-registro");
}

function IrAPaginaLogin() {
  NAV.push("page-login");
}

function IrAPaginaHome() {
  NAV.push("page-home");
}

// Registro 

async function AltaDeUsuario() {
  let usuario = document.querySelector("#txtRegistroUsuario").value;
  let password = document.querySelector("#txtRegistroPassword").value;
  let pais = document.querySelector("#selectPaises").value;

  if (ValidarUsuario(usuario)) {
    if (ValidarPassword(password)) {
      if (ValidarPais(pais)) {
        let ObjRegistro = new Object();

        ObjRegistro.usuario = usuario;
        ObjRegistro.password = password;
        ObjRegistro.idPais = pais;

        PrenderLoader("Procesando");

        let response = await fetch(`${URL_BASE}usuarios`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(ObjRegistro),
        });

        let data = await response.json();
        let mensaje = data.mensaje;

        if (data.codigo == 200) {
          localStorage.setItem("token", data.token);

          ArmarMenu();
          NAV.push("page-home");
          ApagarLoader();
          MostrarToast("Usuario creado correctamente", 3000, "success");
        } else {
          ApagarLoader();
          Alertar("AVISO", "NO SE PUDO CREAR USUARIO", mensaje);
        }
      } else {
        Alertar("AVISO", "NO SE PUDO CREAR USUARIO", "Pais invalido");
      }
    } else {
      Alertar("AVISO", "NO SE PUDO CREAR USUARIO", "Contraseña invalida");
    }
  } else {
    Alertar("AVISO", "NO SE PUDO CREAR USUARIO", "Nombre de usuario invalido");
  }
}

function ValidarUsuario(usuario) {
  let valido = false;

  if (
    usuario.length > 0 &&
    usuario.length <= 20 &&
    usuario.toString().trim() != ""
  ) {
    valido = true;
  }

  return valido;
}

function ValidarPassword(password) {
  let valido = false;

  if (
    password.length > 0 &&
    password.length <= 20 &&
    password.toString().trim() != ""
  ) {
    valido = true;
  }

  return valido;
}

function ValidarPais(pais) {
  let valido = false;

  if (!isNaN(pais) && Number(pais) > 0 && pais != null) {
    valido = true;
  }

  return valido;
}

async function CargarPaisesDinamico() {
  let html = ` `;

  let response = await fetch(`${URL_BASE}paises`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  });

  let data = await response.json();
  let paises = data.paises;

  for (let p of paises) {
    html += `<ion-select-option value="${p.id}">${p.nombre}</ion-select-option>`;
  }
  document.querySelector("#selectPaises").innerHTML = html;
}

// Home 

async function ObtenerPeliculas() {
  let token = localStorage.getItem("token");
  let idUsuario = localStorage.getItem("idUsuario");
  let contenedor = document.querySelector("#contenedor-peliculas");

  if (token) {
    try {
      contenedor.innerHTML = '<ion-spinner name="crescent"></ion-spinner>';

      let response = await fetch(
        `${URL_BASE}/peliculas?idUsuario=${idUsuario}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
        },
      );

      let data = await response.json();
      console.log(data);

      if (response.status === 200) {
        PELICULAS = data.peliculas;
        DibujarPeliculas(PELICULAS);
      } else {
        mostrarMensaje("No se pudieron cargar las películas");
      }
    } catch (error) {
      console.error(error);
      mostrarMensaje("Error al cargar las películas");
    }
  }
}

function DibujarPeliculas(peliculas) {
  let contenedor = document.querySelector("#contenedor-peliculas");
  let mensajeVacio = document.querySelector("#mensaje-vacio");

  if (peliculas.length === 0) {
    contenedor.innerHTML = "";
    mensajeVacio.style.display = "block";
    return;
  }

  mensajeVacio.style.display = "none";
  let html = "<ion-list>";

  peliculas.forEach((p) => {
    let emoji = "🎬";

    for (let c of CATEGORIAS) {
      if (c.id == p.idCategoria) {
        emoji = c.emoji;
        break;
      }
    }

    html += `
        <ion-item-sliding>
            

            <ion-item>
              <span slot="start" style="font-size: 28px;">
                    ${emoji}
                </span>
              <ion-label>
                <h2>${p.nombre}</h2>
                <p>ID: ${p.id}</p>
              </ion-label>
            </ion-item>

            <ion-item-options side="end">
              <ion-item-option color="danger" onclick="EliminarPelicula(${p.id})">
                    Borrar
                </ion-item-option>
            </ion-item-options>
        </ion-item-sliding>
    `;
  });

  html += "</ion-list>";
  contenedor.innerHTML = html;
}

async function CargarCategoriasEnMemoria() {
  let token = localStorage.getItem("token");

  let response = await fetch(`${URL_BASE}categorias`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  });

  let data = await response.json();

  CATEGORIAS = data.categorias;
}

// Eliminar pelicula 

async function EliminarPelicula(id) {
  let token = localStorage.getItem("token");

  PrenderLoader("Eliminando...");

  let response = await fetch(`${URL_BASE}peliculas/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  });

  ApagarLoader();

  if (response.status === 200) {
    MostrarToast("Película eliminada correctamente", 2000, "success");
    ObtenerPeliculas();
  } else if (response.status === 401) {
    Alertar("AVISO", "Sesión expirada", "Vuelve a iniciar sesión");
    CerrarSesion();
  } else {
    Alertar("AVISO", "Error", "No se pudo eliminar la película");
  }
}

function AplicarFiltro() {
  let filtro = document.querySelector("#selectFiltroFecha").value;
  let peliculasFiltradas = [];

  if (filtro === "todas") {
    peliculasFiltradas = PELICULAS;
  } else if (filtro === "semana") {
    let hace7Dias = new Date();
    hace7Dias.setDate(hace7Dias.getDate() - 7);

    for (let i = 0; i < PELICULAS.length; i++) {
      let fechaPelicula = new Date(PELICULAS[i].fechaEstreno);

      if (fechaPelicula >= hace7Dias) {
        peliculasFiltradas.push(PELICULAS[i]);
      }
    }
  } else if (filtro === "mes") {
    let hace30Dias = new Date();
    hace30Dias.setDate(hace30Dias.getDate() - 30);

    for (let i = 0; i < PELICULAS.length; i++) {
      let fechaPelicula = new Date(PELICULAS[i].fechaEstreno);

      if (fechaPelicula >= hace30Dias) {
        peliculasFiltradas.push(PELICULAS[i]);
      }
    }
  }

  DibujarPeliculas(peliculasFiltradas);
}

// Agregar pelicula

async function CargarCategoriasDinamico() {
  let token = localStorage.getItem("token");
  let html = ``;

  let response = await fetch(`${URL_BASE}categorias`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  });

  if (response.status === 401) {
    PrenderLoader();
    Alertar("AVISO", "Credenciales invalidas", "Vuelve a Iniciar Sesion");
    ApagarLoader();
    IrAPaginaLogin();
    return;
  }

  if (!response.ok) {
    Alertar("AVISO", "Error", "No se pudieron cargar las categorias");
  }

  let data = await response.json();
  let categorias = data.categorias;

  CATEGORIAS = categorias;

  for (let c of categorias) {
    html += `<ion-select-option value="${c.id}">${c.nombre}</ion-select-option>`;
  }

  document.querySelector("#selectCategoria").innerHTML = html;
}

async function AltaDePelicula() {
  let token = localStorage.getItem("token");
  let idCategoria = document.querySelector("#selectCategoria").value;
  let nombrePelicula = document.querySelector("#txtNombrePelicula").value;
  let fecha = document.querySelector("#fechaVisualizacion").value;
  let comentario = document.querySelector("#txtComentarioPelicula").value;

  let validoIA = await validarComentarioConIa(comentario);

  if (validoIA) {
    if (validarComentario(comentario)) {
      if (validarCategoria(idCategoria)) {
        if (validarFecha(fecha)) {
          if (validarNombrePelicula(nombrePelicula)) {
            let ObjRegistro = new Object();

            ObjRegistro.idCategoria = idCategoria;
            ObjRegistro.nombre = nombrePelicula;
            ObjRegistro.fecha = fecha;

            PrenderLoader("Procesando");

            let response = await fetch(`${URL_BASE}peliculas`, {
              method: "POST",
              headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`,
              },
              body: JSON.stringify(ObjRegistro),
            });

            let data = await response.json();

            if (response.status === 401) {
              PrenderLoader();
              Alertar(
                "AVISO",
                "Credenciales invalidas",
                "Vuelve a Iniciar Sesion",
              );
              ApagarLoader();
              IrAPaginaLogin();
              return;
            }

            if (data.codigo == 200) {
              ApagarLoader();
              MostrarToast("Pelicula agregada correctamente", 3000, "success");
            } else {
              ApagarLoader();
              Alertar(
                "AVISO",
                "NO SE PUDO AGREGAR PELICULA",
                "Ocurrió un error",
              );
            }
          } else {
            Alertar("AVISO", "NO SE PUDO AGREGAR PELICULA", "Nombre invalido");
          }
        } else {
          Alertar(
            "AVISO",
            "NO SE PUDO AGREGAR PELICULA",
            "No se pueden elegir fechas futuras",
          );
        }
      } else {
        Alertar("AVISO", "NO SE PUDO AGREGAR PELICULA", "Categoria invalida");
      }
    } else {
      Alertar("AVISO", "NO SE PUDO AGREGAR PELICULA", "Comentario invalido");
    }
  } else {
    Alertar(
      "AVISO",
      "NO SE AGREGÓ LA PELICULA",
      "Parece que no te gustó la pelicula y no vale la pena agregarla",
    );
  }
}

function validarCategoria(id) {
  let valido = false;

  if (!isNaN(id) && Number(id) > 0 && id != null) {
    valido = true;
  }
  return valido;
}

function validarFecha(fecha) {
  let valido = false;

  const fechaDate = new Date(fecha);
  const hoy = new Date();

  if (fechaDate <= hoy) {
    valido = true;
  }

  return valido;
}

function validarNombrePelicula(nombre) {
  let valido = false;

  if (nombre.trim().length <= 80 || nombre.trim().length > 0) {
    valido = true;
  }

  return valido;
}

function validarComentario(comentario) {
  let valido = false;

  if (
    comentario != null ||
    comentario.length != 0 ||
    comentario.length <= 300
  ) {
    valido = true;
  }

  return valido;
}

async function validarComentarioConIa(comentario) {
  let valido = true;
  let prompt = comentario;

  let ObjValidar = new Object();

  ObjValidar.prompt = prompt;

  PrenderLoader("Procesando");

  let response = await fetch(`${URL_BASE}genai`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(ObjValidar),
  });

  let data = await response.json();
  let feedback = data.sentiment;

  if (feedback == "Negativo") {
    valido = false;
  }

  ApagarLoader();

  return valido;
}

// Mapa 

var map = null;

function CrearMapa() {
  if (map != null) {
    map.remove();
  }

  map = L.map("map").setView([-60.85850908856315, -65.20886834132471], 3);

  L.tileLayer("https://tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 5,
    minZoom: 3,
    attribution:
      '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
  }).addTo(map);

  crearMarcadores();
}

function CargarMapa() {
  setTimeout(function () {
    CrearMapa();
  }, 100);
}

async function crearMarcadores() {
  let token = localStorage.getItem("token");

  let responsePaises = await fetch(`${URL_BASE}paises`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  });

  let data = await responsePaises.json();
  let paises = data.paises;

  let responseUsuariosPorPais = await fetch(`${URL_BASE}usuariosPorPais`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  });

  let dataUsuariosPorPais = await responseUsuariosPorPais.json();
  let usuarioPais = dataUsuariosPorPais.paises;

  for (let p of paises) {
    let nombrePais = p.nombre;
    let usuariosPais = usuariosPorPais(nombrePais, usuarioPais);

    var marker = L.marker([`${p.latitud}`, `${p.longitud}`]).addTo(map);
    marker.bindPopup(`<b>${nombrePais}</b><br>${usuariosPais} usuarios`);
  }
}

function usuariosPorPais(nombrePais, listaPaises) {
  let usuarios = "";

  for (let p of listaPaises) {
    if (nombrePais.trim().toLowerCase() === p.nombre.trim().toLowerCase()) {
      usuarios = p.cantidadDeUsuarios;
    }
  }

  return usuarios;
}

// Estadisticas

function MostrarEstadisticas() {
  let html = "";

    html += `
    <ion-text>
      <h2 style="margin-top:10px;">🎬 Películas vistas</h2>
    </ion-text>
  `;

  for (let i = 0; i < CATEGORIAS.length; i++) {
    let categoria = CATEGORIAS[i];

    let cantidad = 0;

    for (let j = 0; j < PELICULAS.length; j++) {
      if (PELICULAS[j].idCategoria == categoria.id) {
        cantidad++;
      }
    }

    if (cantidad > 0) {
      html += `
                <p>${categoria.emoji} ${categoria.nombre} - ${cantidad} peliculas vistas</p>
              `;
    }
  }

  html += `
    <ion-text>
      <h2 style="margin-top:20px;">📊 Clasificación por edad</h2>
    </ion-text>
  `;

  let mayores = 0;
  let resto = 0;

  for (let i = 0; i < PELICULAS.length; i++) {
    let pelicula = PELICULAS[i];

    for (let j = 0; j < CATEGORIAS.length; j++) {
      if (pelicula.idCategoria == CATEGORIAS[j].id) {
        if (CATEGORIAS[j].edad_requerida > 12) {
          mayores++;
        } else {
          resto++;
        }
      }
    }
  }

  let total = PELICULAS.length;

  if (total > 0) {
    let porcentajeMayores = ((mayores * 100) / total).toFixed(1);
    let porcentajeResto = ((resto * 100) / total).toFixed(1);
    html += `
    <hr>
    <p>Peliculas mayores de 12 años: ${porcentajeMayores}%</p>
    <p>Resto de peliculas: ${porcentajeResto}%</p>
    `;
  }

  document.querySelector("#contenedor-estadisticas").innerHTML = html;
}

// Logout 

function CerrarSesion() {
  localStorage.clear();
  ArmarMenu();
  MENU.close();
  NAV.push("page-login");
}

async function Navegar(evento) {
  PrenderLoader("Procesando");
  let ruta = evento.detail.to;
  let hayToken = localStorage.getItem("token");
  OcultarPantallas();

  if (ruta == "/" && hayToken) {
    HOME.style.display = "block";

    await CargarCategoriasDinamico();
    ObtenerPeliculas();
  } else if (ruta == "/registro") {
    REGISTRO.style.display = "block";
    CargarPaisesDinamico();
  } else if (ruta == "/login") {
    LOGIN.style.display = "block";
  } else if (ruta == "/map" && hayToken) {
    MAPA.style.display = "block";
    CargarMapa();
  } else if (ruta == "/agregar-pelicula" && hayToken) {
    AGREGAR_PELICULA.style.display = "block";
    CargarCategoriasDinamico();
  }else if (ruta == "/estadisticas" && hayToken) {
    ESTADISTICAS.style.display = "block";
    await CargarCategoriasEnMemoria();
    await ObtenerPeliculas();
    MostrarEstadisticas();
  } else {
    IrAPaginaLogin();
  }

  MENU.close();
  ApagarLoader();
}

const loading = document.createElement("ion-loading");

function PrenderLoader(texto) {
  loading.cssClass = "my-custom-class";
  loading.message = texto;
  document.body.appendChild(loading);
  loading.present();
}

function ApagarLoader() {
  loading.dismiss();
}

function Alertar(titulo, subtitulo, mensaje) {
  const alert = document.createElement("ion-alert");
  alert.cssClass = "my-custom-class";
  alert.header = titulo;
  alert.subHeader = subtitulo;
  alert.message = mensaje;
  alert.buttons = ["OK"];
  document.body.appendChild(alert);
  alert.present();
}

function MostrarToast(mensaje, duracion, color) {
  const toast = document.createElement("ion-toast");
  toast.message = mensaje;
  toast.duration = duracion;
  toast.color = color;

  document.body.appendChild(toast);
  toast.present();
}

function OcultarPantallas() {
  HOME.style.display = "none";
  REGISTRO.style.display = "none";
  LOGIN.style.display = "none";
  MAPA.style.display = "none";
  AGREGAR_PELICULA.style.display = "none";
  ESTADISTICAS.style.display = "none";
}